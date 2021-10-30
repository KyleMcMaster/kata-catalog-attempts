#include "pch.h"
#include "Digit.h"

Digit::Digit(int digit)
{
	this->Grid = new char* [WIDTH];
	for (size_t i = 0; i < HEIGHT; i++)
	{
		this->Grid[i] = new char[HEIGHT];
	}

	switch (digit)
		{
		case 0: {
			auto line1 = new char[3]{ '.', '_', '.' };
			auto line2 = new char[3]{ '|', '.', '|' };
			auto line3 = new char[3]{ '|', '_', '|' };
			this->Grid[0] = line1;
			this->Grid[1] = line2;
			this->Grid[2] = line3;
			break;
		}
		case 1: {
			auto line1 = new char[3]{ '.', '.', '.' };
			auto line2 = new char[3]{ '.', '.', '|' };
			auto line3 = new char[3]{ '.', '.', '|' };
			this->Grid[0] = line1;
			this->Grid[1] = line2;
			this->Grid[2] = line3;
			break;
		}
		case 2: {
			auto line1 = new char[3]{ '.', '_', '.' };
			auto line2 = new char[3]{ '.', '_', '|' };
			auto line3 = new char[3]{ '|', '_', '.' };
			this->Grid[0] = line1;
			this->Grid[1] = line2;
			this->Grid[2] = line3;
			break;
		}
		case 3: {
			auto line1 = new char[3]{ '.', '_', '.' };
			auto line2 = new char[3]{ '.', '_', '|' };
			auto line3 = new char[3]{ '.', '_', '|' };
			this->Grid[0] = line1;
			this->Grid[1] = line2;
			this->Grid[2] = line3;
			break;
		}
		case 4: {
			auto line1 = new char[3]{ '.', '.', '.' };
			auto line2 = new char[3]{ '|', '_', '|' };
			auto line3 = new char[3]{ '.', '.', '|' };
			this->Grid[0] = line1;
			this->Grid[1] = line2;
			this->Grid[2] = line3;
			break;
		}
		case 5: {
			auto line1 = new char[3]{ '.', '_', '.' };
			auto line2 = new char[3]{ '|', '_', '.' };
			auto line3 = new char[3]{ '.', '_', '|' };
			this->Grid[0] = line1;
			this->Grid[1] = line2;
			this->Grid[2] = line3;
			break;
		}
		case 6: {
			auto line1 = new char[3]{ '.', '_', '.' };
			auto line2 = new char[3]{ '|', '_', '.' };
			auto line3 = new char[3]{ '|', '_', '|' };
			this->Grid[0] = line1;
			this->Grid[1] = line2;
			this->Grid[2] = line3;
			break;
		}
		case 7: {
			auto line1 = new char[3]{ '.', '_', '.' };
			auto line2 = new char[3]{ '.', '.', '|' };
			auto line3 = new char[3]{ '.', '.', '|' };
			this->Grid[0] = line1;
			this->Grid[1] = line2;
			this->Grid[2] = line3;
			break;
		}
		case 8: {
			auto line1 = new char[3]{ '.', '_', '.' };
			auto line2 = new char[3]{ '|', '_', '|' };
			auto line3 = new char[3]{ '|', '_', '|' };
			this->Grid[0] = line1;
			this->Grid[1] = line2;
			this->Grid[2] = line3;
			break;
		}
		case 9: {
			auto line1 = new char[3]{ '.', '_', '.' };
			auto line2 = new char[3]{ '|', '_', '|' };
			auto line3 = new char[3]{ '.', '.', '|' };
			this->Grid[0] = line1;
			this->Grid[1] = line2;
			this->Grid[2] = line3;
			break;
		}
	}
}

void Digit::Print()
{
	std::cout << Grid[0][0] << Grid[0][1] << Grid[0][2] << "\n";
	std::cout << Grid[1][0] << Grid[1][1] << Grid[1][2] << "\n";
	std::cout << Grid[2][0] << Grid[2][1] << Grid[2][2] << "\n";
}
