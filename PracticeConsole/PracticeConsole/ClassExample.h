#pragma once
#include <iostream>


class Shape {
	protected:
		int width, height;
	public:
		Shape(int a = 0, int b = 0) {
			width = a;
			height = b;
		}
		int area() {
			std::cout << "Parent class are:" << std::endl;
			return 0;
		}
};

class Rectangle : public Shape {
	public:
		Rectangle(int a = 0, int b = 0): Shape(a,b){}
		int area() {
			std::cout << "Rectangle class area:" << std::endl;
			return width*height;
		}
};


class foo {
public:
	double boo;
	double hello;
};

class Box {
public:
	double length1;
	double width1;

	Box(double l = 2, double w = 3) {
		std::cout << "HELLO" << std::endl;
		length = l;
		width = w;
		length1 = l;
		width1 = w;
	}
	double area() {
		return length * width;
	}
	double Area();

private:
	double length;
	double width;
};

double Box::Area() {
	return length1*width1;
}


int SudoMain() {
	foo obje;
	obje.boo = 1.5;
	obje.hello = 1.56;
	Box *ptrBox;

	Box Box1(3.5, 1.5);
	ptrBox = &Box1;

	Box Box2;

	std::cout << Box2.Area() << ptrBox->area() << std::endl;

	Box Box3(1.5, 6.5);

	ptrBox = &Box3;
	std::cout << ptrBox->area() << std::endl;

	Rectangle rec(10, 5);
	

	std::cout << rec.area();

	return 0;
}