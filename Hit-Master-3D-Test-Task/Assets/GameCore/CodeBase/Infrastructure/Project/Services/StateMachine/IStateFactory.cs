namespace GameCore.CodeBase.Infrastructure.Project.Services.StateMachine
{
    public interface IStateFactory
    {
        public StateType Create<StateType>() where StateType : IState;
    }
}
