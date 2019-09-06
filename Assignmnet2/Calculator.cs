using System;

namespace Assignmnet2
{
    public class  Calculator{

    //Square the entered number
    public static int Square( int num){
        return num * num;
    }

    //Add two number
    public static int Add ( int num1,int num2){
        return num1 + num2;
    }

    //Subtract two number
    public static int Subtraction ( int num1 ,int num2){
        if(num1 > num2)
        {
            return num1 - num2;
        }
        else
        {
            return num2 - num1;
        }
    }

    //Multiplication of two number
    public static int Multiplication( int num1, int num2){
            return num1 * num2;
        }
    }
}