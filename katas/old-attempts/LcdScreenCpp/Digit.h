#pragma once
class Digit
{
public:
	Digit(int x = 0);
	void Print();
private:
	size_t WIDTH = 3;
	size_t HEIGHT = 3;
	char** Grid;
};

