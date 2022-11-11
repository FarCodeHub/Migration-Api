using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestuarantFactory
{
   public interface IOutputHandler
    {
        public void Write(string text);
    }

    public class ConsoleOutPut : IOutputHandler
    {
        public void Write(string text)
        {
           Console.WriteLine(text);
        }
    }

    public class FileOutPut : IOutputHandler
    {
        public string Path { get; set; }
        public void Write(string text)
        {
            //Open and write file
        }
    }
}
