# -*- coding: utf-8 -*-

class Pole:
    def __init__(self,x,y,otwarty):
        self.x = x      #wiersz
        self.y = y      #kolumna
        self.g = 0
        self.h = 0
        self.suma = 0
        self.otwarty = otwarty
        self.aktualny = False
        