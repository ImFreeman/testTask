using System.Collections.Generic;
using Sample.Features.CharacterSelection.Scripts;
using Sample.Features.Input.Scripts.Realization;
using Sample.Features.SceneSelection.Scripts;
using Sample.Features.StartScreen.Scripts;
using Sample.Features.UI.Scripts.Interfaces;
using Sample.Features.UI.Scripts.Realization;
using UnityEngine;

namespace Sample.Features.Core.Scripts
{
    public class ApplicationStartUp : MonoBehaviour
    {
        [SerializeField] private UIRoot _uiRoot;
        [SerializeField] private KeyboardInput _input;
        [SerializeField] private SceneSelectionData[] _sceneData;
        [SerializeField] private SelectableCharacterData[] _selectableCharacterDatas;
        [SerializeField] private SelectableCharacterView _prefab;
    
        private IUIService _uiService;
    
        private InitSceneSelection _initSceneSelection;
        private InitCharacterSelection _initCharacterSelection;

        private StartScreenController _startScreenController;
    
        private void Awake()
        {
            _uiService = new UIService(_uiRoot);
            _uiService.LoadWindows();
        
            var sceneDict = new Dictionary<string, SceneSelectionData>();
            foreach (var sceneSelectionData in _sceneData)
            {
                sceneDict.TryAdd(sceneSelectionData.ID, sceneSelectionData);
            }

            _initSceneSelection = new InitSceneSelection(sceneDict, _uiService, _input);

            var charDict = new Dictionary<string, SelectableCharacterData>();
            foreach (var characterData in _selectableCharacterDatas)
            {
                charDict.TryAdd(characterData.ID, characterData);
            }

            _initCharacterSelection = new InitCharacterSelection(_uiService, _input, _prefab, charDict);

            _startScreenController = new StartScreenController(_uiService);
        }

        private void Start()
        {
            _uiService.Show<StartScreenWindow>();
        }

        private void OnDestroy()
        {
            _startScreenController.Dispose();
            _initCharacterSelection.Dispose();
            _initSceneSelection.Dispose();
            _uiService.Dispose();
        }
    }
}
