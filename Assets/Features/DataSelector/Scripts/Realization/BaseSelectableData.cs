using Features.DataSelector.Scripts.Interfaces;
using UnityEngine;

namespace Features.DataSelector.Scripts.Realization
{
    public abstract class BaseSelectableData : ScriptableObject, ISelectableData
    {
        public string ID => _id;
        
        [SerializeField] private string _id;
    }
}