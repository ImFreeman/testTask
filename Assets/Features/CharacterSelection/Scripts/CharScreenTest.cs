using System;
using System.Collections.Generic;
using Features.Input.Scripts;
using Features.SelectableDataContainer.Interfaces;
using Features.SelectableDataContainer.Realization;
using Features.UI.Scripts.Realization;
using Unity.VisualScripting;
using UnityEngine;

namespace Features.CharacterSelection.Scripts
{
    public class CharScreenTest : MonoBehaviour
    {
        [SerializeField] private UIRoot _uiRoot;
        [SerializeField] private KeyboardInput _input;
        [SerializeField] private SelectableCharacterView _prefab;
        private ISelectableDataContainer<SelectableCharacterData> _selectableDataContainer;
        private UIService _uiService;

        [SerializeField] private SelectableCharacterData[] _data;

        private InitCharacterSelection _init;
        private void Awake()
        {
            _uiService = new UIService(_uiRoot);
            _uiService.LoadWindows();
            _selectableDataContainer = new SelectableDataContainer<SelectableCharacterData>();
        }

        private void Update()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.Alpha1))
            {
                var dict = new Dictionary<string, SelectableCharacterData>();
                foreach (var data in _data)
                {
                    dict.Add(data.ID, data);
                }
                _init = new InitCharacterSelection(_uiService, _input, _prefab, _selectableDataContainer, dict);
            }

            if (UnityEngine.Input.GetKeyDown(KeyCode.Alpha2))
            {
                _uiService.Show<CharacterSelectionWindowView>();
            }
            
            if (UnityEngine.Input.GetKeyDown(KeyCode.Alpha3))
            {
                _uiService.Hide<CharacterSelectionWindowView>();
            }

            if (UnityEngine.Input.GetKeyDown(KeyCode.Alpha4))
            {
                _init.Dispose();
            }
        }
    }
}