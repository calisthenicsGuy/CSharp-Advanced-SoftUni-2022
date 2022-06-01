using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace P01.Meal_Plan
{
    public class Program
    {
        static void Main(string[] args)
        {
            var meals = new Queue<string>
                (Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries));
            var caloriesPerDay = new Stack<int>
                (Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            int countOfEatenMeals = 0;

            while (meals.Count() != 0 && caloriesPerDay.Count() != 0)
            {
                int currCalorie = caloriesPerDay.Peek();

                while (meals.Count() > 0)
                {
                    int currCalorieMeal = MealCalorie(meals.Dequeue());
                    currCalorie -= currCalorieMeal;
                    countOfEatenMeals++;

                    if (currCalorie <= 0)
                    {
                        caloriesPerDay.Pop();
                        if (caloriesPerDay.Count() == 0)
                        {
                            Console.WriteLine($"John ate enough, he had {countOfEatenMeals} meals.{Environment.NewLine}" +
                                                $"Meals left: {string.Join(", ", meals)}.");

                            return;
                        }

                        int calorieForTheNextDay = caloriesPerDay.Pop() - Math.Abs(currCalorie);
                        caloriesPerDay.Push(calorieForTheNextDay);
                        break;
                    }
                }
            }

            if (!meals.Any())
            {
                Console.WriteLine($"John had {countOfEatenMeals} meals.");
                Console.WriteLine($"For the next few days, he can eat {string.Join(", ", caloriesPerDay)} calories.");
            }
            else if (meals.Any())
            {
                Console.WriteLine($"John ate enough, he had {countOfEatenMeals} meals.{Environment.NewLine}" +
                    $"Meals left: {string.Join(", ", meals)}.");
            }
        }

        public static int MealCalorie(string currMeal)
        {
            if (currMeal == "salad")
            {
                return 350;
            }
            else if (currMeal == "soup")
            {
                return 490;
            }
            else if (currMeal == "pasta")
            {
                return 680;
            }
            else if (currMeal == "steak")
            {
                return 790;
            }

            return 0;
        }
    }
}
