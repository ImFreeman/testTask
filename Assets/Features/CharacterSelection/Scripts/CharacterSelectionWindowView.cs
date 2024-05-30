using System;
using Features.UI.Scripts.Realization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class CharacterSelectionWindowView : UIBaseWindow
{
    [SerializeField] private TMP_Text _nameText;
    [SerializeField] private TMP_Text _levelText;
    [SerializeField] private Image _avatarImage;
    [SerializeField] private CharacterButtonData[] _buttons;

    public TMP_Text NameText => _nameText;

    public TMP_Text LevelText => _levelText;

    public Image AvatarImage => _avatarImage;

    public CharacterButtonData[] Buttons => _buttons;

    public event EventHandler<string> CharacterButtonPressed;

    protected override void OnShow()
    {
        foreach (var button in _buttons)
        {
            button.Button.onClick.AddListener(() =>
            {
                CharacterButtonPressed?.Invoke(this, button.CharacterID);
            });
        }
    }

    protected override void OnHide()
    {
        foreach (var button in _buttons)
        {
            button.Button.onClick.RemoveAllListeners();
        }
    }
    
    [Serializable]
    public struct CharacterButtonData
    {
        public Button Button;
        public string CharacterID;
    }
}
