using System;
using Core.DataSelector.Scripts.Interfaces;

namespace Core.DataSelector.Scripts.Realization
{
    public class DataSelector<T> : IDisposable, IDataSelector<T> where T : ISelectableData
    {
        private readonly ISelectableDataContainer<T> _selectableDataContainer;
        
        private ISelectedObjectView<T> _view;

        public DataSelector(
            ISelectableDataContainer<T> selectableDataContainer)
        {
            _selectableDataContainer = selectableDataContainer;

            _selectableDataContainer.OnDataChanged += OnDataChanged;
        }

        public void Select(T data)
        {
            _selectableDataContainer.CurrentData = data;
        }

        public void SetView(ISelectedObjectView<T> view)
        {
            _view = view;
        }

        public void Dispose()
        {
            _selectableDataContainer.OnDataChanged -= OnDataChanged;
        }

        private void UpdateView(T data)
        {
            _view.UpdateView(data);
        }
        
        private void OnDataChanged(object sender, T e)
        {
            UpdateView(e);
        }
    }
}