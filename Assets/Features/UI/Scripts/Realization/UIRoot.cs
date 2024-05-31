using Features.UI.Scripts.Interfaces;
using UnityEngine;

namespace Features.UI.Scripts.Realization
{
    public class UIRoot : MonoBehaviour, IUIRoot
    {
        public Transform Container => container;
        
        [SerializeField] private Transform container;
    }
}