namespace SuperMario
{
    using System;
    using System.IO;

    public abstract class Obstacle : IObstacle
    {   
        private char[,] background;

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
    }
}
