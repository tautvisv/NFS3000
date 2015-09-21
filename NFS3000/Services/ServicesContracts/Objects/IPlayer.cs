namespace Services.ServicesContracts.Objects
{
    interface IPlayer
    {
        string Name { get; set; }
        ICar Car { get; set; }
    }
}
