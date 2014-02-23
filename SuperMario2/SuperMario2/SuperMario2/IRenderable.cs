namespace SuperMario2
{
    using System;

    /// <summary>
    /// All object which could be rendered on out game world
    /// </summary>
    public interface IRenderable
    {
        MatrixCoords GetTopLeft();

        char[,] GetImage();
    }
}
