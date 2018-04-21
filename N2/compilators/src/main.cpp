#include <iostream>
#include <fstream>
#include <cstdlib>
#include <omp.h>

#define MATRIX_X 700
#define MATRIX_Y 1000
#define RANDOM 100
#define As "A.txt"
#define Bs "B.txt"
#define Cs "C.txt"
using namespace std;

void generateMatrixFiles()
{
	ofstream fileA, fileB;
	fileA.open(As);
	fileB.open(Bs);

	for(int i = 0; i < MATRIX_X; i++)
	{
		for(int j = 0; j < MATRIX_Y; j++)
		{
			fileA << rand()%RANDOM << " ";
			fileB << rand()%RANDOM << " ";
		}
		fileA << endl;
		fileB << endl;
	}
	fileA.close();
	fileB.close();
}

void createMatrixTable(int** A, int** B, int** C)
{
	A = new int* [MATRIX_X];
	B = new int* [MATRIX_X];
	C = new int* [MATRIX_X];

	for(int i = 0; i < MATRIX_X; i++)
	{
		A[i] = new int [MATRIX_Y];
		B[i] = new int [MATRIX_Y];
		C[i] = new int [MATRIX_Y];
	}

}

void loadMatrixFromFiles(ifstream fileA, ifstream fileB, ofstream fileC,
		 int** A, int** B, int** C)
{
	for(int i = 0; i < MATRIX_X; i++)
		for(int j = 0; j < MATRIX_Y; j++)
		{
			fileA >> A[i][j];
			fileB >> B[i][j];
			C[i][j] = 0;
		}
}



int main() {

	generateMatrixFiles();

	int** A, **B, **C;
	createMatrixTable(A,B,C);

	ifstream fileA, fileB;
	ofstream fileC;

	fileA.open(As, ios::in);
	fileB.open(Bs, ios::in);
	fileC.open(Cs, ios::out);
	loadMatrixFromFiles(fileA, fileB, fileC, A, B, C);


	return 0;
}
