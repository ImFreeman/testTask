using System;
using System.Collections.Generic;
using Features.DataSelector.Scripts.Realization;
using Features.Input.Scripts;
using Features.SelectableDataContainer.Interfaces;

namespace Features.SceneSelection.Scripts
{
    public class InitSceneSelection : IDisposable
    {
        private readonly Dictionary<string, SceneSelectionData> _dataStorage;
        private readonly IUIService _uiService;
        private readonly IDataSelector<SceneSelectionData> _selector;
        private readonly ISelectableDataContainer<SceneSelectionData> _container;
        
        private readonly SceneSelectionContainerHandler _sceneSelectionContainer;
        private readonly SceneSelectionButtonsHandler _buttonsHandler;
        private readonly SceneSelectionScreenController _screenController;
        private readonly SceneSelectionInputHandler _inputHandler;

        public InitSceneSelection(
            Dictionary<string, SceneSelectionData> dataStorage,
            IUIService uiService, 
            ISelectableDataContainer<SceneSelectionData> container,
            IInput input)
        {
            _dataStorage = dataStorage;
            _uiService = uiService;
            _container = container;
            
            _selector = new DataSelector<SceneSelectionData>(_container);

            _screenController = new SceneSelectionScreenController(_uiService, _selector);
            _sceneSelectionContainer = new SceneSelectionContainerHandler(_container);
            _buttonsHandler =
                new SceneSelectionButtonsHandler(_uiService, _selector, dataStorage, _sceneSelectionContainer);
            _inputHandler = new SceneSelectionInputHandler(_uiService, input, _sceneSelectionContainer);
        }

        public void Dispose()
        {
            _selector?.Dispose();
            _buttonsHandler?.Dispose();
            _screenController?.Dispose();
            _inputHandler?.Dispose();
        }
    }
}