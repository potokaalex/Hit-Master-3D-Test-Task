namespace GameCore.CodeBase.Gameplay
{
    public interface IInteractableWith<in T>
    {
        public void Interact(T t);
    }
}