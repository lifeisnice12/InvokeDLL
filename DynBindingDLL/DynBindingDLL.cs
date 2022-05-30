using System;

namespace BelSoft
{
    // This class, to be loaded dynamically cannot be static.
    // However the methode can be static.
    public class DynBindingDLL
    {
        public static void PrintHello(string text, int count)
        {
            using (System.IO.StreamWriter w = new System.IO.StreamWriter(@"Invoker.txt", true))
            {
                for (int i = 1; i <= count; i++)
                    w.WriteLine(text + " " + DateTime.Now.ToString());
                w.Flush();
            }
        }
    }
}