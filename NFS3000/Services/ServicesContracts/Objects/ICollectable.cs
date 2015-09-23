namespace Services.ServicesContracts.Objects
{
    public interface ICollectable : IDrawable
    {
        /// <summary>
        /// Creates new object.
        /// </summary>
        /// <returns>Returns either negative or positive item (example Obsticle or Nitro)</returns>
        IItem Collect();
    }
}
