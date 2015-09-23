namespace Services.ServicesContracts.Objects
{
    public interface IUsable : IItem
    {
        int Count { get; }

        void Use();

        void Add();
    }
}
