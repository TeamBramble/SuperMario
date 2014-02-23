namespace SuperMario2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public interface IObjectProducer
    {
        IEnumerable<GameObject> ProduceObjects();
    }
}
