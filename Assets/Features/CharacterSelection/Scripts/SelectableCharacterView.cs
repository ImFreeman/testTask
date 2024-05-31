using Features.DataSelector.Scripts.Realization;
using UnityEngine;

namespace Features.CharacterSelection.Scripts
{
    public class SelectableCharacterView : BaseSelectedObjectView<SelectableCharacterData>
    {
        [SerializeField] private Transform _visualContainer;

        private GameObject _visual;
        private CharacterSelectionWindowView _window;
    
        public void SetWindow(CharacterSelectionWindowView window)
        {
            _window = window;
        }
    
        public override void UpdateView(SelectableCharacterData data)
        {
            _window.NameText.text = data.CharacterName;
            _window.LevelText.text = data.Level.ToString();
            _window.AvatarImage.sprite = data.Avatar;
            if (_visual != null)
            {
                Destroy(_visual.gameObject);
            }

            _visual = Instantiate(data.Visual, _visualContainer, false);
        }

        public void OnDestroy()
        {
            if (_visual != null)
            {
                Destroy(_visual.gameObject);
            }
        }
    }
}
