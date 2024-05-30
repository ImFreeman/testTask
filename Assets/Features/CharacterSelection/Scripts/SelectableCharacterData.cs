using Features.DataSelector.Scripts.Realization;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "CharacterData", menuName = "SelectableData/CharacterData", order = 1)]
public class SelectableCharacterData : BaseSelectableData
{
    [SerializeField] private string characterName;
    [SerializeField] private uint _level;
    [SerializeField] private Sprite _avatar;
    [SerializeField] private GameObject _visual;

    public string CharacterName => characterName;

    public uint Level => _level;

    public Sprite Avatar => _avatar;

    public GameObject Visual => _visual;
}
