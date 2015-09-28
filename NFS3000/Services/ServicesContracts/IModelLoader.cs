using System.Collections.Generic;

using Services.Services.Objects;

namespace Services.ServicesContracts
{
    public interface IModelLoader
    {
        IDictionary<Coordinates, char> LoadModel(string file);
    }
}
