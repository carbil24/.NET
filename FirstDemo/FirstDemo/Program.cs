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
                        students();
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

        #region 2D arrays

        static void WeeklyCaloryCalculator()
        {
            int[,] calories = {
            {900, 750, 1020},
            {300, 1000, 2700},
            {500, 700, 2100},
            {400, 900, 1780},
            {600, 1200, 1100},
            {575, 1150, 1900},
            {600, 1020, 1700}};


            double[] dailyAverage;
            double[] mealAverage;

            dailyAverage = CalculateAverageByDay(calories);
            mealAverage = CalculateAverageByMeal(calories);


        }


        private static double[] CalculateAverageByDay(int[,] calories)
        {
            int numberRows = calories.GetLength(0);
            int numberColumns = calories.GetLength(1);
            double[] theDailyAverage = new double[numberRows];
            double sum = 0;

            for (int r = 0; r < numberRows; r++)
            {
                for (int c = 0; c < numberColumns; c++)
                {
                    sum += calories[r, c];
                }
                theDailyAverage[r] = sum / numberColumns;
                sum = 0;
            }

            return theDailyAverage;
        }

        private static double[] CalculateAverageByMeal(int[,] calories)
        {
            int numberRows = calories.GetLength(0);
            int numberColumns = calories.GetLength(1);
            double[] theMealAverage = new double[numberColumns];
            double sum = 0;

            for (int c = 0; c < numberRows; c++)
            {
                for (int r = 0; r < numberColumns; r++)
                {
                    sum += calories[r, c];
                }
                theMealAverage[c] = sum / numberRows;
                sum = 0;
            }

            return theMealAverage;
        }


        private static double CalculateAvgAllMeals(int[,] calories)
        {
            double sum = 0;
            foreach (int item in calories)
            {
                sum += item;
            }

            return sum / calories.Length;
        }

        private static double CalculateAvgAllMealsV2(int[,] calories)
        {
            int numberRows = calories.GetLength(0);
            int numberColumns = calories.GetLength(1);
            double[] allMealsAverage = new double[numberRows];
            double sum = 0;

            for (int r = 0; r < numberRows; r++)
            {
                for (int c = 0; c < numberColumns; c++)
                {
                    sum += calories[r, c];
                }
            }

            return sum / calories.Length;
        }

        #endregion

        #region Drawing shapes with nested loops
        static void startPiramide()
        {
            int num = 5;

            for (int i = 0; i < num; i++)
            {
                for (int j = num; j > i; j--)
                {
                    Console.Write("*");
                }

                Console.WriteLine();
            }
        }


        static void Pattern()
        {
            int num = 5;

            for (int i = 1; i <= num; i++)
            {
                for (int j = num; j > i; j--)
                {
                    Console.Write("o");
                }

                for (int j = 0; j <= i; j++)
                {
                    Console.Write(i);
                }
                Console.WriteLine();

            }

        }

        static void Pattern2()
        {
            int num = 5;

            for (int i = 1; i <= num; i++)
            {
                for (int j = num; j > i; j--)
                {
                    Console.Write(".");
                }

                Console.Write(i);

                for (int j = 0; j < i-1; j++)
                {
                    Console.Write(".");
                }
                Console.WriteLine();

            }

        }

        static void asdasd()
        {
            int num = 5;

            for (int i = 0; i < num; i++)
            {
                for (int j = 0; j < (num - i - 1) * 4; j++)
                {
                    Console.Write("/");
                }

                for (int j = 0; j < i*8; j++)
                {
                    Console.Write("*");

                }


                for (int j = 0; j < (num - i - 1) * 4; j++)
                {
                    Console.Write("\\");
                }

                Console.WriteLine();

            }

        }

        #endregion

        static void students()
        {
            int students = GetIntegerInput("Enter the number of students", 1);

            string[] studentNames = new string[students];
            double[] gradeAvgs = new double[students];
            double sum = 0, gradeTemp, totalSum = 0;
            const int NUMBER_OF_EXAMS = 5;

            for (int i = 0; i < students; i++)
            {
                //getting the names
                Console.Write("Enter student # {0} name: ", (i+1));
                studentNames[i] = Console.ReadLine();

                //get the 3 exam grades
                sum = 0;
                for (int j = 0; j < NUMBER_OF_EXAMS; j++)
                {
                    gradeTemp = GetDoubleInput(string.Format("Enter exam # {0} grade: ", (j + 1)));
                    sum += gradeTemp;
                }

                gradeAvgs[i] = sum / NUMBER_OF_EXAMS;
                totalSum += sum;
            }
            //4- Display output
            //Table header
            Console.WriteLine("{0}. {1,-10}{2,10}", "#", "Student Name", "Avg Grade");
            for (int i = 0; i < students; i++)
            {
                Console.WriteLine("{0}. {1,-10}{2,10}", (i+1), studentNames[i], gradeAvgs[i].ToString("n2"));
            }
        }

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

        static double GetDoubleInput(string customMessage)
        {
            double input;
            Console.Write("{0}:\t", customMessage);
            while (double.TryParse(Console.ReadLine(), out input) == false)
            {
                Console.Write("Input is not numeric, input again:\t");
            }

            return input;
        }
        #endregion


    }
}
