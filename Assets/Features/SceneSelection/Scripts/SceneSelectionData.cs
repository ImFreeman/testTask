using Features.DataSelector.Scripts.Realization;
using UnityEngine;
[CreateAssetMenu(fileName = "SceneData", menuName = "SelectableData/SceneData", order = 2)]
public class SceneSelectionData : BaseSelectableData
{
    [SerializeField] private string _name;
    [SerializeField] private string _description;
    [SerializeField] private Sprite _spriteArt;
    [SerializeField] private int _sceneId;

    public string Name => _name;

    public string Description => _description;

    public Sprite SpriteArt => _spriteArt;

    public int SceneId => _sceneId;
}
