namespace SuperMario2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public interface ICollidable
    {
        bool CanCollideWith(string objectType);

        List<MatrixCoords> GetCollisionProfile();

        void RespondToCollision(CollisionData collisionData);

        string GetCollisionGroupString();
    }
}
