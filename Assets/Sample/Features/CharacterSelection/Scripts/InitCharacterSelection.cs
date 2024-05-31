using System;
using System.Collections.Generic;
using Core.DataSelector.Scripts.Interfaces;
using Core.DataSelector.Scripts.Realization;
using Sample.Features.Input.Scripts.Interfaces;
using Sample.Features.UI.Scripts.Interfaces;

namespace Sample.Features.CharacterSelection.Scripts
{
    public class InitCharacterSelection : IDisposable
    {
        private readonly IDataSelector<SelectableCharacterData> _selector;

        private readonly CharacterSelectionInputHandler _inputHandler;
        private readonly CharacterSelectionScreenController _screenController;
        private readonly CharacterSelectionButtonsHandler _buttonsHandler;

        public InitCharacterSelection(
            IUIService uiService,
            IInput input,
            SelectableCharacterView viewPrefab,
            Dictionary<string, SelectableCharacterData> dataStorage)
        {
            ISelectableDataContainer<SelectableCharacterData> selectableDataContainer = new SelectableDataContainer<SelectableCharacterData>();
            _selector = new DataSelector<SelectableCharacterData>(selectableDataContainer);

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