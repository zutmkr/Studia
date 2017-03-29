import podziemia
import uczestnicy
import funkcje
import os

os.system('mode con: cols=115 lines=62')


gr = uczestnicy.Gracz()

maps = podziemia.Mapa()

maps.mapa[0][0] = gr

maps.przygotuj_mape()
gr.pobierz_pozycje(maps)
funkcje.widocznosc(gr, maps)
maps.rysuj_mape()
funkcje.poruszanie_po_mapie(gr, maps)
