using System;
using System.Collections.Generic;
using Features.DataSelector.Scripts.Realization;
using Features.Input.Scripts;
using Features.SelectableDataContainer.Interfaces;
using Features.SelectableDataContainer.Realization;

namespace Features.SceneSelection.Scripts
{
    public class InitSceneSelection : IDisposable
    {
        private readonly IDataSelector<SceneSelectionData> _selector;
        private readonly ISelectableDataContainer<SceneSelectionData> _container;

        private readonly SceneSelectionButtonsHandler _buttonsHandler;
        private readonly SceneSelectionScreenController _screenController;
        private readonly SceneSelectionInputHandler _inputHandler;

        public InitSceneSelection(
            Dictionary<string, SceneSelectionData> dataStorage,
            IUIService uiService, 
            IInput input)
        {
            _container = new SelectableDataContainer<SceneSelectionData>();
            _selector = new DataSelector<SceneSelectionData>(_container);

            _screenController = new SceneSelectionScreenController(uiService, _selector);
            var sceneSelectionContainer = new SceneSelectionContainerHandler(_container);
            _buttonsHandler =
                new SceneSelectionButtonsHandler(uiService, _selector, dataStorage, sceneSelectionContainer);
            _inputHandler = new SceneSelectionInputHandler(uiService, input, sceneSelectionContainer);
        }

        public void Dispose()
        {
            _selector.Dispose();
            _buttonsHandler.Dispose();
            _screenController.Dispose();
            _inputHandler.Dispose();
        }
    }
}