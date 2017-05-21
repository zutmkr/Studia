from tkinter import *

def generator():

    okno = Tk()
    
    okno.title('Dorothy\'s Dungeon Map Generator v0.01')
    okno.geometry("1200x900")
    
    f = LabelFrame(okno, text='WYGENEROWANA MAPA', labelanchor='n')
    f.grid(columnspan=4, row=0)
    
    f2 = LabelFrame(okno, text='OPCJE PODZIEMI', labelanchor='n')
    f2.grid(column=6, row=0)
    
    w = Label(f2, text="Poziom podziemi  ")
    w.grid(column=1, row=2)
    
    s = Spinbox(f2, from_=1, to=20, width=5)
    s.grid(column=2, row=2)
    
    w1 = Label(f2, text="Wielkość mapy  ")
    w1.grid(column=1, row=3)
    
    s1 = Spinbox(f2, from_=7, to=12, width=5)
    s1.grid(column=2, row=3)
    
    w2 = Label(f2, text="Punkty życia  ")
    w2.grid(column=1, row=4)
    
    s = Menubutton(f2, text='dużo')
    s.grid(column=2, row=4)
    s.menu = Menu(s, tearoff=0)
    s["menu"] = s.menu
    s.menu.add_checkbutton(label="mało")
    
    
    mapa_odktyra = Text(f, font=('Times', '12'))
    mapa_odktyra.grid()
    
    b1 = Button(okno, text='GENERUJ', bd=4, width=15, height=2)
    b1.grid(column=5, row=2)
    
    b2 = Button(okno, text='ZAPISZ MAPĘ', bd=4, width=15, height=2)
    b2.grid(column=5, row=3)
    
    b3 = Button(okno, text='ZAGRAJ', bd=4, width=15, height=2, bg="light blue")
    b3.grid(column=6, row=2)
    
    b4 = Button(okno, text='WYJDŹ', bd=8, width=20, height=5)
    b4.grid(column=7, row=7)
    
    b5 = Button(okno, text='WCZYTAJ', bd=5, width=20)
    b5.grid(column=2, row=2)
    
    b6 = Button(okno, text='USUN', bd=5, width=20)
    b6.grid(column=2, row=3)
    
    c = Checkbutton(okno, text='Losuj wszystkie parametry')
    c.grid(column=6, row=3)
    
    okno.mainloop()
