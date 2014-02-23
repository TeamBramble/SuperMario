namespace SuperMario2
{
    using System;
    using System.IO;
    /// <summary>
    /// All object which could be rendered on out game world
    /// </summary>
    public interface IRenderable
    {
        MatrixCoords GetTopLeft();
        void WriteThis (GameObject target );
        
        char[,] GetImage();
    }
}
