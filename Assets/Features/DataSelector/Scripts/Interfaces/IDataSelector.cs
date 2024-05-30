using Features.DataSelector.Scripts.Interfaces;

public interface IDataSelector<T> where T : ISelectableData
{
    public void Select(T data);
}
