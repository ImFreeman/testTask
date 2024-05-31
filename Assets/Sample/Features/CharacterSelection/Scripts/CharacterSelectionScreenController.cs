using System;
using Core.DataSelector.Scripts.Interfaces;
using Sample.Features.UI.Scripts.Interfaces;
using Object = UnityEngine.Object;

namespace Sample.Features.CharacterSelection.Scripts
{
    public class CharacterSelectionScreenController : IDisposable
    {
        private readonly IUIService _uiService;
        private readonly IDataSelector<SelectableCharacterData> _selector;
        private readonly SelectableCharacterView _viewPrefab;

        private SelectableCharacterView _currentView;

        public CharacterSelectionScreenController(
            IUIService uiService,
            SelectableCharacterView viewPrefab,
            IDataSelector<SelectableCharacterData> selector)
        {
            _uiService = uiService;
            _viewPrefab = viewPrefab;
            _selector = selector;
            _uiService.WindowShown += OnWindowShown;
            _uiService.WindowHided += OnWindowHiden;
        }
        
        public void Dispose()
        {
            _uiService.WindowShown -= OnWindowShown;
            _uiService.WindowHided -= OnWindowHiden;
        }
        
        private void OnWindowShown(object sender, Type e)
        {
            if (e == typeof(CharacterSelectionWindowView))
            {
                _currentView = Object.Instantiate(_viewPrefab);
                if (_uiService.Get<CharacterSelectionWindowView>(out var window))
                {
                    _currentView.SetWindow(window);
                }
                _selector.SetView(_currentView);
            }
        }
        
        private void OnWindowHiden(object sender, Type e)
        {
            if (e == typeof(CharacterSelectionWindowView))
            {
                Object.Destroy(_currentView.gameObject);
            }
        }
    }
}