package com.company.zut.ewidencja;

import java.io.Serializable;
import java.math.BigDecimal;
import java.util.Scanner;

public class Handlowiec extends Pracownik implements Serializable {

    private BigDecimal stawkaProwizji;

    public BigDecimal getStawkaProwizji() {
        return stawkaProwizji;
    }

    public void setStawkaProwizji(BigDecimal stawkaProwizji) {
        this.stawkaProwizji = stawkaProwizji;
    }

    public Handlowiec(String imie, String nazwisko, String pesel, Integer wynagrodzenie, String stanowisko, String telefon)
    {
        super(imie, nazwisko, pesel, wynagrodzenie, stanowisko, telefon);
    }


    public void showInfo(){
        System.out.println("-------------HANDLOWIEC--------------------");

        System.out.println("Imie            : " + getImie());
        System.out.println("Nazwisko        : " + getNazwisko());
        System.out.println("Pesel           : " + getPesel());
        System.out.println("Wynagrodzenie   : " + getWynagrodzenie() + " PLN");
        System.out.println("Stanowisko      : " + getStanowisko());
        System.out.println("Telefon         : " + getTelefon());
        System.out.println("Stawka prowizji : " + getStawkaProwizji());

        System.out.println("--------------------------------------------");
    }

    public void addUser(){
        Scanner scanner = new Scanner(System.in);
        String input;
        Integer intInput;
        BigDecimal bigInput;

        System.out.println("Podaj Imie: ");
        input = scanner.nextLine();
        this.setImie(input);

        System.out.println("Podaj Nazwisko: ");
        input = scanner.nextLine();
        this.setNazwisko(input);

        System.out.println("Podaj Pesel: ");
        input = scanner.nextLine();
        this.setPesel(input);

        System.out.println("Podaj Wynagrodzenie: ");
        intInput = Integer.parseInt(scanner.nextLine());
        this.setWynagrodzenie(intInput);

        /*
        System.out.println("Podaj Stanowisko: ");
        input = scanner.nextLine();
        this.setStanowisko(input);
        */

        System.out.println("Podaj Telefon: ");
        input = scanner.nextLine();
        this.setTelefon(input);

        System.out.println("Podaj Stawke prowizji: ");
        bigInput = BigDecimal.valueOf(Integer.parseInt(scanner.nextLine()));
        this.setStawkaProwizji(bigInput);



    }


}
