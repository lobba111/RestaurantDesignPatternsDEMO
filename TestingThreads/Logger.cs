using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingThreads
{
    public static class Logger 
    {
        public static void LogInfo(string message)
        {
            string foler = @"C:\Users\robin\OneDrive\Skrivbord\ThreadLogger\";
            string fileName = "ThreadLogg.txt";
            string fullPath = foler + fileName;
            File.AppendAllText(fullPath, message);
        }
    }
}
