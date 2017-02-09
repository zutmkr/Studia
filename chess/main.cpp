
#include <stdio.h>
#include <tchar.h>
#include <iostream>
#include <Windows.h>
#include <stdlib.h>     // srand, rand
#include <time.h>		// time

// ConsoleApplication1.cpp : Defines the entry point for the console application.



//TODO ...


using namespace std;

/////////////////////CLASS HEADERS/////////////

class Queen;
class Board;
class Square;

/////////////////////QUEEN/////////////////////

class Queen
{
public:
	int pos_x, pos_y;
};


/////////////////////SQUARE////////////////////
class Square
{
public:
	Square();
	int pos_x, pos_y;
	bool status;
};

Square::Square()
{
	status = 0;
}

/////////////////////BOARD/////////////////////

class Board
{
public:
	Board(int l);
	~Board();

	int size;
	Square** state;


};

Board::Board(int l)
{
	//int SQ_number = 0;
	size = l;

	state = new Square*[l];
	for (int i = 0; i < l; i++)
	{
		state[i] = new Square[l];
	}

	for (int row = 0; row < l; row++)
	{
		for (int col = 0; col < l; col++)
		{
			state[row][col].pos_x = col;
			state[row][col].pos_y = row;
		}
	}
}

Board::~Board()
{
	for (int i = 0; i < size; i++)
		delete state[i];

	delete[] state;
}






int main()
{
	srand(time(NULL));

	int random,random2,changes = 0;
	int q = 5;


	Board fBoard(q);

	Queen* queen_table = new Queen[q];

	cout << "        y x" << endl;
	for (int i = 0; i < q; i++)
    {
        random = rand() % (q);
		random2 = rand() % (q);

		cout << "RANDOM  " << random2 << " " << random << endl;
		cout << endl;


		queen_table[i].pos_x = random;
		queen_table[i].pos_y = random2;


    }
for (int i = 0; i < q; i++)
    for (int k = 0; k < q; k++)
    cout << fBoard.state[i][k].pos_x << "||" << fBoard.state[i][k].pos_y<<endl;

	for (int k = 0; k < q; k++)
	{
		for (int i = 0; i < q; i++)
		{
			if ((fBoard.state[i][k].pos_x == queen_table[k].pos_x) && (fBoard.state[i][k].pos_y == queen_table[k].pos_y))
			{
				fBoard.state[i][k].status = 1;
				changes++;
			}

		}
	}

	for (int i = 0; i < q; i++)
		for (int k = 0; k < q; k++)
			cout << "Pole o wspolrzednych y: " << i << " oraz x: " << k <<" wynosi(bool): " << fBoard.state[i][k].status << endl;


	//cout << "Stworzylem " << (fBoard.size * fBoard.size) << " pol" << endl << endl << endl << endl;

	cout << "changes: " << changes << endl;
	system("pause");

	return 0;
}
