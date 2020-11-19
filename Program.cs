using System;
using System.Collections.Generic;

namespace Gradebook
{

  
    class Program
    {
        static void Main(string[] args)
        {

            IBook book = new DiskBook("Chris Grade Book");
            book.GradeAdded += OnGradeAdded;

            EnterGrades(book);
            var stats = book.GetStatistics();

            
            Console.WriteLine($"For the book named {book.Name} ");
            System.Console.WriteLine($"The Lowest Grade is {stats.Low}");
            System.Console.WriteLine($"The Highest Grade is {stats.High}");
            System.Console.WriteLine($"The Average Grade is {stats.Average:N1}");
            Console.WriteLine($"The letter grade is {stats.Letter}");

        }

        private static void EnterGrades(InMemoryBook book)
        {
            throw new NotImplementedException();
        }

        private static void EnterGrades(IBook book)
        {
            while (true)
            {
                Console.WriteLine("Enter Grade or 'q' to quit");
                var input = Console.ReadLine();
                if (input == "q")
                {
                    break;

                }

                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine("**");
                }

            }
        }

        static void OnGradeAdded(object sender, EventArgs e)
              {

                  Console.WriteLine("A Grade Was Added");
              }    
         }
    }