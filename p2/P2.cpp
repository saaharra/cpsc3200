//Sarah Nguyen
//Created by sarah on 4/13/2023.
//p2.cpp

#include "nova.h"
#include <iostream>
#include <memory>
#include <random>

using namespace std;


int main()
{
    int arrSize = rand() % 10 + 1;

    int* brightnessArry = new int[arrSize];
    int* powerArry = new int[arrSize];
    int* sizeArry = new int[arrSize];

    for(int i = 0; i < arrSize; i++){
        brightnessArry[i] = rand() % 401 + 100;
        powerArry[i] = rand() % 91 + 10;
        sizeArry[i] = rand() % 91 + 10;
    }

    cout << "this is creating the nova obj" << endl;
    nova obj = nova(brightnessArry, powerArry, sizeArry, arrSize);
    cout << "this would be calling the glow method on the nova obj" << endl;
    obj.glow(arrSize);

    cout << "this is to test the maxGlow function of a nova with lumen objects" << endl;
    cout << obj.maxGlow() << endl;
    cout << "this is to test the minGlow function of a nova with lumen objects" << endl;
    cout << obj.minGlow() << endl;
    cout << endl;

    cout << "This is to test out the recharge method" << endl;
    obj.recharge();
    cout << endl;

    cout << "This is to test out the assignment operator" << endl;
    nova obj3 = move(obj);
    obj3.glow(arrSize);

    cout << "this is to test the maxGlow function of a nova with lumen objects" << endl;
    cout << obj3.maxGlow() << endl;
    cout << "this is to test the minGlow function of a nova with lumen objects" << endl;
    cout << obj3.minGlow() << endl;
    cout << endl;


    cout << endl;
    cout << "This is to test the copy obj2" << endl;
    nova obj2(move(obj3));
    cout << "This is to show that the copy worked" << endl;
    obj2.glow(arrSize);
    cout << "this is to test the maxGlow function of a nova with lumen objects" << endl;
    cout << obj2.maxGlow() << endl;
    cout << "this is to test the minGlow function of a nova with lumen objects" << endl;
    cout << obj2.minGlow() << endl;
    cout << endl;

}