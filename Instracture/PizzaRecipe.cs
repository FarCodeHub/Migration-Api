using System;

namespace Instracture
{
    public class PizzaRecipe:Material
    {
        public string SelectPizzaRecipe()
        {
            Console.WriteLine("which pizza do you like ? 0- pizza , 1- pizza 2  , 2-pizza 3");
            var item = Console.ReadLine();

            return item == "1" ? Pizza1() : Pizza2();
        }

        public string Pizza1()
        {
           var sos = Soas();
           var cheese = Cheese();
           var olive = Olive();

           return sos + cheese + olive;
        }


        public string Pizza2()
        {
            var sos = Soas();
            var cheese = Cheese();

            return sos + cheese ;
        }

        public string Pizza3()
        {
            var sos = Soas();
            var cheese = Cheese();
            var olive = Olive();
            var sousage = Sausage();

            return sos + cheese + olive + sousage;
        }


    }
}
