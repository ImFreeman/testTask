using System;
using Features.UI.Scripts.Realization;
using UnityEngine;
using UnityEngine.UI;

namespace Features.StartScreen.Scripts
{
    public class StartScreenWindow : UIBaseWindow
    {
        public event EventHandler CharacterButtonPressed;
        public event EventHandler ScenesButtonPressed;
        
        [SerializeField] private Button _characterButton;
        [SerializeField] private Button _scenesButton;
    
        protected override void OnShow()
        {
            _characterButton.onClick.AddListener(() =>
            {
                CharacterButtonPressed?.Invoke(this, EventArgs.Empty);
            });
            _scenesButton.onClick.AddListener(() =>
            {
                ScenesButtonPressed?.Invoke(this, EventArgs.Empty);
            });
        }

        protected override void OnHide()
        {
            _characterButton.onClick.RemoveAllListeners();
            _scenesButton.onClick.RemoveAllListeners();
        }
    }
}
