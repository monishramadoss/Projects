// PracticeConsole.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "ClassExample.h"
#include <Windows.h>
#include <stdio.h>
#include <stdlib.h>
#include <iostream>
#include <time.h>
using namespace std;


int main()
{
	while (true) {
		time_t timer;
		time(&timer);
		cout << ctime(&timer) << endl;
		Sleep(1000);
		system("cls");
	}
	cin.get();
	return 0;
}

