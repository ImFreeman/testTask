using System;
using Features.Input.Scripts;
using Features.Input.Scripts.Enums;
using Features.Input.Scripts.Interfaces;
using Features.UI.Scripts.Interfaces;

namespace Features.CharacterSelection.Scripts
{
    public class CharacterSelectionInputHandler : IDisposable
    {
        private readonly IUIService _uiService;
        private readonly IInput _input;

        private CharacterSelectionWindowView _currentWindow;
        private int _currentButtonId;
        private bool _isShown;

        public CharacterSelectionInputHandler(IUIService uiService, IInput input)
        {
            _uiService = uiService;
            _input = input;
            
            _uiService.WindowShown += OnWindowShown;
            _uiService.WindowHided += OnWindowHiden;
        }
        
        public void Dispose()
        {
            if (_isShown)
            {
                _input.InputPressed -= OnInputPressed;
            }
            _uiService.WindowShown -= OnWindowShown;
            _uiService.WindowHided -= OnWindowHiden;
        }
        
        private void OnWindowShown(object sender, Type e)
        {
            if (e == typeof(CharacterSelectionWindowView))
            {
                _currentButtonId = 0;
                _input.InputPressed += OnInputPressed;
                if (_uiService.Get<CharacterSelectionWindowView>(out var window))
                {
                    _currentWindow = window;
                    _isShown = true;
                }
            }
        }

        private void OnInputPressed(object sender, InputType e)
        {
            switch (e)
            {
                case InputType.Left:
                    _currentWindow.Buttons[_currentButtonId].Button.image.color = UnityEngine.Color.white;
                    _currentButtonId = Math.Max(_currentButtonId - 1, 0);
                    _currentWindow.Buttons[_currentButtonId].Button.image.color = UnityEngine.Color.red;
                    break;
                case InputType.Right:
                    _currentWindow.Buttons[_currentButtonId].Button.image.color = UnityEngine.Color.white;
                    _currentButtonId = Math.Min(_currentButtonId + 1, _currentWindow.Buttons.Length - 1);
                    _currentWindow.Buttons[_currentButtonId].Button.image.color = UnityEngine.Color.red;
                    break;
                case InputType.Enter:
                    _currentWindow.Buttons[_currentButtonId].Button.onClick.Invoke();
                    break;
            }
        }

        private void OnWindowHiden(object sender, Type e)
        {
            if (e == typeof(CharacterSelectionWindowView))
            {
                _input.InputPressed -= OnInputPressed;
                _isShown = false;
            }
        }
    }
}