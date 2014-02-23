namespace SuperMario
{
    public interface IMovable
    {
        int LocationX { get; set; }
        int LocationY { get; set; }

        void Moving();
    }
}
