package com.company.zut.ewidencja;


import java.io.Serializable;
import java.math.BigDecimal;
import java.util.Scanner;


public class Dyrektor extends Pracownik implements Serializable {

   private BigDecimal dodatekSluzbowy;

   public BigDecimal getDodatekSluzbowy() {
      return dodatekSluzbowy;
   }

   public void setDodatekSluzbowy(BigDecimal dodatekSluzbowy) {
      this.dodatekSluzbowy = dodatekSluzbowy;
   }

   public Dyrektor(String imie, String nazwisko, String pesel, Integer wynagrodzenie, String stanowisko, String telefon)
   {
        super(imie, nazwisko, pesel, wynagrodzenie, stanowisko, telefon);
   }


   public void showInfo(){
       System.out.println("-------------DYREKTOR---------------------");

       System.out.println("Imie            : " + getImie());
       System.out.println("Nazwisko        : " + getNazwisko());
       System.out.println("Pesel           : " + getPesel());
       System.out.println("Wynagrodzenie   : " + getWynagrodzenie() + " PLN");
       System.out.println("Stanowisko      : " + getStanowisko());
       System.out.println("Telefon         : " + getTelefon());
       System.out.println("Dodatek Sluzbowy: " + getDodatekSluzbowy());

       System.out.println("------------------------------------------");
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

      /* System.out.println("Podaj Stanowisko: ");
        input = scanner.nextLine();
        this.setStanowisko(input);
       */
       System.out.println("Podaj Telefon: ");
       input = scanner.nextLine();
       this.setTelefon(input);

       System.out.println("Podaj Dodatek sluzbowy: ");
       bigInput = BigDecimal.valueOf(Integer.parseInt(scanner.nextLine()));
       this.setDodatekSluzbowy(bigInput);
   }



}

