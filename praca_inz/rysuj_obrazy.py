from time import sleep


def rysuj_animacja_ciag(adres, s):
    fp = open(adres)
    for i, line in enumerate(fp):
        print(line, end='')
        sleep(s)


def rysuj_logo():
    with open('static/LOGO.txt') as plik:
        print(plik.read())


def rysuj_potwora(adres):
    with open(adres) as plik:
        print(plik.read())        