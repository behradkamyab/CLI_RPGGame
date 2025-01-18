using GameStateMachine.GameObjects;
using GameStateMachine.Interfaces;
using GameStateMachine.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStateMachine.Commands
{
    public class MoveRoomCommand : ICommand
    {
        private StateManager _manager;
        private string _direction;
        private Room _room;
        private IGame _game;
        private IState _lastState;
        public MoveRoomCommand  (StateManager manager , IState lastState,string direction , Room room , IGame game)
        {
            _manager = manager;
            _direction = direction;
            _room = room;
            _game = game;
        }
        public void Execute()
        {
            _game.Player.CurrentRoom = _room;
            _manager.SwitchState(new RoomState(_manager, _lastState, _game, _room));
        }
    }
}
