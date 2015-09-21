using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ServicesContracts.Objects
{
    interface IUsable : IItem
    {
        int Count { get; }

        void Use();

        void Add();
    }
}
