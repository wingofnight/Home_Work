#pragma once
#include <iostream>
#include <string>
using namespace std;
class Planet {
	string Planet_name;
	string Planet_Type;
	double Planet_Coordinate[2];
public:
	Planet() {
		Planet_name = "Eart";
		Planet_Type = "Eco";
		Planet_Coordinate[0] = 0;
		Planet_Coordinate[1] = 0;
	}
	Planet(string Planet_name, string Planet_Type, double Planet_Coordinate[2]) {
		Planet_name = "Eart";
		Planet_Type = "Eco";
		Planet_Coordinate[0] = 0;
		Planet_Coordinate[1] = 0;
	}
};

class Country : public Planet {
	string country_name;
	string country_coordinate;
	long int country_strength;
	
public:
	friend void Create_Country(Country &);
	};
void Create_Country(Country & country) {
	cout << "Enter country name : "; cin >> country.country_name;
	cout << "Enter country coordinate : "; cin >> country.country_coordinate;
	cout << "Enter country strength: "; cin >> country.country_strength;
}
class capital : public Planet {
public:
	string capital_name;
	string capital_coordinate;
	long int capitel_strenght;

};
