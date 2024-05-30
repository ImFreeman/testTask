using System;
using Features.DataSelector.Scripts.Interfaces;
using Features.SelectableDataContainer.Interfaces;

namespace Features.DataSelector.Scripts.Realization
{
    public class DataSelector<T> : IDisposable, IDataSelector<T> where T : ISelectableData
    {
        private readonly ISelectedObjectView<T> _view;
        private readonly ISelectableDataContainer<T> _selectableDataContainer;

        protected DataSelector(
            ISelectableDataContainer<T> selectableDataContainer,
            ISelectedObjectView<T> view)
        {
            _selectableDataContainer = selectableDataContainer;
            _view = view;

            _selectableDataContainer.OnDataChanged += OnDataChanged;
        }

        public void Select(T data)
        {
            _selectableDataContainer.CurrentData = data;
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