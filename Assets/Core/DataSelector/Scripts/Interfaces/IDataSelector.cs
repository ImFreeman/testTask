using System;

namespace Core.DataSelector.Scripts.Interfaces
{
    public interface IDataSelector<T> : IDisposable where T : ISelectableData
    {
        public void Select(T data);
        public void SetView(ISelectedObjectView<T> view);
    }
}