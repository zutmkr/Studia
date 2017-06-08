import random
import winsound
import os
import sys
import pickle
from math import ceil
from msvcrt import getch
from time import sleep

import pokoj
import uczestnicy
import podziemia
import rysuj_obrazy

import logging
logging.basicConfig(filename='error_logs/errors.log', level=logging.DEBUG, format='%(asctime)s %(levelname)s %(name)s %(message)s')
logger=logging.getLogger(__name__)


prawda_falsz = [True, False]
status = ''
PIK = "save/objects.bj"


def sciana():
    global status
    status = 'Nie możesz tam iść, to ściana.'
    
def zapisz_gre(gr,maps):
    data = [gr,maps, podziemia.poziom_p, gr.lista, gr.zadania]
    
    with open(PIK, "wb") as f:
        pickle.dump(len(data), f)
        for value in data:
            pickle.dump(value, f)
            
def handel(gr,ha):
    wyb = ''

    ha.dodaj_do_plecak()
    ha.dodaj_do_plecak()
    ha.dodaj_do_plecak()

    
    while wyb != '0':
        os.system('cls')  # czyszczenie ekranu
        rysuj_obrazy.rysuj_potwora('static/handl.txt')
        print('\t\tSpotykasz Handlarza!!!\n')
        print('>W czym mogę pomóc?\n\t\t\t Handlarz posiada ', ha.zloto, ' sztuk złota\n')
        print('\t1) Pokaż mi swoje towary. (kupuj)')
        print('\t2) Zobacz co mam. (sprzedawaj)')
        if gr.zadania[3] == 1 and gr.zadania[5] == 1:
            print('\t3) Oddaj zadanie (Dostań nagrodę!)')
        print('\t0) Żegnam.\t\t Twoje złoto: ', gr.zloto)
        print('AKTUALNA SILA:', gr.s)
        wyb = input('\nTwój wybór: ')
        s = 0
        if wyb == '1':
            ha.sprzedaj_kup(gr,wyb,s)
        elif wyb == '2':
            gr.sprzedaj_kup(ha,wyb,s)
        elif gr.zadania[3] == 1 and gr.zadania[4] == 1 and gr.zadania[5] == 1:
            print("Jesteś POTĘŻNY!\n\
            Dzięki za zniszczenie ostatniego \n\
            przedstawiciela jego gatunku. Oto obiecana \n\
            nagroda.")
            getch()
            gr.dodaj_do_plecak()
            gr.punkty += 10
            gr.zadania[3] = 0
            gr.zadania[4] = 0
            gr.zadania[5] = 0
            print("Otrzymałeś przedmiot! - ", gr.lista[-1].nazwa)
            getch()
        elif gr.zadania[3] == 1 and gr.zadania[4] == 0 and gr.zadania[5] == 1:
            print("\tJesteś WIELKI!\n\
            Te gargulce nieprędko wrócą. \n\
            W końcu będę miał spokój. Oto obiecana \n\
            nagroda.")
            getch()
            gr.dodaj_do_plecak()
            gr.punkty += 20
            gr.zadania[3] = 0
            gr.zadania[4] = 0
            gr.zadania[5] = 0
            uczestnicy.gargulce = 0
            print("Otrzymałeś przedmiot! - ", gr.lista[-1].nazwa)
            getch()
    try:
        if random.choice(prawda_falsz):
            if gr.zadania[3] == 0:
                ha.quest(gr)
    except Exception as e:
        logger.error(e)    
      
def event(gr, maps):
    ha = uczestnicy.Handlarz()
    ha.zloto *= podziemia.poziom_p * 1.25
    p = random.randint(0,3)
    #p = 1
    if p == 0:
        uczestnicy.Uzdrowiciel(gr)
    elif p == 1:
        handel(gr,ha)
    else:
        rozpocznij_walke(gr)

def widocznosc(gr, maps):
    # boki dolne
    if gr.pozycja[0] < len(maps.mapa) and gr.pozycja[1] < len(maps.mapa):
        try:
            maps.mapa[gr.pozycja[0] + 1][gr.pozycja[1]].widoczny = True
        except:
            pass
        try:
            maps.mapa[gr.pozycja[0] + 1][gr.pozycja[1] + 1].widoczny = True  # dp
        except:
            pass

    # boki gorne
    if gr.pozycja[0] > 0 and gr.pozycja[1] < len(maps.mapa):
        try:
            maps.mapa[gr.pozycja[0] - 1][gr.pozycja[1]].widoczny = True
        except:
            pass
        try:
            maps.mapa[gr.pozycja[0] - 1][gr.pozycja[1] + 1].widoczny = True  # gp
        except:
            pass
        try:
            maps.mapa[gr.pozycja[0]][gr.pozycja[1] + 1].widoczny = True
        except:
            pass

    # bok lewy
    if gr.pozycja[1] > 0 and gr.pozycja[0] > 0:
        try:
            maps.mapa[gr.pozycja[0]][gr.pozycja[1] - 1].widoczny = True
        except:
            pass
        try:
            maps.mapa[gr.pozycja[0] + 1][gr.pozycja[1] - 1].widoczny = True  # dl
        except:
            pass
        try:
            maps.mapa[gr.pozycja[0] - 1][gr.pozycja[1] - 1].widoczny = True  # gl
        except:
            pass

    try:
        maps.mapa[gr.pozycja[0]][gr.pozycja[1] + 1].widoczny = True
    except:
        pass


def poruszanie_po_mapie(gr, maps):
    global status
    gr.pobierz_pozycje(maps)
    # winsound.PlaySound('sound/fire.wav', winsound.SND_ASYNC | winsound.SND_LOOP | winsound.SND_FILENAME)
    # winsound.PlaySound(None, winsound.SND_PURGE) # brak dzwieku

    while True:
        print('Status: ', status)
        if gr.pz == 0:
            sys.exit(0)
        h = input('\n\nQuo vadis?>')

        if h == 'w':
            w(gr, maps)
        elif h == 's':
            s(gr, maps)
            maps.stworz_nowa_mape(gr)
        elif h == 'a':
            a(gr, maps)
        elif h == 'd':
            d(gr, maps)
            maps.stworz_nowa_mape(gr)
        elif h == 'c':
            gr.karta_postaci()
            getch()
        elif h == 'i':
            gr.pokaz_plecak()
            getch()
        elif h == '`':
            zapisz_gre(gr,maps)
            print('Do zobaczenia bohaterze!')
            sleep(2)
            sys.exit(0)
        else:
            status = 'Złą drogą kroczysz!'
        widocznosc(gr, maps)
        maps.rysuj_mape()        
        
        
def stala_pozycja(gr, maps):
    global status
    maps.mapa[gr.pozycja[0]][gr.pozycja[1]] = pokoj.Pokoj()
    maps.mapa[gr.pozycja[0]][gr.pozycja[1]].przedmiot = False
    gr.pobierz_pozycje(maps)


def w(gr, maps):
    if gr.pozycja[0] - 1 >= 0 and maps.mapa[gr.pozycja[0] - 1][gr.pozycja[1]].otwarty:
        try:
            if maps.mapa[gr.pozycja[0] - 1][gr.pozycja[1]].event:
                event(gr, maps)
            if maps.mapa[gr.pozycja[0] - 1][gr.pozycja[1]].przedmiot:
                gr.dodaj_do_plecak()
        except:
            pass
        maps.mapa[gr.pozycja[0] - 1][gr.pozycja[1]] = gr
        stala_pozycja(gr, maps)
    else:
        sciana()


def s(gr, maps):
    if gr.pozycja[0] + 1 < len(maps.mapa) and maps.mapa[gr.pozycja[0] + 1][gr.pozycja[1]].otwarty:
        try:
            if maps.mapa[gr.pozycja[0] + 1][gr.pozycja[1]].event:
                event(gr, maps)
            if maps.mapa[gr.pozycja[0] + 1][gr.pozycja[1]].przedmiot:
                gr.dodaj_do_plecak()
        except:
            pass
        maps.mapa[gr.pozycja[0] + 1][gr.pozycja[1]] = gr
        stala_pozycja(gr, maps)
    else:
        sciana()


def a(gr, maps):
    if gr.pozycja[1] - 1 >= 0 and maps.mapa[gr.pozycja[0]][gr.pozycja[1] - 1].otwarty:
        try:
            if maps.mapa[gr.pozycja[0]][gr.pozycja[1] - 1].event:
                event(gr, maps)
            if maps.mapa[gr.pozycja[0]][gr.pozycja[1] - 1].przedmiot:
                gr.dodaj_do_plecak()
        except:
            pass
        maps.mapa[gr.pozycja[0]][gr.pozycja[1] - 1] = gr
        stala_pozycja(gr, maps)
    else:
        sciana()


def d(gr, maps):
    if gr.pozycja[1] + 1 < len(maps.mapa) and maps.mapa[gr.pozycja[0]][gr.pozycja[1] + 1].otwarty:
        try:
            if maps.mapa[gr.pozycja[0] + 1][gr.pozycja[1] + 1].event:
                event(gr, maps)
            if maps.mapa[gr.pozycja[0]][gr.pozycja[1] + 1].przedmiot:
                gr.dodaj_do_plecak()
        except:
            pass
        maps.mapa[gr.pozycja[0]][gr.pozycja[1] + 1] = gr
        stala_pozycja(gr, maps)
    else:
        sciana()        
        
        
def rozpocznij_walke(gr):
    global status

    losuj_potwora = random.randint(1,5)
    if losuj_potwora == 1:
        potwor = uczestnicy.Potwor('Smok', 13, 30)
    elif losuj_potwora == 2:
        potwor = uczestnicy.Potwor('Niedzwiedz', 13, 30)
    elif losuj_potwora == 3:
        potwor = uczestnicy.Potwor('Gargulec', 13, 30)
    elif gr.zadania[3] == 1 and gr.zadania[4] == 1 and gr.zadania[5] == 0:
        potwor = uczestnicy.Potwor('Jezdziec', 6, 45)
    else:
        potwor = uczestnicy.Potwor('Demon', 13, 30)

    if podziemia.poziom_p > 1:
        potwor.pz = int(potwor.pz * podziemia.poziom_p * 0.8)
        potwor.pmax = int(potwor.pmax * podziemia.poziom_p  * 0.8)
        potwor.s = int(potwor.s * podziemia.poziom_p * 0.6)

    status = ''    
    

    while True:
        if gr.pz == 0:
            potwor.walka_gui(status, gr)
            print('ZOSTAŁES ZGŁADZONY.')
            getch()
            
            dlugosc_poziom = ((9 + len(gr.imie)) -19) * -1
            dlugosc_punkty = 33 - 9 - len(gr.imie) - dlugosc_poziom
            
            
            with open("score/high_score.txt", "a") as f:
                f.write("\n         " + gr.imie + (" " * dlugosc_poziom) + str(podziemia.poziom_p) + (" " * dlugosc_punkty) + str(gr.punkty))
            rysuj_obrazy.rysuj_animacja_ciag('animated/gameover/gameover.txt', 0.035)
            f.close()
            
            rysuj_obrazy.rysuj_score()
            print('\n\n\t\tRozpocznij nową grę?')
            print('\t\t1. Nowa gra\t2.Główne menu \t3. Zakończ grę')
            while True:
                d = input('\t\tTwój wybór?>')
                if d == '1':
                    from __main__ import nowa_gra
                    nowa_gra()
                elif d == '2':
                    from __main__ import menu_glowne
                    menu_glowne()
                elif d == '3':
                    sys.exit(0)
   
        potwor.walka_gui(status, gr)
        h = input('\n\nCo robisz?>')

        while True:
            if h == 'f':
                status = 'Atakujesz ' + str(potwor.imie) + ' za ' + str(gr.s) + ' obrażeń!'
                winsound.PlaySound('sound/gracz_atak.wav', winsound.SND_ASYNC)
                potwor.walka_gui(status, gr)
                getch()
                potwor.pz -= gr.s
                break
            elif h == 'j':
                b = random.randrange(1, 13)
                if b in range(1, 5):
                    print('UCIECZKA UDANA!')
                    getch()
                    return
                else:
                    print('NIE UDAŁO SIĘ UCIEC Z WALKI!')
                    getch()
                    break
            else:
                status = 'Chyba pomyliło Ci się coś?!'
                potwor.walka_gui(status, gr)
                h = input('\n\nCo robisz?>')

        if potwor.pz <= 0:
            winsound.PlaySound('sound/smok_smierc.wav', winsound.SND_ASYNC)
            print('ZWYCIĘSTWO!!!')
            if potwor.imie == "Jezdziec":
                ile_wygral = 135.0 * 1.45 * podziemia.poziom_p
                gr.zadania[5] = 1
            elif potwor.imie == "Gargulec" and gr.zadania[3] == 1 and gr.zadania[4] == 0:
                ile_wygral = 135.0 * 1.45 * podziemia.poziom_p
                if uczestnicy.gargulce > 1:
                    gr.zadania[5] = 1
                else:
                    uczestnicy.gargulce = uczestnicy.gargulce + 1
            else:
                ile_wygral = 100.0 * 1.25 * podziemia.poziom_p
                
            gr.zloto += ile_wygral
            print("Otrzymujesz ",ile_wygral, " złota.")
            gr.punkty += 5
            getch()
            return
        else:
            status = str(potwor.imie) + ' atakuje Cię za ' + str(potwor.s) + ' obrażen!'
            winsound.PlaySound('sound/smok_atak.wav', winsound.SND_ASYNC)
            gr.pz -= potwor.s
            if gr.pz <= 0:
                gr.pz = 0        

