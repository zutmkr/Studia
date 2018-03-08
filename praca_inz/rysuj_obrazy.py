# -*- coding: utf-8 -*-
import logging
from time import sleep
from itertools import islice
from msvcrt import getch


logging.basicConfig(filename='error_logs/errors.log', level=logging.DEBUG, format='%(asctime)s %(levelname)s %(name)s %(message)s')
logger=logging.getLogger(__name__)


def rysuj_animacja_ciag(adres, s):
    fp = open(adres, encoding="utf8")
    for i, line in enumerate(fp):
        print(line, end='')
        sleep(s)
    fp.close()
    
    
def rysuj_score():
    try:
        with open("score/high_score.txt", encoding="utf8") as plik:
            print(plik.read())
    except Exception as e:
        logger.error(e)
    plik.close()
    

def rysuj_logo():
    with open("static/LOGO.txt", encoding="utf8") as plik:
        print(plik.read())
    plik.close()
        
        
def rysuj_potwora(adres):
    with open(adres, encoding="utf8") as plik:
        print(plik.read())
    plik.close()
    
    
def rysuj(adres):
    with open(adres, encoding="utf8") as plik:
        print(plik.read())        
    plik.close()    
        
        
def rysuj_gl_menu(adres,od,do):
    with open(adres, encoding="utf8") as plik:
        lines = islice(plik, od, do)
        for line in lines:
            print(line)
    plik.close()
    
    
def rysuj_zadanie(adres,od,do):
    with open(adres, encoding="utf8") as plik:
        lines = islice(plik, od, do)
        for line in lines:
            print(line)   
    plik.close()    
    