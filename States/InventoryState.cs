using GameStateMachine.Commands;
using GameStateMachine.GameObjects;
using GameStateMachine.Interfaces;


namespace GameStateMachine.States
{
    public class InventoryState : IState
    {
        private StateManager _manager;

        private IGame _game;
        private IState _lastState;
        int? myAge;


        public InventoryState(StateManager manager,IState lastState, IGame game)
        {
            _manager = manager;
            _game = game;
            _lastState = lastState;
        }

        public ICommand GetCommand()
        {

            var command = Console.ReadLine();
            var parts = command.Split(' ');

            if (parts.Length == 2 && parts[0] == "drop")
            {
                if (int.TryParse(parts[1], out int resultInInt))
                {
                    if (resultInInt < 0 || resultInInt > _game.Player.Inventory.Count)
                    {
                        Console.WriteLine("Invalid Item number!");
                    }
                    else
                    {
                        var item = _game.Player.Inventory[resultInInt - 1];
                        if (item != null)
                        {


                            return new DropItemCommand(_manager, item,_game.Player.CurrentRoom, _game);
                        }
                        else
                        {
                            Console.WriteLine("There is no item in this room");
                        }
                    }

                }
                else
                {
                    return new InvalidCommand();
                }
            }


            switch (command)
            {
                case "load":
                    return new SwitchStateCommand(_manager, new LoadGameState(_manager, this, _game));
                case "save":
                    return new SwitchStateCommand(_manager, new SaveGameState(_manager, this, _game));
                case "back":
                    return new SwitchStateCommand(_manager, _lastState);
                default:
                    return new InvalidCommand();

            }
        }

        public void Render()
        {
            Console.WriteLine("This is Your inventory");
            Console.WriteLine("----------------------");

            for (var i = 0; i < _game.Player.Inventory.Count; i++)
            {
                Console.WriteLine($"[ {i + 1} ] - {_game.Player.Inventory[i].Name}");
            }


            Console.WriteLine("You can choose whatever item to DROP! or type back to take back to the last state");
        }
    }
}
