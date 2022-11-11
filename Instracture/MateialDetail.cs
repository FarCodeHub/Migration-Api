using System.Reflection.Metadata;

namespace Instracture
{
    public class MateialDetail
    {
 
        public virtual string Detail(string _price , string _title)
        {
            return _price + _title;
        }

    }
}