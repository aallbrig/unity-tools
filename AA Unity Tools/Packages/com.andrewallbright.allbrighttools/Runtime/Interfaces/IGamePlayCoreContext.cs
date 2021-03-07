namespace Interfaces
{
    public interface IFiniteStateMachineContext<TState> where TState : IState
    {
        TState CurrentState { get; set; }

        void TransitionToState(TState state);
    }
}