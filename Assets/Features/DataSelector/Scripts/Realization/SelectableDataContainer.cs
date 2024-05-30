using System;
using Features.DataSelector.Scripts.Interfaces;
using Features.SelectableDataContainer.Interfaces;

namespace Features.SelectableDataContainer.Realization
{
    public class SelectableDataContainer<T> : ISelectableDataContainer<T> where T : ISelectableData
    {
        private T _data;
        public T CurrentData
        {
            get => _data;
            set
            {
                _data = value;
                OnDataChanged?.Invoke(this, _data);
            }
        }
        public event EventHandler<T> OnDataChanged;
    }
}