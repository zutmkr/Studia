#include <iostream>
#include <stdio.h>
#include <stdlib.h>
#include <windows.h>
#include <wininet.h>
#include <cstring>
#include <string>

using namespace std;

void kurs(){


	string str,str2;
	float ex;

	HINTERNET connect = InternetOpenA("MyBrowser", INTERNET_OPEN_TYPE_PRECONFIG, NULL, NULL, 0);

	if (!connect) {
		cout << "Connection Failed or Syntax error";

	}

	HINTERNET OpenAddress = InternetOpenUrlA(connect, "http://api.nbp.pl/api/exchangerates/rates/a/eur/", NULL, 0, INTERNET_FLAG_PRAGMA_NOCACHE | INTERNET_FLAG_KEEP_CONNECTION, 0);

	if (!OpenAddress)
	{
		DWORD ErrorNum = GetLastError();
		cout << "Failed to open URL \nError No: " << ErrorNum;
		InternetCloseHandle(connect);

	}

	char DataReceived[4096];
	DWORD NumberOfBytesRead = 0;
	while (InternetReadFile(OpenAddress, DataReceived, 4096, &NumberOfBytesRead) && NumberOfBytesRead)
	{
		//cout << DataReceived;
		str += DataReceived;
	}

	ex = stof(str.substr(111, 6));

	cout << ex;

	InternetCloseHandle(OpenAddress);
	InternetCloseHandle(connect);

}




void sprawdz(int* cenapomodulo){

    if (*cenapomodulo <= 5)
        *cenapomodulo = 5;
    else
        *cenapomodulo = 9;
};




int main()
{
    int cena, cenapl,i;
    float mnoznik[4] = {0.85,0.75,0.65,0.5};
    int temp,temp2;
    char wybor;

    kurs();

    do{

        printf("\nPodaj cene w EURO znaleziona na zagranicznych stronach: ");
        scanf("%d", &cena);
        cenapl = cena*4;
        printf("Cena sugerowana to %d PLN \n\n", cenapl);
        printf("\tNormalne \t\t Dodatkowo obnizone\n");

        for(i=0; i<4; i++)
        {
            temp = cenapl*mnoznik[i];
            temp2 = cenapl*mnoznik[i];
            //printf("\n\ncena po obnizce %d\n\n", temp);
            temp = temp%10;
            temp2 -= temp;
            sprawdz(&temp);
            temp2 += temp;


            if(i==0)
                printf("\tKlasa 1 to %d PLN ", temp2);
            else if(i==1)
                printf("\t\t Klasa 1 to %d PLN \n", temp2);
            else if(i==2)
                printf("\tKlasa 2 to %d PLN ", temp2);
            else
                printf("\t\t Klasa 2 to %d PLN \n\n", temp2);
        }


        printf("Czy chcesz pracowac dalej? Wpisz t lub n: ");
        scanf(" %c", &wybor);


  } while (wybor !='n');
  printf("\t\tDziekuje za skorzystanie z programu");
  Sleep(2000);

    return 0;
}
