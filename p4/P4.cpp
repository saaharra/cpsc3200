//Sarah Nguyen
//Created by sarah on 4/13/2023.
//updated on 5/18/2023
//p4.cpp

#include <iostream>
#include <vector>
#include <memory>
#include <cstdlib>
#include <ostream>
#include "nova.h"
#include "lumen.h"
using namespace std;

// Helper function to create lumen objects
std::unique_ptr<lumen> createLumen(int brightness, int power, int size) {
    return unique_ptr<lumen>(new lumen(brightness, power, size));
}

int randomBrightness()
{
    int fillNum = rand() % 401 + 100;
    return fillNum;
}

int randomPowerAndSize()
{
    int fillNum = rand() % 91 + 10;
    return fillNum;
}

int* generateRandomArray(int size) {
    int* arr = new int[size];
    for (int i = 0; i < size; i++) {
        arr[i] = rand() % 401 + 100;
    }
    return arr;
}


int main() {
    int brightness = randomBrightness();
    int power = randomPowerAndSize();
    int size = randomPowerAndSize();
    // Creating lumen objects using unique_ptr
    unique_ptr<lumen> lumen1 = createLumen(brightness, power, size);
    unique_ptr<lumen> lumen2(new lumen(rand() % 401 + 100, rand() % 91 + 10, rand() % 91 + 10));

    // Copying lumen objects using copy constructor
    unique_ptr<lumen> lumen3(new lumen(*lumen1));

    // Testing operator overloads
    if (*lumen1 == *lumen3) {
        cout << "lumen1 is equal to lumen3" << endl;
    }

    cout << endl;

    *lumen1 += rand() % 5 + 1;
    if (*lumen1 > *lumen2) {
        cout << "lumen1 is greater than lumen2" << endl;
    }
    else
        cout << "lumen2 is greater than lumen1" << endl;

    cout << endl;

    cout << "this is lumen2 before you add lumen3 to it" << endl;
    cout << *lumen2 << endl;

    cout << endl;

    *lumen2+=*lumen3;

    cout << "this is lumen2 after you add the lumen3 to it" << endl;
    cout << *lumen2 << endl << endl;

    if (*lumen2 <= *lumen3) {
        cout << "lumen2 is less than or equal to lumen3" << endl;
    }
    else
        cout << "lumen3 is less than or equal to lumen2" << endl << endl;

    cout << "creating the pointer arrays for the nova object" << endl;
    int arrSize = rand() % 10 + 1;

    int* brightnessArray = generateRandomArray(arrSize);
    int* powerArray = generateRandomArray(arrSize);
    int* sizeArray = generateRandomArray(arrSize);
    cout << "creating a nova obj using shared_ptr" << endl;
    // Creating nova object using shared_ptr
    shared_ptr<nova> novaObj = make_shared<nova>(brightnessArray, powerArray, sizeArray, arrSize);

    cout << "Printing novaObj before the copy semantics" <<endl;
    cout << *novaObj << endl << endl;
    shared_ptr<nova> novaObj2 = move(novaObj);

    cout << "Printing novaObj2 to check the move semantics" << endl;
    cout << *novaObj2  << endl;

    cout << "Printing lumen1 before the copy semantics" <<endl;
    cout << *lumen1 << endl;
    cout << endl;
    // Move semantics
    unique_ptr<lumen> lumen4 = move(lumen1);

    cout << "Printing lumen4 to check the move semantics" << endl;
    cout << *lumen4<<endl <<endl;

    if (*lumen4 >= *lumen2) {
        cout << "lumen4 is greater than or equal to lumen2" << endl;
    }
    else
        cout << "lumen2 is greater than or equal to lumen4" << endl;

    cout << "Before prefix increment" << *lumen4 << endl;
    // Testing prefix increment operator
    ++(*lumen4);
    cout << "After prefix increment: " << *lumen4 << endl;

    cout << "Before postfix increment" << *lumen4 << endl;
    // Testing postfix increment operator
    (*lumen4)++;
    cout << "After postfix increment: " << *lumen4 << endl;

    cout << "Before prefix decrement" << *lumen4 << endl;
    // Testing prefix decrement operator
    --(*lumen4);
    cout << "After prefix decrement: " << *lumen4 << endl;

    cout << "Before postfix decrement" << *lumen4 << endl;
    // Testing postfix decrement operator
    (*lumen4)--;
    cout << "After postfix decrement: " << *lumen4 << endl;


    delete[] brightnessArray;
    delete[] powerArray;
    delete[] sizeArray;
    return 0;
}



