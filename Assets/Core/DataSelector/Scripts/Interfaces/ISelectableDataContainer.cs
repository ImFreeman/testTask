using System;

namespace Core.DataSelector.Scripts.Interfaces
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