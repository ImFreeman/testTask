using System;
using Core.DataSelector.Scripts.Interfaces;
using Sample.Features.UI.Scripts.Interfaces;

namespace Sample.Features.SceneSelection.Scripts
{
    public class SceneSelectionScreenController : IDisposable
    {
        private readonly IUIService _uiService;
        private readonly IDataSelector<SceneSelectionData> _selector;

        public SceneSelectionScreenController(
            IUIService uiService,
            IDataSelector<SceneSelectionData> selector)
        {
            _uiService = uiService;
            _selector = selector;
            _uiService.WindowShown += OnWindowShown;
        }
        
        public void Dispose()
        {
            _uiService.WindowShown -= OnWindowShown;
        }
        
        private void OnWindowShown(object sender, Type e)
        {
            if (e == typeof(SceneSelectionWindowView))
            {
                if (_uiService.Get<SceneSelectionWindowView>(out var window))
                {
                    _selector.SetView(window);
                }
            }
        }
    }
}