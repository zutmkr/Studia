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
    zloto = 0

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

        
class Handlarz(Gracz):

    lista = []
    zloto = 500
    
    def rysuj_handel(self,gr):
            os.system('cls')  # czyszczenie ekranu
            rysuj_obrazy.rysuj_potwora('static/handl.txt')
            print('\t\tSpotykasz Handlarza!!!\n')
            print('>W czym moge pomoc?\n\t\t\t Handlarz posiada ', self.zloto, ' sztuk zlota\n')
            print('\t1) Pokaz mi swoje towary. (kupuj)')
            print('\t2) Zobacz co mam. (sprzedawaj)')
            print('\t0) Zegnam.\t\t Twoje zloto: ',gr.zloto)
    
    def handel(self,gr):
        wyb = '9'
        
        self.dodaj_do_plecak()
        self.dodaj_do_plecak()
        self.dodaj_do_plecak()
            
        while wyb != '0':

            self.rysuj_handel(gr)
            wyb = input('\nTwoj wybor: ')
            s = 0
            
            if wyb == '1':
                if not self.lista:
                    print('(Handlarz): Nie mam przy sobie zadnych towarow...')
                    getch()
                inp = ''
                while inp != '8':
                    if not self.lista:
                        break

                    for Przedmiot in self.lista:
                        Przedmiot.nazwa = Przedmiot.nazwa.lstrip()
                        Przedmiot.nazwa = Przedmiot.nazwa.lstrip('-> ')
                    
                    for Przedmiot in self.lista:
                        Przedmiot.nazwa = '   ' + Przedmiot.nazwa
                    
                    self.lista[s].nazwa = self.lista[s].nazwa.lstrip()
                    self.lista[s].nazwa = '-> ' + self.lista[s].nazwa
                    
                    os.system('cls')  # czyszczenie ekranu
                    print('Wybierz co Cie interesuje:')
                    print('\t\t\t\t\t\tINSTRUKCJE')
                    print('\t\t\t\t\t\t\tw - strzalka w gore')
                    print('\t\t\t\t\t\t\ts - strzalka w dol')
                    print('\t\t\t\t\t\t\tk - kup przedmiot')
                    print('\t\t\t\t\t\t\t8 - wroc do rozmowy z handlarzem')
                    print('\t\tTwoje zloto:', gr.zloto, ' zlota\n')
                    for Przedmiot in self.lista:
                        print('\t',Przedmiot.nazwa,'\t(', Przedmiot.wartosc, ' zlota)')
                        
                    inp = getch().decode("utf-8")
                    if inp == 'w':
                        s-=1
                        try:
                            if s < 0 : 
                                s = 0
                                self.lista[s+1].nazwa = self.lista[s+1].nazwa.lstrip()
                                self.lista[s+1].nazwa = self.lista[s+1].nazwa.lstrip('-> ')
                                self.lista[s+1].nazwa = '   ' + self.lista[s+1].nazwa
                                self.lista[s].nazwa = self.lista[s].nazwa.lstrip()
                                self.lista[s].nazwa = self.lista[s].nazwa.lstrip('-> ')
                                self.lista[s].nazwa = '-> ' + self.lista[s].nazwa
                            else:
                                self.lista[s+1].nazwa = self.lista[s+1].nazwa.lstrip()
                                self.lista[s+1].nazwa = self.lista[s+1].nazwa.lstrip('-> ')
                                self.lista[s+1].nazwa = '   ' + self.lista[s+1].nazwa
                                self.lista[s].nazwa = self.lista[s].nazwa.lstrip()
                                self.lista[s].nazwa = self.lista[s].nazwa.lstrip('-> ')
                                self.lista[s].nazwa = '-> ' + self.lista[s].nazwa
                        except:
                            pass
                    elif inp == 's':
                        s+=1
                        try:
                            if s > len(self.lista)-1:
                                s = len(self.lista)-1
                                self.lista[s-1].nazwa = self.lista[s-1].nazwa.lstrip()
                                self.lista[s-1].nazwa = self.lista[s-1].nazwa.lstrip('-> ')
                                self.lista[s-1].nazwa = '   ' + self.lista[s-1].nazwa
                                self.lista[s].nazwa = self.lista[s].nazwa.lstrip()
                                self.lista[s].nazwa = self.lista[s].nazwa.lstrip('-> ')
                                self.lista[s].nazwa = '-> ' + self.lista[s].nazwa
                            else:  
                                self.lista[s-1].nazwa = self.lista[s-1].nazwa.lstrip()
                                self.lista[s-1].nazwa = self.lista[s-1].nazwa.lstrip('-> ')
                                self.lista[s-1].nazwa = '   ' + self.lista[s-1].nazwa
                                self.lista[s].nazwa = self.lista[s].nazwa.lstrip()
                                self.lista[s].nazwa = self.lista[s].nazwa.lstrip('-> ')
                                self.lista[s].nazwa = '-> ' + self.lista[s].nazwa
                        except:
                            pass
                    elif inp == 'k':
                        for Przedmiot in self.lista:
                            if not Przedmiot.nazwa.find('-> '):
                                Przedmiot.nazwa = Przedmiot.nazwa.lstrip('-> ')
                                gr.lista.append(Przedmiot)
                                self.lista.remove(Przedmiot)
                                s = 0
                                
            elif wyb == '2':
                gr.pokaz_plecak()
                getch()
            
        
        
        
        
