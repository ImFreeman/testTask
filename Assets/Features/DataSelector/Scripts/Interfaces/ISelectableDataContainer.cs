using System;
using Features.DataSelector.Scripts.Interfaces;

namespace Features.SelectableDataContainer.Interfaces
{
    public interface ISelectableDataContainer<T> where T : ISelectableData
    {
        public T CurrentData
        {
            get;
            set;
        }

        public event EventHandler<T> OnDataChanged;
    }
}