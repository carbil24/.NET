using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            const int EXIT_VALUE = 4;
            int choice;
            bool validInput;
            string menuItems = 
                "1. Police Radar Exercise\n" +
                "2. Item 2\n" +
                "3. Item 3\n" +
                EXIT_VALUE + ". Exit";

            do
            {
                Console.WriteLine(menuItems);
                choice = GetIntegerInput("Please enter a number");

                switch (choice)
                {
                    case 1:
                        PoliceRadar();
                        break;
                    case 2:
                        ExaminingValueTypes();

                        break;
                    case 3:
                        Console.WriteLine("You chose 3");

                        break;
                    case EXIT_VALUE:
                        Console.WriteLine("Exit... bye bye");

                        break;
                    default:
                        Console.WriteLine("Error, wrong input. Input again");

                        break;
                }

                Console.WriteLine("\nPress any key to continue");
                Console.ReadKey();
                Console.Clear();

            } while (choice != EXIT_VALUE);

            Console.ReadKey();

        }

        #region Exercise 1
        static void PoliceRadar()
        {
            Console.WriteLine("Welcome to the Radar Application");
            //Inputs
            int speedLimit, carSpeed;
            const int PONINTS_LIMIT = 5, MAX_POINTS = 12, MIN_SPEED = 0, MAX_SPEED = 200;

            speedLimit = GetIntegerInput("Enter the road speed limit", MIN_SPEED, MAX_SPEED);
            carSpeed = GetIntegerInput("Enter the car speed", MIN_SPEED, MAX_SPEED);

            if (carSpeed < speedLimit)
            {
                Console.WriteLine("Car is not speeding");
            }
            else if(carSpeed == speedLimit) 
            {
                Console.WriteLine("Warning: Slow down.");
            }
            else
            {
                Console.WriteLine("Over Speeding");
                //Demirit
                double numberOfPoints = (double)(carSpeed - speedLimit) / PONINTS_LIMIT;
                Console.WriteLine($"Your speed was {carSpeed} km/h." + $" Demerit points: {numberOfPoints}.");

                if (numberOfPoints > MAX_POINTS)
                {
                    Console.WriteLine("License is suspended");
                }
            }
        }
        #endregion

        #region Pass by Value exercises
        static void ExaminingValueTypes()
        {
            int grade = GetIntegerInput("Enter student grade", 0, 100);
            int gradeRef=1, gradeOut;
            Console.WriteLine("Grade before calling method:" + grade);
            ChangeGrade(grade);
            Console.WriteLine("Grade after calling method:" + grade);
            ChangeGrade(out grade);
            Console.WriteLine("Grade after calling out method:" + grade);

            ChangeGrade(out gradeOut);
            ChangeGradeRef(ref gradeRef);
        }

        static void ChangeGrade(int grade)
        {
            grade = 100;
        }

        static void ChangeGrade(out int gradeOut)
        {
            gradeOut = 100;
        }

        static void ChangeGradeRef(ref int gradeOut)
        {
            gradeOut = 100;
        }

        #endregion

        #region Pass by Reference
        static void ExamineReferenceTypes()
        {
            int[] numArray = new int[5];
            Console.WriteLine("Array before");
            PrintArray(numArray);
            PopulateArray(numArray);
            Console.WriteLine("Array after");
            PrintArray(numArray);
        }

        static void PopulateArray(int [] passedArray) 
        {
            for (int i = 0; i < passedArray.Length; i++)
            {
                passedArray[i] = GetIntegerInput("Enter array element # " + i);
            }
        }

        static void changeArray(int[] passedArray)
        {
            passedArray = new int[10];
            passedArray[0] = 100;
        }

        static void PrintArray(int[] passedArray)
        {
            foreach (int number in passedArray)
            {
                Console.WriteLine(number + " ");
            }
            Console.WriteLine();
        }


        #endregion

        #region Helper Methods
        static int GetIntegerInput(string customMessage)
        {
            int input;
            Console.Write("{0}:\t", customMessage);
            while (int.TryParse(Console.ReadLine(), out input) == false)
            {
                Console.Write("Input is not numeric, input again:\t");
            }

            return input;
        }

        /*static int GetIntegerInput(string customMessage, int min)
        {
            int input;
            Console.Write("{0}:\t", customMessage);
            while (int.TryParse(Console.ReadLine(), out input) == false || input <= min)
            {
                Console.Write("Input is not numeric or not within range, input again:\t");
            }

            return input;
        }*/

        static int GetIntegerInput(string customMessage, int min)
        {
            int input = GetIntegerInput(customMessage);
            while(input <= min)
            {
                Console.Write("Error, input cannot be less than {0}, try again: ", min);
                input = GetIntegerInput(customMessage);
            }

            return input;
        }

        static int GetIntegerInput(string customMessage, int min, int max)
        {
            int input = GetIntegerInput(customMessage, min);
            while (input > max)
            {
                Console.Write("Error, input cannot be more than {0}, try again: ", max);
                input = GetIntegerInput(customMessage, min);
            }

            return input;
        }

        /*static int GetIntegerInput(string customMessage, int min, int max)
        {
            int input = GetIntegerInput(customMessage, min);
            while (input < min || input > max)
            {
                Console.Write("Error, input cannot be more than {0} & {1}, try again: ", min, max);
                input = GetIntegerInput(customMessage, min);
            }

            return input;
        }*/
        #endregion
    }
}
