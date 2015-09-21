namespace Services.ServicesContracts.Objects
{
    interface IUsable : IItem
    {
        int Count { get; }

        void Use();

        void Add();
    }
}
