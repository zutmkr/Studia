import random
import winsound
import os
from msvcrt import getch

import przedmiot
import rysuj_obrazy
import podziemia
import pokoj
import funkcje

prawda_falsz = [True, False]
        

class Gracz:
    lista = []  # lista przedmiotow
    pozycja = []
    punkty = 0

    # atrybuty postaci
    s = 10  # sila
    pz = 39  # punkty zycia

    def pokaz_staty(self):
        print('Sila postaci: ', self.s)
        print('Pozostale punkty zycia: ', self.pz)

    def pokaz_plecak(self):
        for Przedmiot in self.lista:
            print(Przedmiot.nazwa)

    def karta_postaci(self):
        os.system('cls')  # czyszczenie ekranu
        with open('static/warrior.txt') as plik:
            print(plik.read())
        self.pokaz_staty()

    def pobierz_pozycje(self, maps):
        for i in range(len(maps.mapa)):
            try:
                if maps.mapa[i].index(self) >= 0:
                    self.pozycja = []
                    self.pozycja.append(i)
                    self.pozycja.append(maps.mapa[i].index(self))
            except:
                continue

    def dodaj_do_plecak(self):
        if random.choice(prawda_falsz):
            self.lista.append(przedmiot.Wartosciowy().dodaj_przedmiot())
            self.punkty += 1
            funkcje.status = ''
            if not self.lista[-1].nazwa.find('legendarne'):
                winsound.PlaySound('sound/legenda.wav', winsound.SND_ASYNC)
                funkcje.status = 'Zdobyles LEGENDARNY przedmiot, otrzymujesz +5 do sily!!!'
                self.s += 5
        else:
            self.lista.append(przedmiot.Smiec().dodaj_przedmiot())
            self.punkty -= 1
            funkcje.status = ''


class Potwor(Gracz):
    def __init__(self,imie,s,pz):
        self.imie = imie
        self.s = s
        self.pz = pz
        self.pmax = pz

    def walka_gui(self, status, gr):
        os.system('cls')
        rysuj_obrazy.rysuj_potwora('static/' + self.imie + '.txt')
        print('Musisz walczyc z ', self.imie, ' ', self.pz, '/', self.pmax, 'PZ')
        print('\t\t\t\t\t\tDOZWOLONE AKCJE')
        print('\t\t\t\t\t\t\tf - Atak bronia')
        print('\t\t\t\t\t\t\tj - Ucieczka(20% szans)\n\n')
        print('\t\t\t\t\t\t\tTwoje PZ: ', gr.pz)
        print('Status: ', status)
        

class Uzdrowiciel(Gracz):
    def __init__(self, gr):
        os.system('cls')  # czyszczenie ekranu
        rysuj_obrazy.rysuj_potwora('static/uzdr.txt')
        print('Spotykasz Uzdrowiciela!!!')
        print('Otrzymujesz +3 Punkty Zycia')
        gr.pz += 3
        getch()
