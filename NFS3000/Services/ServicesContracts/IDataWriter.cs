namespace Services.ServicesContracts
{
    interface IDataWriter
    {
        void Write(object obj);
        string[] Read();
    }
}
