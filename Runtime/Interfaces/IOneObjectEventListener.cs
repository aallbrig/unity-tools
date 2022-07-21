namespace Interfaces
{
    public interface IOneObjectEventListener<T>
    {
        void OnEventBroadcast(T eventPayload);
    }
}