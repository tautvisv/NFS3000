using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ServicesContracts.Objects
{
    interface IPlayer
    {
        string Name { get; set; }
        ICar Car { get; set; }
    }
}
