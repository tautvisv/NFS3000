using System;
using System.Collections.Generic;

using Services.Services.Objects;

namespace Services.Trash
{
    [Serializable]
    public class MapObjects
    {
        public MapObjects(string classType)
        {
            ClassType = classType;
            Positions = new List<Coordinates>();
        }

        public readonly string ClassType;
        public IList<Coordinates> Positions { get; private set; }
    }

    [Serializable]
    public class MapStructure
    {
        public MapStructure()
        {
            map = new List<MapObjects>();
        }

        public int MapLength { get; set; }
        public int MapWidth { get; set; }
        public IList<MapObjects> map;

    }
}
