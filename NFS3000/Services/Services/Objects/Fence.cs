using System;
using System.Collections.Generic;
using Data;
using Services.Services.Objects.Singletons;
using Services.ServicesContracts;
using Services.ServicesContracts.Objects;

namespace Services.Services.Objects
{
    public class Fence : AIObject, IFence
    {
        public Fence(int position, int width)
        {
            var c = new Dictionary<Coordinates, char>();
            RequeredTicksToMove = 5;
            for (int i = 0; i < Globals.Y_MAX_BOARD_SIZE; i++)
            {
                char val = i%3 == 1 ? Globals.BACKGROUND_DEFAULT_VALUE : '|';
                for (int j = 0; j < width; j++)
                {
                    c.Add(new Coordinates(j, i), val);
                }
                
            }
            Position = new Coordinates(position, 0);
            Content = c;
        }
        public override void Move()
        {
            CurrentTick++;
            if (CurrentTick == 0)
            {
                Ui.Instance().RequireScreenUpdate();
                foreach (var cell in Content)
                {
                    cell.Key.Y = (cell.Key.Y + 1) % Globals.Y_MAX_BOARD_SIZE;
                }
            }
            //throw new NotImplementedException();
        }

        public Coordinates Position { get; private set; }
        public int Priority { get; private set; }
        public IDictionary<Coordinates, char> Content { get; private set; }
        public bool ShouldBeDrawn(int screenTop, int screenBottom)
        {
            return true;
        }
    }
}
