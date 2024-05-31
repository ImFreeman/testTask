using System;
using Sample.Features.CharacterSelection.Scripts;
using Sample.Features.SceneSelection.Scripts;
using Sample.Features.UI.Scripts.Interfaces;

namespace Sample.Features.StartScreen.Scripts
{
    public class StartScreenController : IDisposable
    {
        private readonly IUIService _uiService;

        private bool _shown;
    
        public StartScreenController(
            IUIService uiService
        )
        {
            _uiService = uiService;

            _uiService.WindowShown += OnWindowShown;
            _uiService.WindowHided += OnWindowHiden;
        }
        
        public void Dispose()
        {
            if (_shown)
            {
                if (_uiService.Get<StartScreenWindow>(out var window))
                {
                    window.CharacterButtonPressed -= OnCharacterButtonPressed;
                    window.ScenesButtonPressed -= OnScenesButtonPressed;
                }
            }
            _uiService.WindowShown -= OnWindowShown;
            _uiService.WindowHided -= OnWindowHiden;
        }

        private void OnWindowShown(object sender, Type e)
        {
            if (e == typeof(StartScreenWindow))
            {
                if (_uiService.Get<StartScreenWindow>(out var window))
                {
                    window.CharacterButtonPressed += OnCharacterButtonPressed;
                    window.ScenesButtonPressed += OnScenesButtonPressed;
                    _shown = true;
                }
            }
        }

        private void OnScenesButtonPressed(object sender, EventArgs e)
        {
            _uiService.Hide<StartScreenWindow>();
            _uiService.Show<SceneSelectionWindowView>();
        }

        private void OnCharacterButtonPressed(object sender, EventArgs e)
        {
            _uiService.Hide<StartScreenWindow>();
            _uiService.Show<CharacterSelectionWindowView>();
        }

        private void OnWindowHiden(object sender, Type e)
        {
            if (e == typeof(StartScreenWindow))
            {
                if (_uiService.Get<StartScreenWindow>(out var window))
                {
                    window.CharacterButtonPressed -= OnCharacterButtonPressed;
                    window.ScenesButtonPressed -= OnScenesButtonPressed;
                    _shown = false;
                }
            }
        }
    }
}
