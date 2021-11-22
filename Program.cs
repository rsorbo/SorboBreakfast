using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SorboBreakfast
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            Coffee cup = PourCoffee();
            Console.WriteLine("coffee is ready");

            var eggsTask = FryEggsAsync(2);
            var baconTask = FryBaconAsync(3);
            var toastTask = MakeToastWithButterAndJamAsync(2);

            var breakfastTasks = new List<Task> { eggsTask, baconTask, toastTask };
            while (breakfastTasks.Count >0)
            {
                Task finishedTask = await Task.WhenAny(breakfastTasks);
                if (finishedTask == eggsTask)
                {
                    Console.WriteLine("Eggs are ready");
                }
                else if (finishedTask == baconTask)
                {
                    Console.WriteLine("Bacon is ready");
                }
                else if (finishedTask == toastTask)
                {
                    Console.WriteLine("Toast is ready");
                }
                breakfastTasks.Remove(finishedTask);
            }

            
            Juice oj = PourOJ();
            Console.WriteLine("oj is ready");
            Console.WriteLine("Breakfast is ready!");

        }

        static Juice PourOJ()
        {
            Console.WriteLine("Pouring orange juice");
            return new Juice();
        }

        public static string ApplyJam(Toast toast)
        {
            Console.WriteLine("Putting jam on the toast");
            return "Putting jam on the toast";
        }

        public static string ApplyButter(Toast toast)
        {
            Console.WriteLine("Putting butter on the toast");
            return "Putting butter on the toast";
        }

        static async Task<Toast> MakeToastWithButterAndJamAsync(int number)
            {   var toast = await ToastBreadAsync(number);
                ApplyButter(toast);
                ApplyJam(toast);

                return toast;
            }

        static async Task<Toast> ToastBreadAsync(int slices)
        {
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("Putting a slice of bread in the toaster");
            }

            Console.WriteLine("Start toasting...");
            await Task.Delay(2000);
            //Console.WriteLine("Fire! Toast is ruined!");
            //throw new InvalidOperationException("The toaster is on fire");
            await Task.Delay(1000);
            Console.WriteLine("Remove toast from toaster");

            return new Toast();

        }
        

        static async Task<Bacon> FryBaconAsync(int slices)
        {
            Console.WriteLine($"putting {slices} slices of bacon in the pan");
            Console.WriteLine("cooking first side of bacon...");
            await Task.Delay(3000);
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("flipping a slice of bacon");
            }
            Console.WriteLine("cooking the second side of bacon...");
            await Task.Delay(3000);
            Console.WriteLine("Put bacon on plate");

            return new Bacon();
        }

        static async Task<Eggs> FryEggsAsync(int howMany)
        {
            Console.WriteLine("Warming the egg pan...");
            await Task.Delay(3000);
            Console.WriteLine($"cracking {howMany} eggs");
            Console.WriteLine("cooking the eggs ...");
            await Task.Delay(3000);
            Console.WriteLine("Put eggs on plate");

            return new Eggs();
        }

        public static Coffee PourCoffee()
        {
            Console.WriteLine("Pouring coffee");
            return new Coffee();
            
        }
    }
}
