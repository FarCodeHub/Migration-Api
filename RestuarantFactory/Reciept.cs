using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestuarantFactory
{
    public class RecieptItem: IMaterial
    {
       
       
        public int UsedQuantity { get; set; }
        public string Brand { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Price { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Quantity { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Print(IOutputHandler outputHandler)
        {
            throw new NotImplementedException();
        }
    }

    public class Reciept
    {
        public List<RecieptItem> Items { get; private set; }

        public Reciept()
        {
            Items = new List<RecieptItem>();
        }

        public int Quantity()
        {
            return Items.Sum(x => x.UsedQuantity);
        }

        public int Price()
        {
            return Items.Sum(x => x.Price * x.UsedQuantity);
        }

        public void AddItem(IMaterial item,int usedQuantity)
        {
            //Map item to RecieptItem(Automapper) then fill UsedQuantity
            //Items.Add(item);
        }

        public IMaterial GetByType<T>()
        {
           return this.Items.FirstOrDefault(x => x.GetType() == typeof(T));
        }

    }
}
