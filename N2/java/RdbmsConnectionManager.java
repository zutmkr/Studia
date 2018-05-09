package pl.zut.zjava;

import java.sql.Connection;
import java.sql.SQLException;

import javax.sql.DataSource;

import org.apache.commons.dbcp2.ConnectionFactory;
import org.apache.commons.dbcp2.DriverManagerConnectionFactory;
import org.apache.commons.dbcp2.PoolableConnection;
import org.apache.commons.dbcp2.PoolableConnectionFactory;
import org.apache.commons.dbcp2.PoolingDataSource;
import org.apache.commons.pool2.ObjectPool;
import org.apache.commons.pool2.impl.GenericObjectPool;

import pl.zut.zjava.commons.Config;

public class RdbmsConnectionManager {
	
	private static RdbmsConnectionManager _instance;
	
	private DataSource dataSource;
	
	
	public static Connection GetConnection() throws SQLException {
		
		if ( _instance == null ) {
			_instance = new RdbmsConnectionManager();
		}
		
		return _instance.getConnection();
	}
	
	
	private RdbmsConnectionManager() {
		this.initializeConnectionPool();
	}
	
	
	private void initializeConnectionPool() {
		
		ConnectionFactory connectionFactory = 
				new DriverManagerConnectionFactory(Config.getDbConnectionString());
		
		PoolableConnectionFactory poolableConnectionFactory =
				new PoolableConnectionFactory(connectionFactory, null);
		
		ObjectPool<PoolableConnection> connectionPool =
				new GenericObjectPool<>(poolableConnectionFactory);

		this.dataSource = new PoolingDataSource<>(connectionPool);
	}
	
	
	private Connection getConnection() throws SQLException {
		
		Connection conn = dataSource.getConnection();
		conn.setAutoCommit(false);
		
		return conn;
	}
}
