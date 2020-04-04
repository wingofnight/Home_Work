#include <iostream>
#include <string>
#include "Classes.h"
using namespace std;
int whoBig(capital zero, capital one, capital two);

int main()
{
	capital Mosscow;
	capital Voronez;
	capital Saratov;

	Mosscow.capitel_strenght = 10;
	Voronez.capitel_strenght = 1;
	Saratov.capital_coordinate = -1;
	//whoBig(Mosscow, Voronez, Saratov);
	cout << " have a many piople = " << whoBig(Mosscow, Voronez, Saratov);
}

int whoBig(capital zero, capital one, capital two) {
	capital Capital[3]{ zero,one,two };
	int buff = Capital[0].capitel_strenght;
	string bigCapital = Capital[0].capital_name;
	for (int i = 0; i < 3; i++)
	{	
		if (buff < Capital[i].capitel_strenght)
		{
			buff = Capital[i].capitel_strenght;
			bigCapital = Capital[i].capital_name;
		}
	}
	cout << bigCapital;
	return buff;
}
