namespace Interfaces
{
    public interface IGameObjectEventListener<T>
    {
        void OnEventBroadcast(T eventPayload);
    }
}