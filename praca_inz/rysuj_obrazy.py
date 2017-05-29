from time import sleep
from itertools import islice


def rysuj_animacja_ciag(adres, s):
    fp = open(adres)
    for i, line in enumerate(fp):
        print(line, end='')
        sleep(s)

def rysuj_score():
    with open("score/high_score.txt") as plik:
        print(plik.read())
    getch()

def rysuj_logo():
    with open("static/LOGO.txt") as plik:
        print(plik.read())


def rysuj_potwora(adres):
    with open(adres) as plik:
        print(plik.read())

def rysuj(adres):
    with open(adres) as plik:
        print(plik.read())        
        
def rysuj_gl_menu(adres,od,do):
    with open(adres) as plik:
        lines = islice(plik, od, do)
        for line in lines:
            print(line)

def rysuj_zadanie(adres,od,do):
    with open(adres) as plik:
        lines = islice(plik, od, do)
        for line in lines:
            print(line)   