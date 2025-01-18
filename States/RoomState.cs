using GameStateMachine.Commands;
using GameStateMachine.GameObjects;
using GameStateMachine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStateMachine.States
{
    public class RoomState : IState
    {
        private StateManager _manager;

        private IGame _game;
        private Room _room;
        private IState _lastState;

        public RoomState(StateManager manager,IState lastState  , IGame game, Room room)
        {
            _manager = manager;
            _game = game;
            _room = room;
            _lastState = lastState;
        }
        public ICommand GetCommand()
        {
            var command = Console.ReadLine();
            var parts = command.Split(' ');


            if(parts.Length == 2 && parts[0] == "move")
            {
                var room = _room.GetConnectedRoom(parts[1]);
                if(room != null)
                {
                    return new MoveRoomCommand(_manager, this,parts[1], room ,_game);
                }
            }

            if(parts.Length == 2 && parts[0] == "use")
            {

                if(int.TryParse(parts[1], out int resultInInt) )
                {
                    if(resultInInt < 0 || resultInInt > _room.Items.Count)
                    {
                       Console.WriteLine("Invalid Item number!");
                    }
                    else
                    {
                        var item = _room.Items[resultInInt - 1];
                        if (item != null)
                        {
                            return new UseItemCommand(_manager, item, _game);
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


            if(parts.Length == 2 && parts[0] == "pick")
            {
                if (int.TryParse(parts[1], out int resultInInt))
                {
                    if (resultInInt < 0 || resultInInt > _room.Items.Count)
                    {
                        Console.WriteLine("Invalid Item number!");
                    }
                    else
                    {
                        var item = _room.Items[resultInInt - 1] as IPickupable;
                        if (item != null)
                        {
                            return new PickupItemCommand(_manager,item,_room , _game);
                        }
                        else
                        {
                            Console.WriteLine("You cannot pick this Item!");
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
                    return new SwitchStateCommand(_manager, new LoadGameState(_manager , this , _game));
                case "save":
                    return new SwitchStateCommand(_manager, new SaveGameState(_manager , this , _game));

                case "inventory":
                    return new SwitchStateCommand(_manager, new InventoryState(_manager, this, _game));
                default:
                    return new InvalidCommand();

            }
        }

        public void Render()
        {

            Console.WriteLine(_room.Description);

            Console.WriteLine("Connected Rooms");
            Console.WriteLine("----------------");

            foreach(var connection in _room.Connections)
            {
                Console.WriteLine("[{0}] - {1}" , connection.Direction , connection.Room.Name );
            }

            Console.WriteLine("---------------");
            Console.WriteLine("Room Items");


            for (var i = 0; i < _room.Items.Count; i++)
            {
                var item = _room.Items[i] as IPickupable;
                if(item != null)
                {
                    Console.WriteLine($"[ {i + 1} ] - {_room.Items[i].Name}, you can PICK it");
                }
                else
                {
                    Console.WriteLine($"[ {i + 1} ] - {_room.Items[i].Name}");
                };

            }

            Console.WriteLine("-------------------");

            Console.WriteLine("[load] - load game");
            Console.WriteLine("[save] - save game");
            Console.WriteLine("[inventory] - Your Inventory!");

        }
    }
}
