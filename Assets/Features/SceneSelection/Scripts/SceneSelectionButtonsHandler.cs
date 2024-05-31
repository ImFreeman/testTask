using System;
using System.Collections.Generic;
using Features.DataSelector.Scripts.Interfaces;
using Features.UI.Scripts.Interfaces;

namespace Features.SceneSelection.Scripts
{
    public class SceneSelectionButtonsHandler : IDisposable
    {
        private readonly Dictionary<string, SceneSelectionData> _dataStorage;
        private readonly IUIService _uiService;
        private readonly IDataSelector<SceneSelectionData> _selector;
        private readonly SceneSelectionContainerHandler _sceneSelectionContainer;

        private bool _isShown;

        public SceneSelectionButtonsHandler(
            IUIService uiService,
            IDataSelector<SceneSelectionData> selector,
            Dictionary<string, SceneSelectionData> dataStorage,
            SceneSelectionContainerHandler sceneSelectionContainer)
        {
            _uiService = uiService;
            _selector = selector;
            _dataStorage = dataStorage;
            _sceneSelectionContainer = sceneSelectionContainer;

            _uiService.WindowShown += OnWindowShown;
            _uiService.WindowHided += OnWindowHiden;
        }
        
        public void Dispose()
        {
            _sceneSelectionContainer.UnloadCurrentScene();
            if (_isShown)
            {
                if (_uiService.Get<SceneSelectionWindowView>(out var window))
                {
                    window.SceneButtonPressed -= OnSceneButtonPressed;
                    window.LoadSceneButtonPressed -= OnLoadSceneButtonPressed;
                }
            }
            _uiService.WindowShown -= OnWindowShown;
            _uiService.WindowHided -= OnWindowHiden;
        }

        private void OnWindowShown(object sender, Type e)
        {
            if (e == typeof(SceneSelectionWindowView))
            {
                if (_uiService.Get<SceneSelectionWindowView>(out var window))
                {
                    window.SceneButtonPressed += OnSceneButtonPressed;
                    window.LoadSceneButtonPressed += OnLoadSceneButtonPressed;
                    _isShown = true;
                }
            }
        }

        private void OnLoadSceneButtonPressed(object sender, EventArgs e)
        {
            _sceneSelectionContainer.LoadSelectedScene();
        }

        private void OnSceneButtonPressed(object sender, string e)
        {
            if (_dataStorage.TryGetValue(e, out var data))
            {
                _selector.Select(data);
            }
        }

        private void OnWindowHiden(object sender, Type e)
        {
            if (e == typeof(SceneSelectionWindowView))
            {
                if (_uiService.Get<SceneSelectionWindowView>(out var window))
                {
                    window.SceneButtonPressed -= OnSceneButtonPressed;
                    window.LoadSceneButtonPressed -= OnLoadSceneButtonPressed;
                    _isShown = false;
                }
            }
        }
    }
}