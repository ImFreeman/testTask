using System;
using Core.DataSelector.Scripts.Interfaces;
using Sample.Features.UI.Scripts.Realization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Sample.Features.SceneSelection.Scripts
{
    public class SceneSelectionWindowView : UIBaseWindow, ISelectedObjectView<SceneSelectionData>
    {
        public CharacterButtonData[] Buttons => _buttons;
        public event EventHandler<string> SceneButtonPressed;
        public event EventHandler LoadSceneButtonPressed;
        
        [SerializeField] private CharacterButtonData[] _buttons;
        [SerializeField] private Button _loadSceneButton;
        [SerializeField] private TMP_Text _nameText;
        [SerializeField] private TMP_Text _descriptionText;
        [SerializeField] private Image _sceneImage;

        public void UpdateView(SceneSelectionData data)
        {
            _nameText.text = data.Name;
            _descriptionText.text = data.Description;
            _sceneImage.sprite = data.SpriteArt;
        }
        
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
    }
}