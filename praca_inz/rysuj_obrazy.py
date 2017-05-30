from time import sleep
from itertools import islice
from msvcrt import getch

import logging
logging.basicConfig(filename='error_logs/errors.log', level=logging.DEBUG, format='%(asctime)s %(levelname)s %(name)s %(message)s')
logger=logging.getLogger(__name__)


def rysuj_animacja_ciag(adres, s):
    fp = open(adres)
    for i, line in enumerate(fp):
        print(line, end='')
        sleep(s)

def rysuj_score():
    try:
        with open("score/high_score.txt", encoding="utf8") as plik:
            print(plik.read())
    except Exception as e:
        logger.error(e)

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
            