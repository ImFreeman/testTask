using System;
using System.Collections.Generic;
using Features.DataSelector.Scripts.Realization;
using Features.Input.Scripts;
using Features.SelectableDataContainer.Interfaces;
using Features.SelectableDataContainer.Realization;

namespace Features.CharacterSelection.Scripts
{
    public class InitCharacterSelection : IDisposable
    {
        private readonly IDataSelector<SelectableCharacterData> _selector;
        private readonly ISelectableDataContainer<SelectableCharacterData> _selectableDataContainer;

        private readonly CharacterSelectionInputHandler _inputHandler;
        private readonly CharacterSelectionScreenController _screenController;
        private readonly CharacterSelectionButtonsHandler _buttonsHandler;

        public InitCharacterSelection(
            IUIService uiService,
            IInput input,
            SelectableCharacterView viewPrefab,
            Dictionary<string, SelectableCharacterData> dataStorage)
        {
            _selectableDataContainer = new SelectableDataContainer<SelectableCharacterData>();
            _selector = new DataSelector<SelectableCharacterData>(_selectableDataContainer);

            _inputHandler = new CharacterSelectionInputHandler(uiService, input);
            _screenController = new CharacterSelectionScreenController(uiService, viewPrefab, _selector);
            _buttonsHandler = new CharacterSelectionButtonsHandler(uiService, _selector, dataStorage);
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