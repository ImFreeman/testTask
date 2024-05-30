using System;
using System.Collections.Generic;
using Features.CharacterSelection.Scripts;
using Features.Input.Scripts;
using Features.SelectableDataContainer.Interfaces;
using Features.SelectableDataContainer.Realization;
using Features.UI.Scripts.Realization;
using UnityEngine;

namespace Features.SceneSelection.Scripts
{
    public class SceneSelectTest : MonoBehaviour
    {
        [SerializeField] private UIRoot _uiRoot;
        [SerializeField] private KeyboardInput _input;
        private ISelectableDataContainer<SceneSelectionData> _selectableDataContainer;
        private UIService _uiService;
        
        [SerializeField] private SceneSelectionData[] _data;

        private InitSceneSelection _init;
        private void Awake()
        {
            _uiService = new UIService(_uiRoot);
            _uiService.LoadWindows();

            _selectableDataContainer = new SelectableDataContainer<SceneSelectionData>();
        }
        
        private void Update()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.Alpha1))
            {
                var dict = new Dictionary<string, SceneSelectionData>();
                foreach (var data in _data)
                {
                    dict.Add(data.ID, data);
                }
                _init = new InitSceneSelection(dict, _uiService, _selectableDataContainer, _input);
            }

            if (UnityEngine.Input.GetKeyDown(KeyCode.Alpha2))
            {
                _uiService.Show<SceneSelectionWindowView>();
            }
            
            if (UnityEngine.Input.GetKeyDown(KeyCode.Alpha3))
            {
                _uiService.Hide<SceneSelectionWindowView>();
            }

            if (UnityEngine.Input.GetKeyDown(KeyCode.Alpha4))
            {
                _init.Dispose();
            }
        }
    }
}