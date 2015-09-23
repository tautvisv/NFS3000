namespace Services.ServicesContracts.Objects
{
    public interface IPlayer
    {
        string Name { get; set; }
        ICar Car { get; set; }
    }
}
