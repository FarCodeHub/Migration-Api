using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instracture
{
    public class Pizza : Food
    {

        public override string Material()
        {
            return base.Material();

        }

        public string PizzaMaterial(string id)
        {

            var commonMateial=  Material();
            string[] pizza = { "Cheese, sausage", "Cheese, sausage,", "sausage" };
            Console.WriteLine("which pizza do you like ? 0- pizza , 1- pizza 2  , 2-pizza 3");
            var pizzaId = Console.ReadLine();
            return pizza[int.Parse(pizzaId)] + commonMateial;

        }

    }
}
