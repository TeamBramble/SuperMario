namespace SuperMario2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;

    public class Engine
    {
        private readonly IRenderer renderer;
        private readonly IUserInterface userInterface;
        private readonly List<GameObject> allObjects;
        private readonly List<MovingObject> movingObjects;
        private readonly List<GameObject> staticObjects;
        private readonly int waitMs;
        private Mario playerMario;

        public Engine(IRenderer renderer, IUserInterface userInterface, int waitMs, int worldRows, int worldCols)
        {
            Console.SetWindowSize(120,60);
            Console.SetBufferSize(500, 100);
            this.renderer = renderer;
            this.userInterface = userInterface;
            this.allObjects = new List<GameObject>();
            this.movingObjects = new List<MovingObject>();
            this.staticObjects = new List<GameObject>();
            this.waitMs = waitMs;
            this.WorldRows = worldRows;
            this.WorldCols = worldCols;
        }

        public int WorldRows { get; protected set; }

        public int WorldCols { get; protected set; }

        private void AddStaticObject(GameObject obj)
        {
            this.staticObjects.Add(obj);
            this.allObjects.Add(obj);
        }

        private void AddMovingObject(MovingObject obj)
        {
            this.movingObjects.Add(obj);
            this.allObjects.Add(obj);
        }

        public virtual void AddObject(GameObject obj)
        {
            if (obj is MovingObject)
            {
                this.AddMovingObject(obj as MovingObject);
            }
            else
            {
                if (obj is Mario)
                {
                    AddMario(obj);

                }
                else
                {
                    this.AddStaticObject(obj);
                }
            }
        }

        private void AddMario(GameObject obj)
        {
            this.playerMario = obj as Mario;

            for (int i = 0; i < this.allObjects.Count; i++)
            {
                if (this.allObjects[i] is Mario)
                {
                    this.allObjects.RemoveAt(i);
                    i--;
                }
            }

            for (int i = 0; i < this.staticObjects.Count; i++)
            {
                if (this.staticObjects[i] is Mario)
                {
                    this.staticObjects.RemoveAt(i);
                    i--;
                }
            }

            this.AddStaticObject(obj);
        }

        public virtual void MovePlayerLeft()
        {
            if (this.playerMario.MarioCol() != 0)
            {

                this.playerMario.MoveLeft();
            }
        }

        public virtual void MovePlayerRight()
        {
            if (this.playerMario.MarioCol() + this.playerMario.GetImage().GetLength(1) < this.WorldCols)
            {
                this.playerMario.MoveRight();
            }
        }

        public virtual void MovePlayerUp()
        {
            if (this.playerMario.MarioRow() != 0)
            {
                this.playerMario.MoveUp();
            }
        }

        public virtual void MovePlayerDown()
        {
            if (this.playerMario.MarioRow() + this.playerMario.GetImage().GetLength(0) < this.WorldRows)
            {
                this.playerMario.MoveDown();
            }
        }

        public virtual void Run()
        {
            while (true)
            {
                this.renderer.RenderAll();
                this.renderer.ClearQueue();
                
                this.userInterface.ProcessInput();
                
                foreach (var obj in this.allObjects)
                {
                    obj.Update();
                    this.renderer.EnqueueForRendering(obj);   
                }

                CollisionDispatcher.HandleCollisions(this.movingObjects, this.staticObjects);

                List<GameObject> producedObjects = new List<GameObject>();

                foreach (var obj in this.allObjects)
                {
                    producedObjects.AddRange(obj.ProduceObjects());
                }

                this.allObjects.RemoveAll(obj => obj.IsDestroyed);
                this.movingObjects.RemoveAll(obj => obj.IsDestroyed);
                this.staticObjects.RemoveAll(obj => obj.IsDestroyed);

                foreach (var obj in producedObjects)
                {
                    this.AddObject(obj);
                }

                Thread.Sleep(this.waitMs);
            }
        }
    }
}
