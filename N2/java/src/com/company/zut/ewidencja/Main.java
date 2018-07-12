package com.company.zut.ewidencja;

import Server.ServerThread;

import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.io.IOException;
import java.io.ObjectInputStream;
import java.math.BigDecimal;
import java.net.Socket;
import java.sql.*;
import java.util.ArrayList;
import java.util.Iterator;
import java.util.Scanner;





public class Main {

    static Scanner input = new Scanner(System.in);
    static  String DB_URL = "jdbc:postgresql://localhost:5432/ewidencja";
    static  String USER = "user1";
    static  String PASSWORD = "1234";




    public static void main(String[] args) {

        Connection connection = null;

        ServerThread server = new ServerThread(1111);
        server.setDaemon(true);
        server.start();

        try {
            connection = DriverManager.getConnection(DB_URL,USER,PASSWORD);
            connection.setAutoCommit(false);

            printMenu(connection);
            connection.close();

        } catch (SQLException e) {
            e.printStackTrace();
        }
    }

    public static void printInfo(Connection conn){

        ArrayList<Pracownik> lista_pracownikow = null;
        Statement stmt = null;

        try {
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

        Iterator it = lista_pracownikow.iterator();

        int next = 0;

        char op;
        do {
            if (!it.hasNext()) {
                return;
            }

            (lista_pracownikow.get(next++)).showInfo();
            System.out.println("[D]\tDalej");
            System.out.println("[Q]\tWyjście");
            op = input.next().charAt(0);
            if (op != 'Q') {
                it.next();
            }
        } while(op != 'Q' && op != 'q');




    }

    public static void Add(Connection conn){
        System.out.println("Dodaj Pracownika");
        System.out.println("[D]yrektor/[H]handlowiec:");

        char selectMenuEntry = input.next().charAt(0);
        PreparedStatement prepareInsertUser;

        if (selectMenuEntry == 'D') {
            Dyrektor dyrektor = new Dyrektor("0", "0", "0", 0, "Dyrektor",
                    "0");
            dyrektor.addUser();
            try {
                prepareInsertUser = conn.prepareStatement("INSERT INTO pracownicy (imie, nazwisko, pesel, wynagrodzenie, stanowisko, telefon, dodatek_sluzbowy) VALUES (?, ?, ?, ?, ?, ?, ?)");
                prepareInsertUser.setString(1, dyrektor.getImie());
                prepareInsertUser.setString(2, dyrektor.getNazwisko());
                prepareInsertUser.setString(3, dyrektor.getPesel());
                prepareInsertUser.setInt(4, dyrektor.getWynagrodzenie());
                prepareInsertUser.setString(5, dyrektor.getStanowisko());
                prepareInsertUser.setString(6, dyrektor.getTelefon());
                prepareInsertUser.setBigDecimal(7, dyrektor.getDodatekSluzbowy());
                prepareInsertUser.executeUpdate();
                conn.commit();
            } catch (SQLException e) {
                e.printStackTrace();
            }



        }
        if (selectMenuEntry == 'H') {
            Handlowiec handlowiec = new Handlowiec("0", "0", "0", 0,
                    "Handlowiec", "0");
            handlowiec.addUser();

            try {
                prepareInsertUser = conn.prepareStatement("INSERT INTO pracownicy (imie, nazwisko, pesel, wynagrodzenie, stanowisko, telefon, stawka_prowizji) VALUES (?, ?, ?, ?, ?, ?, ?)");
                prepareInsertUser.setString(1, handlowiec.getImie());
                prepareInsertUser.setString(2, handlowiec.getNazwisko());
                prepareInsertUser.setString(3, handlowiec.getPesel());
                prepareInsertUser.setInt(4, handlowiec.getWynagrodzenie());
                prepareInsertUser.setString(5, handlowiec.getStanowisko());
                prepareInsertUser.setString(6, handlowiec.getTelefon());
                prepareInsertUser.setBigDecimal(7, handlowiec.getStawkaProwizji());
                prepareInsertUser.executeUpdate();
                conn.commit();
            } catch (SQLException e) {
                e.printStackTrace();
            }
        }
    }


    public static void clearScreen() {
        System.out.print("\033[H\033[2J");
        System.out.flush();
    }

    public static void Delete(Connection conn){
        ArrayList<Pracownik> lista_pracownikow = null;
        Statement stmt = null;
        String sql;
        try {
            lista_pracownikow = new ArrayList();
            stmt = conn.createStatement();
            sql = "SELECT imie, nazwisko, pesel, wynagrodzenie, stanowisko, telefon, dodatek_sluzbowy, stawka_prowizji FROM pracownicy";
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

        Iterator it = lista_pracownikow.iterator();
        int index = 0;

        char op;
        do {
            if (!it.hasNext()) {
                return;
            }

            (lista_pracownikow.get(index)).showInfo();
            System.out.println("[D]\tDalej");
            System.out.println("[U]\tUsuń");
            System.out.println("[Q]\tWyjdz");
            op = input.next().charAt(0);
            if (op != 'U') {
                it.next();
                ++index;
            }

            if (op == 'U') {
                sql = "DELETE FROM pracownicy WHERE pesel LIKE '" + (lista_pracownikow.get(index)).getPesel() + "'";
                lista_pracownikow.remove(index);
                System.out.println(sql);

                try {
                    stmt = conn.createStatement();
                    stmt.execute(sql);
                    conn.commit();

                    stmt.close();
                } catch (SQLException e) {
                    e.printStackTrace();
                }

                return;
            }
        } while(op != 'Q' && op != 'q');

    }




    private static void printMenu(Connection conn){

        char selectMenuEntry = 0;
        while(selectMenuEntry != '5'){
            System.out.println("Glowne menu programu do ewidencji pracownikow");
            System.out.println("1. Lista pracownikow");
            System.out.println("2. Dodaj pracownika");
            System.out.println("3. Usun pracownika");
            System.out.println("4. Pobierz dane z sieci");
            System.out.println("5. Wyjdz z programu");

            selectMenuEntry = input.next().charAt(0);
            switch(selectMenuEntry){
                case '1':
                    printInfo(conn);
                    break;
                case '2':
                    Add(conn);
                    break;
                case '3':
                    Delete(conn);
                    break;
                case '4':
                    DownloadData(conn);
                    break;
                case '5':
                    System.out.println("Program konczy dzialanie");
                    break;
                default:
                    System.out.println("Nie ma takiej opcji");
                    break;
            }
           // clearScreen();
        }

    }

    public static void DownloadData(Connection conn)  {

        String addr="";
        int port = 0;

        String message = "get_all";

        System.out.println("Podaj adres:");
        Scanner line = new Scanner(System.in);
        String input = line.nextLine();
        if(!input.isEmpty())
            addr = new String(input);
        input = "";

        System.out.println("Podaj port:");
        Scanner line2 = new Scanner(System.in);
        input = line2.nextLine();
        if(!input.isEmpty())
            port = Integer.valueOf(input);
        input = "";

        System.out.println("Adres\t:\t" + addr);
        System.out.println("Port\t:\t" + port);
        System.out.println("-----------------------");
        System.out.print("Zakonczenie\t:\t");

        Socket s;
        try {
            s = new Socket(addr, port);
            if(s.isConnected()) {
                System.out.println("Sukces");
            }
            DataOutputStream dos = new DataOutputStream(s.getOutputStream());
            dos.writeUTF(message);

            DataInputStream dis = new DataInputStream(s.getInputStream());

            ObjectInputStream ois = new ObjectInputStream(dis);

            //System.out.println("is object avalitable: " + ois.available());


            ArrayList<Pracownik> pracownicy =  (ArrayList<Pracownik>) ois.readObject();

            Iterator it = pracownicy.iterator();
            String op;
            int index = 0;
            while(it.hasNext()){

                pracownicy.get(index++).showInfo();
                System.out.println("[Enter]\tDalej");
                System.out.println("[Q]\tWyjscie");

                op = line.nextLine();
                if(op.equals("")) it.next();
                if(op.equals("Q") || op.equals("q")) return;
            }

            dos.close();
        } catch (IOException e) {
            e.printStackTrace();
        } catch (ClassNotFoundException e) {
            e.printStackTrace();
        }

    }
}
