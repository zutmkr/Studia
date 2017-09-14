
![Logo](https://github.com/zutmkr/Studia/blob/master/praca_inz/static/logo.PNG)

# (Beta v0.2):
###    *[TO DO]*:  
        + ulepszyć formatowanie itemów w plecaku na mapie gry       
        + tłumaczenia (Pl,En,De)                                  
        + nowa statystyka przedmiotów, gracza i potworów - pancerz  
        + rzadkie przedmioty zwiakszają pancerz gracza            
        + dodanie tłumaczeń i odblokowanie opcji JĘZYK            
###    [CODE]:
        + poprwawione kodowanie pliku (ang\PL\menu_glowne_instrukcje.txt)
        + dodano instrukcje zamykające plik w module rysuj_obrazy        
        + lekkie uporządkowanie kodu                                     
###    [NEW FEATURE]:  
        + odblokowana opcja O GRZE                                        

# (Beta v0.1b):
###    [EDITOR v0.03]:
        + poprawiono okienko WCZYTAJ                                     
        + naprawiono pomniejsze błędy                                    
###    [NEW FEATURE]:  
        + dodano informację o statusie aktualnego zadania                
        
# (Beta v0.1a):
###    [NEW FEATURE]:  
        + edytor podziemi v0.02                                          
        + dodano drugie zadanie dla Handlarza                            
        
# (Beta v0.020RC):
###    [CODE]:   
        + dodanie algorytmu wyszukiwania ścieżki  A*                     
        + mapa generuje się w trzech wariantach wielkości                      
###    [KNOWN BUGS]:
        + wybranie 'nowej gry' po ekranie śmierci przenosi do Głównego menu 
            ++ fixed (okazało się, że python wykorzystuje 'import __main__' w celu wykorzystania metod skryptu inicjalizującego)

# (Alpha v0.013):
###    [CODE]:  
        + błąd złapany przez wyjątek jest teraz zapisywany do pliku        
###    [NEW FEATURE]:                                                      
        + zadania i nagrody dla gracza                                      
            ++ info(Tylko 1 zadanie handlarza)   
        + tablica z iloscia zebranych punktow na koncu gry                 
        + mozliwosc nadania imienia swojej postaci                           
###    [KNOWN BUGS]:
        + tablica wyników nie wypisuje się na ekran po śmierci gracza    
        
# (Alpha v0.012):  
###    [QUALITY OF LIFE]:  
        + dodano nr wersji gry przy LOGO                                    
        + dodano mozliwosc powrotu do gl.m po ekranie game over             
        + gracz bedzie szybciej wiedzial czy sprzedaje/kupuje               
        + ulepszono formatowanie nazw przed. na ekranie handlu              
            ++ fixed(legendy zle sie wyswietlaja)  
        + legenda zdobyta na mapie (status) jest teraz opisana konkretniej  
###    [CODE]:  
        + zmodyfikowano balans walk                                         
        + poprawa ekranu GAME OVER                                          
        + okreslic statystyki przedmiotow                                   
        + zoptymalizować metodę Gracz.handel()                              
        + uzdrowiciel skaluje się z poziomem lochu                          
        + obrazenia zadawane przez potwory skaluja sie z poziomem lochu     
        + naprawiono resetowanie sie poziomu lochu po rozpoczeciu
        nowej gry przez gracza, z poziomu ekranu game over                  
        + usunieto znacznik kowala i handlarza z widoku mapy                
            ++ hotfix(usunąłem przez przypadek tez info o plecaku i postaci..)  
        + dodac statystyki do przedmiotow                                   
            ++ fixed(problem z przypisywaniem stringa +5 do nie legendarnych itemow, itemy z sprzedarzy kopiuja sie do pleacaka przy wyjsciu od handlarza)  

    
# (Alpha v0.011):  
    + główne menu gry                                                
    + nagroda (zloto) za  wygrane walki                              
    + opcja save game                                                
    + obsługa kodowania polskich znaków                              
    + zwiekszono obrazenia zadawane przez gracza do 15 na 1 poziomie 
    + zwiekszono szanse ucieczki do 25%                              
    + oprogramowano handel                                           
    + uzdrowiciel skaluje się z poziomiem                            
    + na ekranie postaci dodano wskażnik ilosći złota                
    
# (Alpha v0.010c):
    + dodano mozliwosc kupowania przedmiotow od handlarza oraz plynny wybor przedmiotów z listy
    + dodano mozliwosc spotkania handlarza i podstawowa interakcje z nim
    
# (Alpha v0.010b):
    + dodano mozliwosc zaczecia nowej gry po ekranie 'game over'
    + gracz otrzymuje juz tylko jeden przedmiot per pokoj 

# (Alpha v0.010a):
    + dodano trzech nowych przeciwnikow
    + dodano opis i znak kowala do interfejsu gracza (nie oprogramowano jeszcze ulepszania przedmiotow)
    + dodano znacznik zejscia poziom nizej w podziemiach
    + dodano opis i znak handlarza do interfejsu gracza (nie oprogramowano jeszcze handlu)
    + naprawiono blad przy uzyciu przycisku wyjscia z gry '`'
    
# (Alpha v0.010):
    + refaktoryzacja kodu
    + dodano dzwiek zdobycia legendarnego przedmiotu
    + zmieniono dzwiek ataku gracza i smierci przeciwnika na przyjemniejszy dla ucha

# (Alpha v0.09d):
    + zmiana algorytmu rysowania mapy. Mapa jest rysowana dopiero, gdy gracz odkrywa pola

# (Alpha v0.09c):
    + dodano dzwieki walki
    + poprawiono odkrywanie mapy na poziomach 2+
    
# (Alpha v0.09b):
    + dodano dynamiczne odkrywanie mapy
    
# (Alpha v0.09a):
    + dodano animacje smierci gracza
    
# (Alpha v0.09):
    + poprawiono wyswietlanie wartosci zycia potworow (maxPZ)
    + dodano skalowanie zycia potwora w zaleznosci od poziomu lochu
    + oprogramowano opcje ucieczki z walki (20% szans)
    + mozna wyjsc z gry znakiem '`' w widoku 'mapy'

# (Alpha v0.08):
    + gra konczy sie dopiero z smiercia gracza (infinite dyngeons, yay!)
    + dodano 'status bar' mowiacy co sie dzieje z postacia
    + dodano tryb walki
    + pokaz_staty -> pokaz karte postaci
    + eventy we wszystkich kierunkach
    + duzo zmian quality of life
    + gdy gracz znajdzie legendarny przedmiot ten na stale da mu +5 do sily
    + i masa innych rzeczy o ktorych nie pamietam...
                                 
# (Alpha v0.03):
	+ dodano linijke pytajaca, gdzie gracz ma sie udac
	+ zwiekszono czas wyswietlania informacji dla gracza do 1 sekundy (z 0.3s)

# (Alpha v0.02):
	+ dodano obsluge poruszania graczem bez potrzeby zaakceptowania
	  akcji przy uzyciu klawisza 'enter'
	+ dodano metode sleep() z biblioteki 'time', by ekran nie czyscil sie za szybko
	  wymazujac instrukcje zwrotna dla gracza

# (Alpha v0.01):
    + pierwsza grywalna wersja