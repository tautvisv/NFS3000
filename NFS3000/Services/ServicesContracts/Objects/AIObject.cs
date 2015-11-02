namespace Services.ServicesContracts.Objects
{
    public abstract class AIObject : IMove
    {
        private int currentTick;
        protected int RequeredTicksToMove { get; set; }

        protected int CurrentTick
        {
            get { return currentTick; }
            set { currentTick = value % RequeredTicksToMove; }
        }

        public abstract void Move();
    }
}
