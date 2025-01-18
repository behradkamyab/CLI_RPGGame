

using GameStateMachine.Interfaces;

namespace GameStateMachine.States
{
    public class StateManager
    {
        private IState _state;

        public void SwitchState(IState state)
        {
            _state = state;
        }

        public void Run(IState initialState)
        {
            _state = initialState;
            while (true)
            {
                _state.Render();
                var command = _state.GetCommand();
                command.Execute();
            }
        }
    }
}
