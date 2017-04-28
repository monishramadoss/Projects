#pragma once

#include <iostream>
#include <fstream>
#include <istream>

using namespace std;

int sudoMain1(){

	char data[100];

	fstream ffile;
	string line;
	ffile.open("ReadMe.txt");

	while (ffile.getline(data,100)) {
		cout << data << endl;
	}
		
	ffile >> data;

	ffile.close();
	return 0;

}