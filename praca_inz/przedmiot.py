import random
import podziemia

stuff = ['miecz', 'zbroja', 'potion', 'buty', 'kusza', 'tiara', 'pierscien', 'amulet', 'tarcza', 'pas', 'rekawice',
         'pet']
dobry_prefix = ['dobre', 'magiczne', 'rzadkie', 'legendarne']
zly_prefix = ['zwykle', 'zepsute', 'zardzewiale', 'przeklete']


class Przedmiot:
    def __init__(self):
        self.nazwa = random.choice(stuff)
        self.wartosc = 50.0


class Wartosciowy:
    def dodaj_przedmiot(self):
        y = Przedmiot()
        p = random.choice(dobry_prefix)
        y.nazwa = p + ' ' + y.nazwa
        
        if p == 'dobre':
            y.wartosc = (y.wartosc * 1.25) * podziemia.poziom_p
        elif p == 'magiczne':
            y.wartosc = (y.wartosc * 1.5) * podziemia.poziom_p
        elif p == 'rzadkie':
            y.wartosc = (y.wartosc * 1.75) * podziemia.poziom_p
        elif p == 'legendarne':
            y.wartosc = (y.wartosc * 2) * podziemia.poziom_p
        return y


class Smiec:
    def dodaj_przedmiot(self):
        y = Przedmiot()
        p = random.choice(zly_prefix)
        y.nazwa = p + ' ' + y.nazwa
        
        if p == 'zwykle':
            y.wartosc = y.wartosc * podziemia.poziom_p
        elif p == 'zepsute':
            y.wartosc = (y.wartosc * 0.75) * podziemia.poziom_p
        elif p == 'zardzewiale':
            y.wartosc = (y.wartosc * 0.5) * podziemia.poziom_p
        elif p == 'przeklete':
            y.wartosc = (y.wartosc * 0.25) * podziemia.poziom_p
        
        return y
