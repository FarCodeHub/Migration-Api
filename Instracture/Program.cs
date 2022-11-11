
using System;
using System.IO;

namespace Instracture
{
    class Program : Recipe    //Logs
    {
        static void Main(string[] args)
        {
            var Log = new Logs();
            Console.WriteLine("What food do you like? 1- pizza 2- omlet");
            var foodId = Console.ReadLine();

            var foods = SelectFoodRecipe(foodId);

          //  var food = SelectFood(foodId);

            Console.WriteLine("Do you want the food instructions in the file or not? 1-no 2-yes");
            var logType = Console.ReadLine();
 



                if (logType == "1")
                    Log.WriteLog(foods);
                else
                    Log.MakingFile(foods);
        }


        //private static string SelectFood(string id) => id == "1" ? MakePizza("id") : MakeOmlet("id");

        //private static string MakePizza(string id)
        //{
        //    Pizza p = new Pizza();
        //    return p.PizzaMaterial(id);
        //}

        //private static string MakeOmlet(string id)
        //{
        //    Omlet p = new Omlet();
        //    return p.OmletMaterial(id);
        //}


    }
}
