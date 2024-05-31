using System;
using System.Collections.Generic;
using Features.DataSelector.Scripts.Interfaces;
using Features.UI.Scripts.Interfaces;

namespace Features.CharacterSelection.Scripts
{
    public class CharacterSelectionButtonsHandler : IDisposable
    {
        private readonly Dictionary<string, SelectableCharacterData> _dataStorage;
        private readonly IUIService _uiService;
        private readonly IDataSelector<SelectableCharacterData> _selector;

        public CharacterSelectionButtonsHandler(
            IUIService uiService,
            IDataSelector<SelectableCharacterData> selector, Dictionary<string, SelectableCharacterData> dataStorage)
        {
            _uiService = uiService;
            _selector = selector;
            _dataStorage = dataStorage;

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
                if (_uiService.Get<CharacterSelectionWindowView>(out var window))
                {
                    window.CharacterButtonPressed += OnCharacterButtonPressed;
                }
            }
        }

        private void OnCharacterButtonPressed(object sender, string e)
        {
            if (_dataStorage.TryGetValue(e, out var data))
            {
                _selector.Select(data);
            }
        }

        private void OnWindowHiden(object sender, Type e)
        {
            if (e == typeof(CharacterSelectionWindowView))
            {
                if (_uiService.Get<CharacterSelectionWindowView>(out var window))
                {
                    window.CharacterButtonPressed -= OnCharacterButtonPressed;
                }
            }
        }
    }
}