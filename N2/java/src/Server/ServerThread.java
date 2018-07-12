package Server;
import com.company.zut.ewidencja.Handlowiec;
import com.company.zut.ewidencja.Pracownik;
import com.company.zut.ewidencja.Dyrektor;

import java.io.IOException;
import java.io.ObjectOutputStream;
import java.math.BigDecimal;
import java.net.InetAddress;
import java.net.ServerSocket;
import java.net.Socket;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;


public class ServerThread extends Thread{
    private ServerSocket server;
    protected List<ClientHolder> clients;
    public static final String MESSAGE_GET_ALL = "get_all";

    static  String DB_URL = "jdbc:postgresql://localhost:5432/ewidencja";
    static  String USER = "user1";
    static  String PASSWORD = "1234";

    public ServerThread(int port) {

        try {

            server = new ServerSocket(port);
            System.out.println("Server listening at " +
                    InetAddress.getLocalHost() +
                    " on port " + server.getLocalPort());

        } catch (IOException e) {
            e.printStackTrace();
        }

        clients = new ArrayList<ClientHolder>();
    }

    public void run() {



        while(true) {
            Socket s;
            ArrayList<Pracownik> employees = null;
            try {
                s = server.accept();

                ClientHolder client = new ClientHolder(s);

                String message = client.getDis().readUTF();
                System.out.println(message);

                if(MESSAGE_GET_ALL.equals(message)) {

                    employees = new ArrayList();

                    employees = getAllEmployees();
                }

                ObjectOutputStream oos = new ObjectOutputStream(client.getDos());

                oos.writeObject(employees);

                oos.flush();

                client.getDos().close();
                client.getDis().close();

            } catch (IOException e) {
                e.printStackTrace();
            }
        }
    }


    private ArrayList<Pracownik> getAllEmployees() {

        Scanner line = new Scanner(System.in);
        ArrayList<Pracownik> lista_pracownikow = null;
        Statement stmt = null;

        try {
            Connection conn = DriverManager.getConnection(DB_URL,USER,PASSWORD);
            conn.setAutoCommit(false);

            lista_pracownikow = new ArrayList();

            stmt = conn.createStatement();
            String sql = "SELECT imie, nazwisko, pesel, wynagrodzenie, stanowisko, telefon, dodatek_sluzbowy, stawka_prowizji FROM pracownicy";
            ResultSet rs = stmt.executeQuery(sql);

            while(rs.next()) {
                String imie = rs.getString("imie");
                String nazwisko = rs.getString("nazwisko");
                String pesel = rs.getString("pesel");
                Integer wynagrodzenie = rs.getInt("wynagrodzenie");
                String stanowisko = rs.getString("stanowisko");
                String telefon = rs.getString("telefon");
                BigDecimal dodatek_sluzbowy = rs.getBigDecimal("dodatek_sluzbowy");
                BigDecimal stawka_prowizji = rs.getBigDecimal("stawka_prowizji");
                if (stanowisko.equals("Dyrektor")) {
                    Dyrektor dyrektor = new Dyrektor(imie, nazwisko, pesel, wynagrodzenie, stanowisko, telefon);
                    dyrektor.setDodatekSluzbowy(dodatek_sluzbowy);
                    lista_pracownikow.add(dyrektor);
                } else {
                    Handlowiec handlowiec = new Handlowiec(imie, nazwisko, pesel, wynagrodzenie, stanowisko, telefon);
                    handlowiec.setStawkaProwizji(stawka_prowizji);
                    lista_pracownikow.add(handlowiec);
                }
            }

            rs.close();
            stmt.close();
        } catch (SQLException e) {
            e.printStackTrace();
        }

        return lista_pracownikow;
    }
}
