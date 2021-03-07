namespace Interfaces
{
    public interface IVarSetter<T>
    {
        void SetVarValue(T val);
        void ResetVarValue();
    }
}