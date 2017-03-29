import random

stuff = ['miecz', 'zbroja', 'potion', 'buty', 'kusza', 'tiara', 'pierscien', 'amulet', 'tarcza', 'pas', 'rekawice',
         'pet']
dobry_prefix = ['dobre', 'magiczne', 'legendarne', 'rzadkie']
zly_prefix = ['znoszone', 'przeklete', 'zepsute', 'nawiedzone']


class Przedmiot:
    def __init__(self):
        self.nazwa = random.choice(stuff)


class Wartosciowy:
    def dodaj_przedmiot(self):
        y = Przedmiot()
        y.nazwa = random.choice(dobry_prefix) + ' ' + y.nazwa
        return y


class Smiec:
    def dodaj_przedmiot(self):
        y = Przedmiot()
        y.nazwa = random.choice(zly_prefix) + ' ' + y.nazwa
        return y
