using MontyHall.Models;

namespace MontyHall.Services
{

    public interface ISimulationService 
    {
        List<MontyHallSimulationResult> GenerateSimulation(int noOfGames, bool switchDoors);
    }


    public class SimulationService : ISimulationService
    {
        private static readonly Random random = new Random();
        public List<MontyHallSimulationResult> GenerateSimulation(int noOfGames, bool switchDoors)
        {
        List<MontyHallSimulationResult> simulationResult = new List<MontyHallSimulationResult>();

            for (int i = 0; i < noOfGames; i++) 
            {
                MontyHallSimulationResult result = new MontyHallSimulationResult
                {
                    GameId = i,
                    PrizeDoor = RandomPick(),
                    PlayerInitialChoice = RandomPick(),
                    PlayerSwitched = switchDoors,
                    
                };
                result.HostOpenedDoor = HostChoice(result.PrizeDoor, result.PlayerInitialChoice);
                result.PlayerWon = PlayerWonOrNot(result.PlayerInitialChoice, result.PrizeDoor, result.PlayerSwitched);
                simulationResult.Add(result);
            }   

            return simulationResult;
        }

        //for the PrizeDoor, Player InitialChoice
        public int RandomPick() 
        {
            return random.Next(1, 4);
        }

        //for Host Choice
        public int HostChoice(int prizeDoor, int initialDoor) 
        {
            if (initialDoor == prizeDoor)
            {
                int randomValue;
                do 
                {
                    randomValue = random.Next(1, 4);
                }
                while (randomValue == prizeDoor);

                return randomValue;//have 2 choices
            }
            else {

                if (prizeDoor != 1 && initialDoor != 1)
                {
                    return 1;
                }
                else if (prizeDoor != 2 && initialDoor != 2) 
                {
                    return 2;
                } else 
                    return 3;

                
            }
            
        }

        //check player won or not
        public bool PlayerWonOrNot(int initialDoor, int prizeDoor, bool switched) 
        {
            if (initialDoor == prizeDoor && !switched)
            {
                return true;
            }
            else if (initialDoor  != prizeDoor && switched)
            { 
                return true;
            }
            else {

                return false;
            }
            
        }


    }
}
