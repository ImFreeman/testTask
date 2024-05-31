using Core.DataSelector.Scripts.Interfaces;
using UnityEngine.SceneManagement;

namespace Sample.Features.SceneSelection.Scripts
{
    public class SceneSelectionContainerHandler
    {
        private readonly ISelectableDataContainer<SceneSelectionData> _container;
        
        private int _currentLoadedScene = -1;

        public SceneSelectionContainerHandler(ISelectableDataContainer<SceneSelectionData> container)
        {
            _container = container;
        }

        public void LoadSelectedScene()
        {
            if (_container.CurrentData != null)
            {
                if (_currentLoadedScene != -1)
                {
                    SceneManager.UnloadSceneAsync(_currentLoadedScene);
                }

                _currentLoadedScene = _container.CurrentData.SceneId;
                SceneManager.LoadScene(_currentLoadedScene, LoadSceneMode.Additive);
            }
        }

        public void UnloadCurrentScene()
        {
            if (_currentLoadedScene != -1)
            {
                SceneManager.UnloadSceneAsync(_currentLoadedScene);
                _currentLoadedScene = -1;
            }
        }
    }
}