
![Logo](https://github.com/zutmkr/Studia/blob/master/praca_inz/static/logo.PNG)

NOTE! This code is final... development has moved [here.](https://github.com/zutmkr/Studia/tree/master/praca_mag "Dorothy's Dungeon 2")
# (Beta v0.2.1.180308):
### [CODE + HOTFIX]:
        + naprawiono błąd uniemożliwiający uruchomienie gry (brakujący plik)
        + poprawiono niektóre teksty w grze
        + poprawiono metody odpowiedzialne za rysowanie obrazów
        + nowy wygląd Gargulców

# (Beta v0.2):
### [CODE]:
        + poprawione kodowanie pliku (ang\PL\menu_glowne_instrukcje.txt)
        + dodano instrukcje zamykające plik w module rysuj_obrazy
        + lekkie uporządkowanie kodu
### [NEW FEATURE]:
        + odblokowana opcja O GRZE

# (Beta v0.1b):
### [EDITOR v0.03]:
        + poprawiono okienko WCZYTAJ
        + naprawiono pomniejsze błędy
### [NEW FEATURE]:
        + dodano informację o statusie aktualnego zadania

# (Beta v0.1a):
### [NEW FEATURE]:
        + edytor podziemi v0.02
        + dodano drugie zadanie dla Handlarza

# (Beta v0.020RC):
### [CODE]:
        + dodanie algorytmu wyszukiwania ścieżki A*
        + mapa generuje się w trzech wariantach wielkości
### [KNOWN BUGS]:
        + wybranie 'nowej gry' po ekranie śmierci przenosi do Głównego menu
         ++ fixed (okazało się, że python wykorzystuje 'import __main__' w celu wykorzystania metod skryptu inicjalizującego)

# (Alpha v0.013):
### [CODE]:
        + błąd złapany przez wyjątek jest teraz zapisywany do pliku
### [NEW FEATURE]:
        + zadania i nagrody dla gracza
         ++ info(Tylko 1 zadanie handlarza)
        + tablica z ilością zebranych punktów na końcu gry
        + możliwość nadania imienia swojej postaci
### [KNOWN BUGS]:
        + tablica wyników nie wypisuje się na ekran po śmierci gracza

# (Alpha v0.012):
### [QUALITY OF LIFE]:
        + dodano nr wersji gry przy LOGO
        + dodano możliwość powrotu do gl.m po ekranie game over
        + gracz będzie szybciej wiedział czy sprzedaje/kupuje
        + ulepszono formatowanie nazw przedmiotów na ekranie handlu
         ++ fixed(legendy źle się wyświetlają)
        + legenda zdobyta na mapie (status) jest teraz opisana konkretniej
### [CODE]:
        + zmodyfikowano balans walk
        + poprawa ekranu GAME OVER
        + określić statystyki przedmiotów
        + zoptymalizować metodę Gracz.handel()
        + uzdrowiciel skaluje się z poziomem lochu
        + obrażenia zadawane przez potwory skalują się z poziomem lochu
        + naprawiono resetowanie się poziomu lochu po rozpoczęciu nowej gry przez gracza, z poziomu ekranu game over
        + usunięto znacznik kowala i handlarza z widoku mapy
         ++ hotfix(usunąłem przez przypadek tez info o plecaku i postaci..)
        + dodać statystyki do przedmiotów
         ++ fixed(problem z przypisywaniem stringa +5 do nie legendarnych itemow, itemy z sprzedaży kopiują się do plecaka przy wyjściu od handlarza)

# (Alpha v0.011):
        + główne menu gry
        + nagroda (zloto) za wygrane walki
        + opcja save game
        + obsługa kodowania polskich znaków
        + zwiększono obrażenia zadawane przez gracza do 15 na 1 poziomie
        + zwiększono szanse ucieczki do 25%
        + oprogramowano handel
        + uzdrowiciel skaluje się z poziomem
        + na ekranie postaci dodano wskaźnik ilości złota

# (Alpha v0.010c):
        + dodano możliwość kupowania przedmiotów od handlarza oraz płynny wybór przedmiotów z listy
        + dodano możliwość spotkania handlarza i podstawowa interakcje z nim

# (Alpha v0.010b):
        + dodano możliwość zaczęcia nowej gry po ekranie 'game over'
        + gracz otrzymuje już tylko jeden przedmiot per pokój

# (Alpha v0.010a):
        + dodano trzech nowych przeciwników
        + dodano opis i znak kowala do interfejsu gracza (nie oprogramowano jeszcze ulepszania przedmiotów)
        + dodano znacznik zejścia poziom niżej w podziemiach
        + dodano opis i znak handlarza do interfejsu gracza (nie oprogramowano jeszcze handlu)
        + naprawiono błąd przy użyciu przycisku wyjścia z gry

# (Alpha v0.010):
        + refaktoryzacja kodu
        + dodano dźwięk zdobycia legendarnego przedmiotu
        + zmieniono dźwięk ataku gracza i śmierci przeciwnika na przyjemniejszy dla ucha

# (Alpha v0.09d):
        + zmiana algorytmu rysowania mapy. Mapa jest rysowana dopiero, gdy gracz odkrywa pola

# (Alpha v0.09c):
        + dodano dźwięki walki
        + poprawiono odkrywanie mapy na poziomach 2+

# (Alpha v0.09b):
        + dodano dynamiczne odkrywanie mapy

# (Alpha v0.09a):
        + dodano animacje śmierci gracza

# (Alpha v0.09):
        + poprawiono wyświetlanie wartości życia potworów (maxPZ)
        + dodano skalowanie życia potwora w zależności od poziomu lochu
        + oprogramowano opcje ucieczki z walki (20% szans)
        + można wyjść z gry znakiem "`" w widoku 'mapy'

# (Alpha v0.08):
        + gra kończy się dopiero z śmiercią gracza (infinite dyngeons, yay!)
        + dodano 'status bar' mówiący co się dzieje z postacią
        + dodano tryb walki
        + pokaz_staty -> pokaz kartę postaci
        + eventy we wszystkich kierunkach
        + dużo zmian quality of life
        + gdy gracz znajdzie legendarny przedmiot ten na stałe da mu +5 do siły
        + i masa innych rzeczy o których nie pamiętam...

# (Alpha v0.03):
        + dodano linijkę pytająca, gdzie gracz ma się udać
        + zwiększono czas wyświetlania informacji dla gracza do 1 sekundy (z 0.3s)

# (Alpha v0.02):
        + dodano obsługę poruszania graczem bez potrzeby zaakceptowania akcji przy użyciu klawisza 'enter'
        + dodano metodę sleep() z biblioteki 'time', by ekran nie czyścił się za szybko wymazując instrukcje zwrotna dla gracza

# (Alpha v0.01):
        + pierwsza grywalna wersja
