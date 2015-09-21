using System;
using System.Collections.Generic;
using System.Linq;
using Services.Services.Objects;
using System.Threading.Tasks;

namespace Services.ServicesContracts.Objects
{
    interface ICar
    {
        string Name { get; set; }

        Engine Engine { get; set; }

        IUsable Usable { get; set; }
    }
}
