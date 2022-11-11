using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instracture
{
   public sealed class Logs
    {
        public   void MakingFile(string instracture)
        {
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            using StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "WriteLines.txt"));
            outputFile.WriteLine(instracture);
        }

        public   void WriteLog(string instracture) => Console.WriteLine(instracture);
    }
}
