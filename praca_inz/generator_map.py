import os, os.path
import random
import uczestnicy
from tkinter import *
from tkinter import messagebox
from tkinter import ttk
from datetime import datetime
from podziemia import Mapa
from tkinter import filedialog
poziom_pgen = 1
mapsgen = 0

def licz_pliki(adres):
    ile = 0
    for f in os.listdir(adres):
        if os.path.isfile(os.path.join(adres, f)):
            ile += 1
    return ile


def wyjdz(okno):
    global mapsgen
    mapsgen = 0
    okno.destroy()


def wczytaj_mape(mapa_odkryta):
    d = filedialog.askopenfilename() 
    f = open(d, 'r', encoding="utf8")
    mapa_odkryta.delete(1.0, END)
    mapa_odkryta.insert(END, f.read())
    f.close()


def zapisz_mape(mapa_odkryta):
    adres = './mapy'
    a = (str(datetime.now())).split()
    f = open('mapy/' + a[0]+ '_' + str(licz_pliki(adres)) + '.map', 'w', encoding="utf8")
    f.write(mapa_odkryta.get("1.0", "end-1c"))
    f.close()


def zagraj(poziom_pgen, wielkosc_mapygen, punkty_zycia, sila, okno):
    global mapsgen
    if mapsgen == 0:
        messagebox.showinfo("BŁĄD", "Wygeneruj wpierw mapę, by w nią zagrać!")
    else:    
        okno.destroy()
        from __main__ import nowa_gra
        nowa_gra(poziom_pgen, wielkosc_mapygen, punkty_zycia, sila)

        
def generator():
    def losuj():
        if wcisniety.get() == 1:    
            s.config(state="disabled")

            s1.config(state="disabled")

            pz.config(state="disabled")
            
            ps.config(state="disabled")
        else:
            s['values'] = (1, 2, 3, 4, 5, 6, 7, 8, 9)
            s.config(state="readonly")

            s1['values'] = (7, 9, 11)
            s1.config(state="readonly")

            pz['values'] = (39, 60, 100)
            pz.config(state="readonly")
            
            ps['values'] = (15, 30, 50)
            ps.config(state="readonly")

    def generuj_mape():
        global mapsgen
        if wcisniety.get() == 1:
            s.set(random.randint(1, 9))
            
            s1.set(random.choice([7, 9, 11]))
            
            pz.set(random.choice([39, 60, 100]))
            
            ps.set(random.choice([15, 30, 50]))


        gr = uczestnicy.Gracz()
        mapa_odkryta.delete(1.0, END)
        maps = Mapa(wielkosc_mapygen)
        maps.przygotuj_mape(wielkosc_mapygen)
        mapsgen = maps
        maps.mapa[0][0] = gr
    
        for i in range(len(maps.mapa[0])):
            for j in range(len(maps.mapa[0])):
                try:
                    if maps.mapa[i][j].otwarty:
                        if i == len(maps.mapa[0]) - 1 and j == len(maps.mapa[0]) - 1:
                            mapa_odkryta.insert(END, 'X\n')
                        elif j == len(maps.mapa[0]) - 1:
                            mapa_odkryta.insert(END, '_\n')
                        else:
                            if j == 0:
                                mapa_odkryta.insert(END, '_')
                            else:
                                mapa_odkryta.insert(END, '_')
                    elif not maps.mapa[i][j].otwarty:
                        if j == len(maps.mapa[0]) - 1:
                            mapa_odkryta.insert(END, '#\n')
                        else:
                            if j == 0:
                                mapa_odkryta.insert(END, '#')
                            else:
                                mapa_odkryta.insert(END, '#')
                    else:
                        if j == len(maps.mapa[0]) - 1:
                            mapa_odkryta.insert(END, ' \n')
                        else:
                            if j == 0:
                                mapa_odkryta.insert(END, ' ')
                            else:
                                mapa_odkryta.insert(END, ' ')
                except:
                    if j == len(maps.mapa[0]) - 1:
                        mapa_odkryta.insert(END, '8\n')
                    else:
                        if j == 0:
                            mapa_odkryta.insert(END, '8')
                        else:
                            mapa_odkryta.insert(END, '8')            
                   
    okno = Tk()
    global poziom_pgen

    okno.title('Dorothy\'s Dungeon Map Generator v0.03')
    okno.geometry("630x500")

    f = LabelFrame(okno, text='WYGENEROWANA MAPA', labelanchor='n')
    f.grid(columnspan=3, row=0)

    f2 = LabelFrame(okno, text='OPCJE PODZIEMI', labelanchor='n')
    f2.grid(column=6, row=0)

    w = Label(f2, text="Poziom podziemi  ")
    w.grid(column=1, row=2)

    wcisniety = IntVar()
    wcisniety.set(0)
    c = Checkbutton(okno, text='Losuj wszystkie parametry', variable=wcisniety, command=losuj)
    c.grid(column=6, row=3)

    poziom_pgen = IntVar()
    poziom_pgen.set(1)
    s = ttk.Combobox(f2, width=7, textvariable=poziom_pgen, state="readonly")
    s['values'] = (1, 2, 3, 4, 5, 6, 7, 8, 9)
    s.grid(column=2, row=2)

    w1 = Label(f2, text="Wielkość mapy  ")
    w1.grid(column=1, row=3)

    wielkosc_mapygen = IntVar()
    wielkosc_mapygen.set(7)
    s1 = ttk.Combobox(f2, width=7, textvariable=wielkosc_mapygen, state='readonly')
    s1['values'] = (7, 9, 11)
    s1.grid(column=2, row=3)

    w2 = Label(f2, text="Punkty życia Gracza  ")
    w2.grid(column=1, row=4)

    punkty_zycia = IntVar()
    punkty_zycia.set(39)
    pz = ttk.Combobox(f2, width=7, textvariable=punkty_zycia, state='readonly')
    pz['values'] = (39, 60, 100)
    pz.grid(column=2, row=4)
    
    
    w3 = Label(f2, text="Siła Gracza  ")
    w3.grid(column=1, row=5)
    
    sila = IntVar()
    sila.set(15)
    ps = ttk.Combobox(f2, width=7, textvariable=sila, state='readonly')
    ps['values'] = (15, 30, 50)
    ps.grid(column=2, row=5)

    mapa_odkryta = Text(f, font=('Times', '12'), width=17, height=12)
    mapa_odkryta.grid()

    b1 = Button(okno, text='GENERUJ', bd=4, width=15, height=2, command=generuj_mape)
    b1.grid(column=5, row=2)

    b2 = Button(okno, text='ZAPISZ MAPĘ', bd=4, width=15, height=2, command=lambda: zapisz_mape(mapa_odkryta))
    b2.grid(column=5, row=3)

    b3 = Button(okno, text='ZAGRAJ', bd=4, width=15, height=2, bg="light blue", command=lambda: zagraj(poziom_pgen, wielkosc_mapygen, punkty_zycia, sila, okno))
    b3.grid(column=6, row=2)

    b4 = Button(okno, text='WYJDŹ', bd=8, width=20, height=5, command=lambda: wyjdz(okno))
    b4.grid(column=7, row=7)

    b5 = Button(okno, text='WCZYTAJ', bd=5, width=20, height=2, command=lambda: wczytaj_mape(mapa_odkryta))
    b5.grid(column=2, row=2)


    okno.mainloop()
