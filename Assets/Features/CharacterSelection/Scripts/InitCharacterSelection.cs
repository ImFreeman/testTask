using System;
using System.Collections.Generic;
using Features.DataSelector.Scripts.Realization;
using Features.Input.Scripts;
using Features.SelectableDataContainer.Interfaces;

namespace Features.CharacterSelection.Scripts
{
    public class InitCharacterSelection : IDisposable
    {
        private readonly IUIService _uiService;
        private readonly IInput _input;
        private readonly IDataSelector<SelectableCharacterData> _selector;
        private readonly SelectableCharacterView _viewPrefab;
        private readonly ISelectableDataContainer<SelectableCharacterData> _selectableDataContainer;
        private readonly Dictionary<string, SelectableCharacterData> _dataStorage;

        private readonly CharacterSelectionInputHandler _inputHandler;
        private readonly CharacterSelectionScreenController _screenController;
        private readonly CharacterSelectionButtonsHandler _buttonsHandler;

        public InitCharacterSelection(
            IUIService uiService,
            IInput input,
            SelectableCharacterView viewPrefab,
            ISelectableDataContainer<SelectableCharacterData> selectableDataContainer, Dictionary<string, SelectableCharacterData> dataStorage)
        {
            _uiService = uiService;
            _input = input;
            _viewPrefab = viewPrefab;
            _selectableDataContainer = selectableDataContainer;
            _dataStorage = dataStorage;

            _selector = new DataSelector<SelectableCharacterData>(_selectableDataContainer);

            _inputHandler = new CharacterSelectionInputHandler(_uiService, _input);
            _screenController = new CharacterSelectionScreenController(_uiService, _viewPrefab, _selector);
            _buttonsHandler = new CharacterSelectionButtonsHandler(_uiService, _selector, dataStorage);
        }

        public void Dispose()
        {
            _inputHandler.Dispose();
            _screenController.Dispose();
            _buttonsHandler.Dispose();
            _selector.Dispose();
        }
    }
}