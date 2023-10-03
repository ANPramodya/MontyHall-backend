namespace MontyHall.Models
{
    public class MontyHallSimulationResult
    {
        public int GameId { get; set; }
        public int PrizeDoor { get; set; }
        public int PlayerInitialChoice { get; set; }
        public int HostOpenedDoor { get; set; }
        public bool PlayerSwitched { get; set; }
        public bool PlayerWon { get; set; }
    }
}
