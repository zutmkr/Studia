package com.company.zut.ewidencja;
import java.io.Serializable;

public abstract class Pracownik implements Serializable {
    private static final long serialVersionUID = 3798185773189585963L;
    private String imie;
    private String nazwisko;
    private String pesel;
    private Integer wynagrodzenie;
    private String stanowisko;
    private String telefon;

    public Pracownik(){}

    public Pracownik(String imie, String nazwisko, String pesel, Integer wynagrodzenie, String stanowisko, String telefon) {
        this.imie = imie;
        this.nazwisko = nazwisko;
        this.pesel = pesel;
        this.wynagrodzenie = wynagrodzenie;
        this.stanowisko = stanowisko;
        this.telefon = telefon;
    }

    public void setImie(String imie) {
        this.imie = imie;
    }

    public void setNazwisko(String nazwisko) {
        this.nazwisko = nazwisko;
    }

    public void setPesel(String pesel) {
        this.pesel = pesel;
    }

    public void setWynagrodzenie(Integer wynagrodzenie) {
        this.wynagrodzenie = wynagrodzenie;
    }

    public void setStanowisko(String stanowisko) {
        this.stanowisko = stanowisko;
    }

    public void setTelefon(String telefon) {
        this.telefon = telefon;
    }

    public String getImie() {
        return imie;
    }

    public String getNazwisko() {
        return nazwisko;
    }

    public String getPesel() {
        return pesel;
    }

    public Integer getWynagrodzenie() {
        return wynagrodzenie;
    }

    public String getStanowisko() {
        return stanowisko;
    }

    public String getTelefon() {
        return telefon;
    }

    public abstract void showInfo();
    public abstract void addUser();

}


