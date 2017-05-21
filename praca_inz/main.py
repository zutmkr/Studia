import os
import sys
import pickle
from msvcrt import getch

import podziemia
import uczestnicy
import funkcje
from rysuj_obrazy import * 

PIK = "save/objects.bj"

os.system('mode con: cols=115 lines=50')


def menu_glowne():

    od = 1
    do = 5  
    
    os.system('cls')  # czyszczenie ekranu
    rysuj_logo()
    rysuj("lang/PL/menu_glowne_instrukcje.txt")
    rysuj_gl_menu("lang/PL/menu_glowne.txt",od,do)
    
    
    while True:
        inp = getch().decode("utf-8")
        #inp = input()
        if inp == 'w' and od >= 7:
            od -= 6
            do -= 6
            os.system('cls')  # czyszczenie ekranu
            rysuj_logo()
            rysuj("lang/PL/menu_glowne_instrukcje.txt")
            rysuj_gl_menu("lang/PL/menu_glowne.txt",od,do)
        elif inp == 's' and od >= 1 and do < 23:
            od += 6
            do += 6
            os.system('cls')  # czyszczenie ekranu
            rysuj_logo()
            rysuj("lang/PL/menu_glowne_instrukcje.txt")
            rysuj_gl_menu("lang/PL/menu_glowne.txt",od,do)
        elif inp == 'k':
            if od >=1 and do <=7:
                nowa_gra()
            elif od >=7 and do <=11:
                wczytaj_gre()
            elif od >=19 and do <=23:
                wyjdz_z_gry()
            
        
        
    
    
def nowa_gra():
    gr = uczestnicy.Gracz()
    podziemia.poziom_p = 1
    maps = podziemia.Mapa()
    
    maps.mapa[0][0] = gr
    
    maps.przygotuj_mape()
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
    
    gr.pobierz_pozycje(maps)
    maps.rysuj_mape()
    funkcje.poruszanie_po_mapie(gr, maps)

def wyjdz_z_gry():
    sys.exit(0)
    

menu_glowne()


