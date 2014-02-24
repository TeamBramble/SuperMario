using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario2
{
    interface IEnemy: IRenderable,ICollidable
    {
        char[,] GetMyBody();
    }
}
