# -*- coding: utf-8 -*-
import os
import sys
import pickle
import generator_map
import podziemia
import uczestnicy
import funkcje
from msvcrt import getch
from pdb import set_trace as bp
from rysuj_obrazy import *


PIK = "save/objects.bj"

os.system('mode con: cols=115 lines=55')


def menu_glowne():

    od = 0
    do = 5  
    
    os.system('cls')  # czyszczenie ekranu
    rysuj("static/LOGO.txt")
    rysuj("lang/PL/menu_glowne_instrukcje.txt")
    rysuj_oddo("lang/PL/menu_glowne.txt",od,do)
    
    
    while True:
        #inp = getch().decode("utf-8")
        inp = input()
        if inp == 'w' and od >= 6:
            od -= 6
            do -= 6
            os.system('cls')  # czyszczenie ekranu
            rysuj("static/LOGO.txt")
            rysuj("lang/PL/menu_glowne_instrukcje.txt")
            rysuj_oddo("lang/PL/menu_glowne.txt",od,do)
        elif inp == 's' and od >= 0 and do < 23:
            od += 6
            do += 6
            os.system('cls')  # czyszczenie ekranu
            rysuj("static/LOGO.txt")
            rysuj("lang/PL/menu_glowne_instrukcje.txt")
            rysuj_oddo("lang/PL/menu_glowne.txt",od,do)
        elif inp == 'k':
            if od >=0 and do <=6:
                nowa_gra()
            elif od >=6 and do <=12:
                wczytaj_gre()
            elif od >=12 and do <=18:
                extra()
            elif od >=18 and do <=24:
                wyjdz_z_gry()
   
   
def nowa_gra(poziom_pgen = None, wielkosc_mapygen = None, punkty_zycia = None, sila = None):
    gr = uczestnicy.Gracz()
    while gr.imie == '':
        gr.imie = input("NADAJ IMIĘ SWOJEMU WOJOWNIKOWI\n\t")
        if len(gr.imie) > 9:
            print('IMIE ZA DLUGIE. MAX 9 ZNAKÓW')
            gr.imie = ''
    funkcje.status = ''

    if poziom_pgen is not None or wielkosc_mapygen is not None or punkty_zycia is not None:
        podziemia.poziom_p = poziom_pgen.get()
        maps = generator_map.mapsgen
        gr.pz = punkty_zycia.get()
        gr.s = sila.get()
    else:
        podziemia.poziom_p = 1
        maps = podziemia.Mapa()
        maps.przygotuj_mape()

    maps.mapa[0][0] = gr
    gr.pobierz_pozycje(maps)
    funkcje.widocznosc(gr, maps)
    maps.rysuj_mape()
    funkcje.poruszanie_po_mapie(gr, maps)

    
def wczytaj_gre():
    data2 = []
    gr = uczestnicy.Gracz()
    maps = podziemia.Mapa()
    
    with open(PIK, "rb") as f:
        for _ in range(pickle.load(f)):
            data2.append(pickle.load(f))
    
    gr = data2[0]
    maps = data2[1]
    podziemia.poziom_p = data2[2]
    gr.lista = data2[3]
    gr.zadania = data2[4]
    
    if gr.imie == '':
        gr.imie = input("NADAJ IMIĘ SWOJEMU WOJOWNIKOWI\n\t")
    
    gr.pobierz_pozycje(maps)
    maps.rysuj_mape()
    funkcje.poruszanie_po_mapie(gr, maps)

    
def wyjdz_z_gry():
    sys.exit(0)

    
def extra():
    od = 24
    do = 28  
    
    os.system('cls')  # czyszczenie ekranu
    rysuj("static/LOGO.txt")
    rysuj("lang/PL/menu_glowne_instrukcje.txt")
    rysuj_oddo("lang/PL/menu_glowne.txt",od,do)
    
    
    while True:
        #inp = getch().decode("utf-8")
        inp = input()
        if inp == 'w' and od >= 28:
            od -= 5
            do -= 5
            os.system('cls')  # czyszczenie ekranu
            rysuj("static/LOGO.txt")
            rysuj("lang/PL/menu_glowne_instrukcje.txt")
            rysuj_oddo("lang/PL/menu_glowne.txt",od,do)
        elif inp == 's' and od >= 24 and do < 37:
            od += 5
            do += 5
            os.system('cls')  # czyszczenie ekranu
            rysuj("static/LOGO.txt")
            rysuj("lang/PL/menu_glowne_instrukcje.txt")
            rysuj_oddo("lang/PL/menu_glowne.txt",od,do)
        elif inp == 'k':
            if od >=24 and do <=28:
                generator_map.generator()
            elif od >=28 and do <=34:
                opcje()
            elif od >=34 and do <=39:
                menu_glowne()
def opcje():
    od = 39
    do = 43  
    
    os.system('cls')  # czyszczenie ekranu
    rysuj("static/LOGO.txt")
    rysuj("lang/PL/menu_glowne_instrukcje.txt")
    rysuj_oddo("lang/PL/menu_glowne.txt",od,do)
    
    
    while True:
        #inp = getch().decode("utf-8")
        inp = input()
        if inp == 'w' and od >= 43:
            od -= 5
            do -= 5
            os.system('cls')  # czyszczenie ekranu
            rysuj("static/LOGO.txt")
            rysuj("lang/PL/menu_glowne_instrukcje.txt")
            rysuj_oddo("lang/PL/menu_glowne.txt",od,do)
        elif inp == 's' and od >= 39 and do < 52:
            od += 5
            do += 5
            os.system('cls')  # czyszczenie ekranu
            rysuj("static/LOGO.txt")
            rysuj("lang/PL/menu_glowne_instrukcje.txt")
            rysuj_oddo("lang/PL/menu_glowne.txt",od,do)
        elif inp == 'k':
            if od >=39 and do <=43:
                getch()
            elif od >=43 and do <=48:
                os.system('cls')  # czyszczenie ekranu
                rysuj("static/O_GRZE.txt")
                return False
            elif od >=48 and do <=54:
                extra()
    
    
menu_glowne()
