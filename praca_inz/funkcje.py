import random
import winsound
import os
import sys
import pickle
from msvcrt import getch
from time import sleep

import pokoj
import uczestnicy
import podziemia
import rysuj_obrazy


prawda_falsz = [True, False]
status = ''
PIK = "save/objects.bj"



def sciana():
    global status
    status = 'Nie możesz tam iść, to ściana.'
    
def zapisz_gre(gr,maps):
    data = [gr,maps,podziemia.poziom_p,gr.lista]
    
    with open(PIK, "wb") as f:
        pickle.dump(len(data), f)
        for value in data:
            pickle.dump(value, f)

def event(gr, maps):
    barter = uczestnicy.Handlarz()

    p = random.randint(0,3)
    #p = 1
    if p == 0:    
        uczestnicy.Uzdrowiciel(gr)
    elif p == 1:
        barter.handel(gr)
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
    else:
        potwor = uczestnicy.Potwor('Demon', 13, 30)

    if podziemia.poziom_p > 1:
        potwor.pz *= podziemia.poziom_p * 0.8
        potwor.pmax *= podziemia.poziom_p * 0.8
        potwor.pz = int(potwor.pz)
        potwor.pmax = int(potwor.pmax)

    status = ''

    while True:
        if gr.pz == 0:
            print('ZOSTAŁES ZGŁADZONY.')
            getch()
            rysuj_obrazy.rysuj_animacja_ciag('animated/gameover/gameover.txt', 0.035)

            print('\t\tRozpocznij nową grę?')
            print('\t\t1. Nowa gra\t2. Zakończ grę')
            if input() == '1':
                status = ''
                nowa_gra()
            else:
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
            print('Otrzymujesz 1000 XP')
            getch()
            return
        else:
            status = str(potwor.imie) + ' atakuje Cię za ' + str(potwor.s) + ' obrażen!'
            winsound.PlaySound('sound/smok_atak.wav', winsound.SND_ASYNC)
            gr.pz -= potwor.s
            if gr.pz <= 0:
                gr.pz = 0        


def nowa_gra():
    gr = uczestnicy.Gracz()

    maps = podziemia.Mapa()
    
    maps.mapa[0][0] = gr
    
    maps.przygotuj_mape()
    gr.pobierz_pozycje(maps)
    widocznosc(gr, maps)
    maps.rysuj_mape()
    poruszanie_po_mapie(gr, maps)