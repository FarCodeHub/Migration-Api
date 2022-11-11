using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instracture
{
   public class OmletRecipe : Material
    {
        public string SelectOmletRecipe()
        {
            Console.WriteLine("which omlet do you like ? 0- omlet , 1- omlet 2 ");
           return Console.ReadLine();
        }





    }
}
