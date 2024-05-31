using System;
using Features.DataSelector.Scripts.Interfaces;

namespace Features.DataSelector.Scripts.Realization
{
    public class SelectableDataContainer<T> : ISelectableDataContainer<T> where T : ISelectableData
    {
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
        
        private T _data;
    }
}