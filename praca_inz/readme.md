

    ___                _   _           _         ___                                    
   /   \___  _ __ ___ | |_| |__  _   _( )__     /   \_   _ _ __   __ _  ___  ___  _ __  
  / /\ / _ \| '__/ _ \| __| '_ \| | | |/ __|   / /\ / | | | '_ \ / _` |/ _ \/ _ \| '_ \ 
 / /_// (_) | | | (_) | |_| | | | |_| |\__ \  / /_//| |_| | | | | (_| |  __/ (_) | | | |
/___,' \___/|_|  \___/ \__|_| |_|\__, ||___/ /___,'  \__,_|_| |_|\__, |\___|\___/|_| |_|
                                 |___/                           |___/                  

                                 
                                 
                                 
(Alpha v0.010b):
    - dodano mozliwosc zaczecia nowej gry po ekranie 'game over'
    - gracz otrzymuje juz tylko jeden przedmiot per pokoj 

(Alpha v0.010a):
    - dodano trzech nowych przeciwnikow
    - dodano opis i znak kowala do interfejsu gracza (nie oprogramowano jeszcze ulepszania przedmiotow)
    - dodano znacznik zejscia poziom nizej w podziemiach
    - dodano opis i znak handlarza do interfejsu gracza (nie oprogramowano jeszcze handlu)
    - naprawiono blad przy uzyciu przycisku wyjscia z gry '`'
    
(Alpha v0.010):
    - refaktoryzacja kodu
    - dodano dzwiek zdobycia legendarnego przedmiotu
    - zmieniono dzwiek ataku gracza i smierci przeciwnika na przyjemniejszy dla ucha

(Alpha v0.09d):
    - zmiana algorytmu rysowania mapy. Mapa jest rysowana dopiero, gdy gracz odkrywa pola

(Alpha v0.09c):
    - dodano dzwieki walki
    - poprawiono odkrywanie mapy na poziomach 2+
    
(Alpha v0.09b):
    - dodano dynamiczne odkrywanie mapy
    
(Alpha v0.09a):
    - dodano animacje smierci gracza
    
(Alpha v0.09):
    - poprawiono wyswietlanie wartosci zycia potworow (maxPZ)
    - dodano skalowanie zycia potwora w zaleznosci od poziomu lochu
    - oprogramowano opcje ucieczki z walki (20% szans)
    - mozna wyjsc z gry znakiem '`' w widoku 'mapy'

(Alpha v0.08):
    - gra konczy sie dopiero z smiercia gracza (infinite dyngeons, yay!)
    - dodano 'status bar' mowiacy co sie dzieje z postacia
    - dodano tryb walki
    - pokaz_staty -> pokaz karte postaci
    - eventy we wszystkich kierunkach
    - duzo zmian quality of life
    - gdy gracz znajdzie legendarny przedmiot ten na stale da mu +5 do sily
    - i masa innych rzeczy o ktorych nie pamietam...
                                 
(Alpha v0.03):
	- dodano linijke pytajaca, gdzie gracz ma sie udac
	- zwiekszono czas wyswietlania informacji dla gracza do 1 sekundy (z 0.3s)

(Alpha v0.02):
	- dodano obsluge poruszania graczem bez potrzeby zaakceptowania
	  akcji przy uzyciu klawisza 'enter'
	- dodano metode sleep() z biblioteki 'time', by ekran nie czyscil sie za szybko
	  wymazujac instrukcje zwrotna dla gracza

(Alpha v0.01):
    - pierwsza grywalna wersja