using System;
using System.Collections.Generic;
using Features.UI.Scripts.Interfaces;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Features.UI.Scripts.Realization
{
    public class UIService : IUIService
    {
        private readonly IUIRoot _uiRoot;
        private readonly IDictionary<Type, UIBaseWindow> _prefabStorage;
        private readonly IDictionary<Type, UIBaseWindow> _windowsOnScene;

        public UIService(IUIRoot uiRoot)
        {
            _uiRoot = uiRoot;

            _prefabStorage = new Dictionary<Type, UIBaseWindow>();
            _windowsOnScene = new Dictionary<Type, UIBaseWindow>();
        }

        public void LoadWindows()
        {
            var windows = Resources.LoadAll("Windows", typeof(UIBaseWindow));

            foreach (var window in windows)
            {
                var windowType = window.GetType();
                _prefabStorage.Add(windowType, (UIBaseWindow)window);
            }
        }
        
        public T Show<T>() where T : UIBaseWindow
        {
            var type = typeof(T);
            if (!_windowsOnScene.ContainsKey(type) && _prefabStorage.TryGetValue(type, out var windowPrefab))
            {
                var window = Object.Instantiate(windowPrefab as T, _uiRoot.Container, false);
                window.Show();
                _windowsOnScene.Add(type, window);
                return window;
            }

            Debug.LogError($"There no such window {type.Name}");
            return null;
        }

        public void Hide<T>() where T : UIBaseWindow
        {
            if (Get<T>(out var window))
            {
                window.Hide();
                Object.Destroy(window.gameObject);
                _windowsOnScene.Remove(typeof(T));
            }
        }

        public bool Get<T>(out T window) where T : UIBaseWindow
        {
            var type = typeof(T);
            if (_windowsOnScene.TryGetValue(type, out var newWindow))
            {
                window = newWindow as T;
                return true;
            }

            window = null;
            return false;
        }
    }
}