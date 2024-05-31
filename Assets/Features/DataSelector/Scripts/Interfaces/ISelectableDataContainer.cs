using System;

namespace Features.DataSelector.Scripts.Interfaces
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