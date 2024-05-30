using System;
using Features.DataSelector.Scripts.Interfaces;
using Features.UI.Scripts.Realization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Features.SceneSelection.Scripts
{
    public class SceneSelectionWindowView : UIBaseWindow, ISelectedObjectView<SceneSelectionData>
    {
        
        [SerializeField] private CharacterButtonData[] _buttons;
        [SerializeField] private Button _loadSceneButton;
        
        [SerializeField] private TMP_Text _nameText;
        [SerializeField] private TMP_Text _descriptionText;
        [SerializeField] private Image _sceneImage;
        
        public CharacterButtonData[] Buttons => _buttons;

        public event EventHandler<string> SceneButtonPressed;
        public event EventHandler LoadSceneButtonPressed;

        protected override void OnShow()
        {
            foreach (var button in _buttons)
            {
                button.Button.onClick.AddListener(() =>
                {
                    SceneButtonPressed?.Invoke(this, button.SceneID);
                });
            }

            _loadSceneButton.onClick.AddListener(() =>
            {
                LoadSceneButtonPressed?.Invoke(this, EventArgs.Empty);
            });
        }

        protected override void OnHide()
        {
            foreach (var button in _buttons)
            {
                button.Button.onClick.RemoveAllListeners();
            }
            _loadSceneButton.onClick.RemoveAllListeners();
        }
    
        [Serializable]
        public struct CharacterButtonData
        {
            public Button Button;
            public string SceneID;
        }

        public void UpdateView(SceneSelectionData data)
        {
            _nameText.text = data.Name;
            _descriptionText.text = data.Description;
            _sceneImage.sprite = data.SpriteArt;
        }
    }
}