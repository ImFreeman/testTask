using System;
using Sample.Features.Input.Scripts.Enums;
using Sample.Features.Input.Scripts.Interfaces;
using Sample.Features.UI.Scripts.Interfaces;

namespace Sample.Features.SceneSelection.Scripts
{
    public class SceneSelectionInputHandler : IDisposable
    {
        private readonly IUIService _uiService;
        private readonly IInput _input;
        private readonly SceneSelectionContainerHandler _sceneSelectionContainerHandler;

        private SceneSelectionWindowView _currentWindow;
        private int _currentButtonId;
        private bool _isShown;

        public SceneSelectionInputHandler(
            IUIService uiService,
            IInput input,
            SceneSelectionContainerHandler sceneSelectionContainerHandler)
        {
            _uiService = uiService;
            _input = input;
            _sceneSelectionContainerHandler = sceneSelectionContainerHandler;

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
            if (e == typeof(SceneSelectionWindowView))
            {
                _currentButtonId = 0;
                _input.InputPressed += OnInputPressed;
                if (_uiService.Get<SceneSelectionWindowView>(out var window))
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
                    _currentWindow.Buttons[_currentButtonId].Button.onClick.Invoke();
                    break;
                case InputType.Right:
                    _currentWindow.Buttons[_currentButtonId].Button.image.color = UnityEngine.Color.white;
                    _currentButtonId = Math.Min(_currentButtonId + 1, _currentWindow.Buttons.Length - 1);
                    _currentWindow.Buttons[_currentButtonId].Button.image.color = UnityEngine.Color.red;
                    _currentWindow.Buttons[_currentButtonId].Button.onClick.Invoke();
                    break;
                case InputType.Enter:
                    _sceneSelectionContainerHandler.LoadSelectedScene();
                    break;
            }
        }

        private void OnWindowHiden(object sender, Type e)
        {
            if (e == typeof(SceneSelectionWindowView))
            {
                _input.InputPressed -= OnInputPressed;
                _isShown = false;
            }
        }
    }
}