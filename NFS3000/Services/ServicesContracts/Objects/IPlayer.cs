namespace Services.ServicesContracts.Objects
{
    public interface IPlayer : IDrawable
    {
        string Name { get; set; }
        ICar Car { get; set; }
    }
}
