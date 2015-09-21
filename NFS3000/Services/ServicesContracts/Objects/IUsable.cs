using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ServicesContracts.Objects
{
    interface IUsable : IItem
    {
        int Count { get; private set; }

        void Use();

        void Add();
    }
}
