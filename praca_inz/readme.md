# (Alpha v0.013):IN WORK 
###    [Quality of life]:  
        + ulepszyc formatowanie itemow w plecaku na mapie gry               - ...  
        + tłumaczenia (Pl,En,De)                                            - ...  
###    [CODE]:  
        + nowa statystyka przedmiotow, gracza i potworow - pancerz          - ...  
        + rzadkie przedmioty zwiakszaja pancerz gracza                      - ...  
###    [NEW FEATURE]:  
        + łądnijesze menu gry oraz odblokowana opcja EXTRA                  - partially implemented (Brakuje OPCJI oraz O GRZE) 
        + edytor podziemi                                                   - partially implemented (Buttony jeszcze nie działają) 
        + zadania i nagrody dla gracza                                      - partially implemented (Tylko 1 zadanie handlarza)  
        + tablica z iloscia zebranych punktow na koncu gry                  - partially implemented (wszystko działa, ale tablica się nie wypisuje na erkan przy śmierci gracza)  
        + mozliwosc nadania imienia swojej postaci                          - done  

# (Alpha v0.012):  
###    [Quality of life]:  
        + dodano nr wersji gry przy LOGO                                    - done  
        + dodano mozliwosc powrotu do gl.m po ekranie game over             - done  
        + gracz bedzie szybciej wiedzial czy sprzedaje/kupuje               - done  
        + ulepszono formatowanie nazw przed. na ekranie handlu              - done + fixed(legendy zle sie wyswietlaja)  
        + legenda zdobyta na mapie (status) jest teraz opisana konkretniej  - done  
###    [CODE]:  
        + zmodyfikowano balans walk                                         - done  
        + poprawa ekranu GAME OVER                                          - done  
        + okreslic statystyki przedmiotow                                   - done  
        + zoptymalizować metodę Gracz.handel()                              - done  
        + uzdrowiciel skaluje się z poziomem lochu                          - done  
        + obrazenia zadawane przez potwory skaluja sie z poziomem lochu     - done  
        + naprawiono resetowanie sie poziomu lochu po rozpoczeciu
        nowej gry przez gracza, z poziomu ekranu game over                  - done  
        + usunieto znacznik kowala i handlarza z widoku mapy                - done + hotfix(usunąłem przez przypadek tez info o plecaku i postaci..)  
        + dodac statystyki do przedmiotow                                   - done + fixed(problem z przypisywaniem stringa +5 do nie legendarnych itemow, itemy z sprzedarzy kopiuja sie do pleacaka przy wyjsciu od handlarza)  

    
# (Alpha v0.011):  
    + główne menu gry                                                   - done  
    + nagroda (zloto) za  wygrane walki                                 - done  
    + opcja save game                                                   - done  
    + obsługa kodowania polskich znaków                                 - done  
    + zwiekszono obrazenia zadawane przez gracza do 15 na 1 poziomie    - done  
    + zwiekszono szanse ucieczki do 25%                                 - done  
    + oprogramowano handel                                              - done  
    + uzdrowiciel skaluje się z poziomiem                               - done  
    + na ekranie postaci dodano wskażnik ilosći złota                   - done  
    
(Alpha v0.010c):
    - dodano mozliwosc kupowania przedmiotow od handlarza oraz plynny wybor przedmiotów z listy
    - dodano mozliwosc spotkania handlarza i podstawowa interakcje z nim
    
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