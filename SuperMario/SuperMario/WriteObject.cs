using System;
using System.IO;

namespace SuperMario
{
    public static class WriteObject
    {
        
        public static void WriteThis(IMovable target)
        {
            string typeOfTarget = target.GetType().Name;
                
            string[] lines = File.ReadAllLines(typeOfTarget+".txt");
            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }
            
        }
    }
}
