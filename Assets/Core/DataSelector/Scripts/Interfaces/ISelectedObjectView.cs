namespace Core.DataSelector.Scripts.Interfaces
{
    public interface ISelectedObjectView<T> where T : ISelectableData
    {
        public void UpdateView(T data);
    }
}