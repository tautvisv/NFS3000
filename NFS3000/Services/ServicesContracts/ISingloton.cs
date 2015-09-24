using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ServicesContracts
{
    public interface ISingloton<T>
    {
        T GetInstance();
    }
}
