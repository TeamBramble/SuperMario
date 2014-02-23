namespace SuperMario
{
    using System;
    using System.IO;

    public abstract class Obstacle : IObstacle
    {   
        
        /*
        public void RenderMap()
        {
            
            using (StreamReader reader = new StreamReader("..\\..\\images\\Background.txt"))
            {
                string[] lines = reader.ReadToEnd().Split(Environment.NewLine.ToCharArray());
                

               foreach (string line in lines)
                {
                   line.ToCharArray();
                }
                
                
            }
         
        }
         */
        //TO DO Да се конвертира от string[] към char[ , ], или по някакъв друг начин директно от файла,за да се проверява за сблъсъци
    }
}
