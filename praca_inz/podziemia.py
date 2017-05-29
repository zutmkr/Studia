
import random
import os

import rysuj_obrazy
import pokoj
import funkcje


# rodzaj_mapy = [[0,0,0], [0,0,0,0,0], [0,0,0,0,0,0,0]]
rodzaj_mapy = [[0, 0, 0, 0, 0, 0, 0]]
prawda_falsz = [True, False]
poziom_p = 1


class Mapa():
    def __init__(self):
        # tworzenie mapy gry
        wielkosc_mapy = random.choice(rodzaj_mapy)
        self.mapa = []  # ATR: MAPA
        for i in range(len(wielkosc_mapy)): self.mapa.append(wielkosc_mapy[:])
        print(len(wielkosc_mapy))
        self.lista_pokoi = [pokoj.Pokoj() for i in range(len(wielkosc_mapy) ** 2)]  # ATR: LISTA_POKOI
        k = 0
        for i in range(len(wielkosc_mapy)):
            for j in range(len(wielkosc_mapy)):
                self.mapa[i][j] = self.lista_pokoi[k]
                if random.choice(prawda_falsz):
                    self.mapa[i][j].otwarty = True
                    if random.choice(prawda_falsz):
                        self.mapa[i][j].event = True
                else:
                    self.mapa[i][j].otwarty = False
                k += 1

    def przygotuj_mape(self):
        if len(self.mapa[0]) == 3:
            self.mapa[1][0].otwarty = True
            self.mapa[1][1].otwarty = True
            self.mapa[1][2].otwarty = True
            self.mapa[2][2].otwarty = True
        elif len(self.mapa[0]) == 5:
            self.mapa[1][0].otwarty = True
            self.mapa[1][1].otwarty = True
            self.mapa[1][2].otwarty = True
            self.mapa[2][2].otwarty = True
            self.mapa[2][3].otwarty = True
            self.mapa[3][3].otwarty = True
            self.mapa[3][4].otwarty = True
            self.mapa[4][4].otwarty = True
        elif len(self.mapa[0]) == 7:
            self.mapa[1][0].otwarty = True
            self.mapa[1][1].otwarty = True
            self.mapa[2][1].otwarty = True
            self.mapa[3][1].otwarty = True
            self.mapa[3][2].otwarty = True
            self.mapa[4][2].otwarty = True
            self.mapa[5][2].otwarty = True
            self.mapa[2][2].otwarty = True
            self.mapa[2][3].otwarty = True
            self.mapa[2][4].otwarty = True
            self.mapa[3][4].otwarty = True
            self.mapa[5][3].otwarty = True
            self.mapa[6][3].otwarty = True
            self.mapa[6][4].otwarty = True
            self.mapa[6][5].otwarty = True
            self.mapa[6][6].otwarty = True

    def rysuj_mape(self):
        global poziom_p
        os.system('cls')  # czyszczenie ekranu
        rysuj_obrazy.rysuj_logo()
        print('\t\t\tPOZIOM PODZIEMIA: ', poziom_p, '\n')

        for i in range(len(self.mapa[0])):
            for j in range(len(self.mapa[0])):
                try:
                    if self.mapa[i][j].otwarty and self.mapa[i][j].widoczny:
                        if i == len(self.mapa[0])-1 and j == len(self.mapa[0])-1:
                            print('X')
                        elif j == len(self.mapa[0]) - 1:
                            print('_')
                        else:
                            if j == 0:
                                print('\t\t\t_', end='')
                            else:
                                print('_', end='')
                    elif not self.mapa[i][j].otwarty and self.mapa[i][j].widoczny:
                        if j == len(self.mapa[0]) - 1:
                            print('#')
                        else:
                            if j == 0:
                                print('\t\t\t#', end='')
                            else:
                                print('#', end='')
                    else:
                        if j == len(self.mapa[0]) - 1:
                            print(' ')
                        else:
                            if j == 0:
                                print('\t\t\t ', end='')
                            else:
                                print(' ', end='')
                except:
                    if j == len(self.mapa[0]) - 1:
                        print('8')
                    else:
                        if j == 0:
                            print('\t\t\t8', end='')
                        else:
                            print('8', end='')

        print('\t\t\t\t\t\tINSTRUKCJE')
        print('\t\t\t\t\t\t\t8 - GRACZ\t\tw - ruch w górę')
        print('\t\t\t\t\t\t\t_ - OTWARTY POKÓJ\ts - ruch w dół')
        print('\t\t\t\t\t\t\t# - ZAMKNIĘTY POKÓJ\ta - ruch w lewo')
        print('\t\t\t\t\t\t\tX - ZEJŚCIE\t\td - ruch w prawo')
        print('\t\t\t\t\t\t\t\t\tc - pokaż kartę postaci i questy')
        print('\t\t\t\t\t\t\t\t\ti - pokaż plecak')
        print('\n\t\t\t\t\t\t\t\t\t\t` - wyjście z gry (zapisuje grę)')

    def stworz_nowa_mape(self,gr):
        if gr.pozycja[0] == len(self.mapa) - 1 and gr.pozycja[1] == len(self.mapa) - 1:
            global poziom_p
            poziom_p += 1
            self = Mapa()
        
            self.mapa[0][0] = gr
        
            self.przygotuj_mape()
            gr.pobierz_pozycje(self)
            funkcje.widocznosc(gr, self)
            self.rysuj_mape()
        
            funkcje.poruszanie_po_mapie(gr, self)