using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ServicesContracts.Objects
{
    public interface IMoveable
    {
        void MoveLeft();
        void MoveRight();
        void MoveUp();
        void MoveDown();
    }
}
