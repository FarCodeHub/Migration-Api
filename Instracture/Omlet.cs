using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instracture
{
    public class Omlet : Food
    {

        public override string Material()
        {
            return base.Material();

        }

        public string OmletMaterial(string id)
        {
            var commonMateial = Material();
            string[] omlet = { "egge and tomato", "egge and tomato , Cheese" };
            Console.WriteLine("which omlet do you like ? 0- omlet , 1- omlet 2 ");
            var omletId = Console.ReadLine();
            return omlet[int.Parse(omletId)] + commonMateial;
        }
    }
}
