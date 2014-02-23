namespace SuperMario
{
    using System;

    public abstract class Move : IMovable
    {
        Hero ActiveHero = new Hero();
      

        public int LocationX
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int LocationY
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }


        public void Moving()
        {
            throw new NotImplementedException();
        }
    }
}
