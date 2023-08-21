namespace GameCore.CodeBase.Infrastructure.Project.Services.StateMachine
{
    public interface IStateMachine
    {
        public void SwitchTo<StateType>()
            where StateType : IState;
    }
}