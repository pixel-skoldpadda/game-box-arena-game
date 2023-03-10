using Infrastructure.DI;
using Infrastructure.States.Interfaces;

namespace Infrastructure.States
{
    public interface IGameStateMachine : IService
    {
        void Enter<TState>() where TState : class, IState;
        void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayLoadedState<TPayload>;
    }
}