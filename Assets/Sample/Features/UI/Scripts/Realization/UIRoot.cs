using Sample.Features.UI.Scripts.Interfaces;
using UnityEngine;

namespace Sample.Features.UI.Scripts.Realization
{
    public class UIRoot : MonoBehaviour, IUIRoot
    {
        public Transform Container => container;
        
        [SerializeField] private Transform container;
    }
}