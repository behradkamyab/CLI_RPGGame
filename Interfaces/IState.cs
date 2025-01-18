
namespace GameStateMachine.Interfaces
{
    public interface IState
    {
        void Render();
        ICommand GetCommand();
    }
}
