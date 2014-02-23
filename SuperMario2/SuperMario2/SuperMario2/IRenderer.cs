namespace SuperMario2
{
    using System;

    /// <summary>
    /// Setup object for renderring, render all, clear rendered objects
    /// </summary>
    public interface IRenderer
    {
        void EnqueueForRendering(IRenderable obj);

        void RenderAll();

        void ClearQueue();
    }
}
