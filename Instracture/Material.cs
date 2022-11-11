using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instracture
{
   public class Material:MateialDetail
    {
        public override string Detail(string price , string title)
        {
            return base.Detail(price, title);

        }


        public string Soas()
        {
            var detail = Detail("2500", "mahram");
            Console.WriteLine("Soas");
            return "Soas " + detail;
        }

        public string Cheese()
        {
            var detail = Detail("34", "pegah");
            Console.WriteLine("Cheese");
            return "Cheese " + detail;
        }

        public string Sausage()
        {
            var detail = Detail("2500000", "andre");
            Console.WriteLine("Sausage");
            return "Sausage " + detail;
        }

        public string Bread()
        {
            var detail = Detail("5000", "sangak");
            Console.WriteLine("Bread");
            return "Bread " + detail;
        }

        public string Egge()
        {
            var detail = Detail("1500", "30morgh");
            Console.WriteLine("Egge");
            return "Egge " + detail;

        }

        public string Olive()
        {
            var detail = Detail("254400", "ddd");
            Console.WriteLine("Olive");
            return "Olive " + detail;

        }


    }
}
