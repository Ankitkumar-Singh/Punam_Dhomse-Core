using System;

namespace Assignmnet2
{
    class Program
    {
        public static void Main(string[] args)
        {
            int c; //Reading a Choice 
            Console.Write("Enter first number: "); 
            int a = int.Parse(Console.ReadLine());  
            Console.Write("Enter second number: ");  
            int b = int.Parse(Console.ReadLine());  

            do{
                Console.WriteLine("1.Addition");  
                Console.WriteLine("2.Subtraction");  
                Console.WriteLine("3.Divsion");  
                Console.WriteLine("4.Multiplication");  
                Console.WriteLine("5.Increment");  
                Console.WriteLine("6.Decrement");  
                Console.WriteLine("7.Square"); 
                Console.WriteLine("Enter your choice");
                
                c = int.Parse(Console.ReadLine()); 

                switch(c)  
                {  
                    case 1:  
                    Console.WriteLine("Addition Of Two Numbers :\n "+Calculator.Add(a,b));  
                    break;  
                    case 2:  
                    Console.WriteLine("\nSubtraction Of Two Numbers : " + Calculator.Subtraction(a,b));  
                    break;  
                    case 3:  
                    Console.WriteLine("\nDivision Of Two Numbers : " + (a / b));  
                    break;  
                    case 4:  
                    Console.WriteLine("\nMultiplicaion Of Two Numbers : " + Calculator.Multiplication(a,b));  
                    break;  
                    case 5:  
                    Console.WriteLine("\nIncrement Numbers : " + (++a) + " " + (++b));  
                    break;  
                    case 6:  
                    Console.WriteLine("\nDecrement Numbers : " + (--a)+" "+(--b));  
                    break;  
                    case 7:  
                    Console.WriteLine("\nSquare Numbers : " + Calculator.Square(a)); 
                    break; 
                    default:  
                    Console.WriteLine("\nChoose Only 1 To 7 ");  
                    break;  
                } 
                Console.WriteLine("\nDo you want to continue? 1 Yes/0 No:");
                c=int.Parse(Console.ReadLine());
            }while(c == 1);
        }
    }
}

