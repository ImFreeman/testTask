using Core.DataSelector.Scripts.Realization;
using UnityEngine;

namespace Sample.Features.CharacterSelection.Scripts
{
    [CreateAssetMenu(fileName = "CharacterData", menuName = "SelectableData/CharacterData", order = 1)]
    public class SelectableCharacterData : BaseSelectableData
    {
        public string CharacterName => _characterName;

        public uint Level => _level;

        public Sprite Avatar => _avatar;

        public GameObject Visual => _visual;
        
        [SerializeField] private string _characterName;
        [SerializeField] private uint _level;
        [SerializeField] private Sprite _avatar;
        [SerializeField] private GameObject _visual;
    }
}
