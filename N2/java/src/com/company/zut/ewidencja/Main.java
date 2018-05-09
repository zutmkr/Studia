package com.company.zut.ewidencja;

import java.util.Scanner;
import java.sql.DriverManager;
import java.sql.Connection;
import java.sql.SQLException;
import java.util.TimeZone;

import com.company.zut.ewidencja.Dyrektor;
import com.company.zut.ewidencja.Handlowiec;
import com.company.zut.ewidencja.Pracownik;

public class Main {

    static Scanner input = new Scanner(System.in);
    static  String DB_URL = "jdbc:postgresql://localhost:5432/ewidencja";
    static  String USER = "user1";
    static  String PASSWORD = "1234";



    public static void main(String[] args) {

        Connection connection = null;

        try {
            connection = DriverManager.getConnection(DB_URL,USER,PASSWORD);
            connection.setAutoCommit(false);

            printMenu();

        } catch (SQLException e) {
            e.printStackTrace();
        }
    }

    public static void printInfo(){

    }

    public static void Add(){
        System.out.println("Dodaj Pracownika");
        System.out.println("[D]yrektor/[H]handlowiec:");

        char selectMenuEntry = input.next().charAt(0);
        if (selectMenuEntry == 'D') {
            Dyrektor dyrektor = new Dyrektor("0", "0", "0", 0, "Dyrektor",
                    "0");
            dyrektor.addUser();
        }
        if (selectMenuEntry == 'H') {
            Handlowiec handlowiec = new Handlowiec("0", "0", "0", 0,
                    "Handlowiec", "0");
            handlowiec.addUser();
        }
    }


    public static void clearScreen() {
        System.out.print("\033[H\033[2J");
        System.out.flush();
    }

    private static void printMenu(){

        char selectMenuEntry = 0;
        while(selectMenuEntry != '4'){
            System.out.println("Glowne menu programu do ewidencji pracownikow");
            System.out.println("1. Lista pracownikow");
            System.out.println("2. Dodaj pracownika");
            System.out.println("3. Usun pracownika");
            System.out.println("4. Kopia zapasowa");
            System.out.println("5. Wyjdz z programu");

            selectMenuEntry = input.next().charAt(0);
            switch(selectMenuEntry){
                case '1':
                    printInfo();
                    break;
                case '2':
                    Add();
                    break;
                case '3':
                    //todo
                    break;
                case '4':
                    //todo
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
}
