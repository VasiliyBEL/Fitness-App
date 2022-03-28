using Fitness.BL.Controller;
using Fitness.BL.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.CMD
{
    class Program
    {
        static void Main()
        {
            var culture = CultureInfo.CreateSpecificCulture("ru-ru");
            var resourceManager = new ResourceManager("Fitness.CMD.Languages.Messages(RU)", typeof(Program).Assembly);

            Console.WriteLine(resourceManager.GetString("Welcome", culture));

            Console.WriteLine(resourceManager.GetString("EnterName", culture));
            var name = Console.ReadLine();

            var userController = new UserController(name);
            var eatingController = new EatingController(userController.CurrentUser);
            var exerciseController = new ExerciseController(userController.CurrentUser);
            if (userController.IsNewUser)
            {
                Console.Write("Введите пол: ");
                var gender = Console.ReadLine();
                var birthDate = ParseDateTime("дата рождения");
                var weight = ParseDouble("вес");
                var height = ParseDouble("рост");

                userController.SetNewUserData(gender, birthDate, weight, height);
            }

            Console.WriteLine(userController.CurrentUser);

            while (true)
            {
                Console.WriteLine("Что вы хотите сделать?");
                Console.WriteLine("Е - ввести прием пищи.");
                Console.WriteLine("А - ввести упражнение.");
                Console.WriteLine("Q - выход.");
                var key = Console.ReadKey();
                Console.WriteLine();

                switch (key.Key)
                {
                    case ConsoleKey.E:
                        {
                            var foods = EnterEating();
                            eatingController.Add(foods.Food, foods.Weight);

                            foreach (var item in eatingController.Eating.Foods)
                            {
                                Console.WriteLine($"\t{item.Key} - {item.Value}");
                            }
                        }
                        break;
                    case ConsoleKey.A:
                        {
                            var exe = EnterExercise();
                            exerciseController.Add(exe.Activity, exe.Begin, exe.End);

                            foreach(var item in exerciseController.Exercises)
                            {
                                Console.WriteLine($"\t{item.Activity} с {item.Start.ToShortTimeString()} до {item.Finish.ToShortTimeString()}");
                            }
                        }
                        break;
                    case ConsoleKey.Q:
                        Environment.Exit(0);
                        break;
                }
                Console.ReadLine();
            }
        }

        private static (DateTime Begin, DateTime End, Activity Activity) EnterExercise()
        {
            Console.Write("Введите название упражнения: ");
            var name = Console.ReadLine();

            var energy = ParseDouble("расход энергии в минуту");

            var begin = ParseDateTime("начало упражнения");
            var end = ParseDateTime("окончание упражнения");

            var activity = new Activity(name, energy);
            return (begin, end, activity);
        }

        /// <summary>
        /// Tuple for EatingController.
        /// </summary>
        /// <returns> Tuple(Food,double) </returns>
        private static (Food Food, double Weight) EnterEating()
        {
            Console.WriteLine("Введите имя продукта: ");
            var food = Console.ReadLine();

            var calories = ParseDouble("Калорийность");
            var prot = ParseDouble("Белки");
            var fats = ParseDouble("Жиры");
            var carbs = ParseDouble("Углеводы"); 

            var weight = ParseDouble("вес порции");
            var product = new Food(food, calories, prot, fats, carbs );


            return (Food: product, Weight: weight);
        }

        /// <summary>
        /// Processing of Time.
        /// </summary>
        /// <returns> birthDate </returns>
        private static DateTime ParseDateTime(string value)
        {
            DateTime birthDate;
            while (true)
            {
                Console.Write($"Введите {value} (dd.MM.yyyy): ");
                if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine($"Неверный формат {value}.");
                }
            }

            return birthDate;
        }

        /// <summary>
        /// Processing of weight or height.
        /// </summary>
        /// <param name="name"></param>
        /// <returns> weight or double </returns>
        private static double ParseDouble(string name)
        {
            while (true)
            {
                Console.Write($"Введите {name}: ");
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine($"Неверный формат поля {name}a.");
                }
            }
        }
    }
}