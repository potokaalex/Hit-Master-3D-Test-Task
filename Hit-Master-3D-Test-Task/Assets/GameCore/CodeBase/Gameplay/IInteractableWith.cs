namespace GameCore.CodeBase.Gameplay.Player
{
    public interface IInteractableWith<in T>
    {
        public void Interact(T t);
    }
}