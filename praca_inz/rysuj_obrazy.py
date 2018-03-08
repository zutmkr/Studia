# -*- coding: utf-8 -*-
import logging
from time import sleep
from itertools import islice
from msvcrt import getch


logging.basicConfig(filename='error_logs/errors.log', level=logging.DEBUG, format='%(asctime)s %(levelname)s %(name)s %(message)s')
logger=logging.getLogger(__name__)


def rysuj_animacja_ciag(adres, s):
    try:
        fp = open(adres, encoding="utf8")
        for i, line in enumerate(fp):
            print(line, end='')
            sleep(s)
    except Exception as e:
        logger.error(e)             
    fp.close()
      
    
def rysuj(adres):
    try:
        with open(adres, encoding="utf8") as plik:
            print(plik.read())   
    except Exception as e:
        logger.error(e)        
    plik.close()    
        
        
def rysuj_oddo(adres,od,do):
    try:
        with open(adres, encoding="utf8") as plik:
            lines = islice(plik, od, do)
            for line in lines:
                print(line)
    except Exception as e:
        logger.error(e)             
    plik.close() 
    