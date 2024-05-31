using System;
using Sample.Features.Input.Scripts.Enums;
using Sample.Features.Input.Scripts.Interfaces;
using UnityEngine;

namespace Sample.Features.Input.Scripts.Realization
{
    public class KeyboardInput : MonoBehaviour, IInput
    {
        public event EventHandler<InputType> InputPressed;

        private void Update()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.W))
            {
                InputPressed?.Invoke(this, InputType.Up);
            }
            if (UnityEngine.Input.GetKeyDown(KeyCode.S))
            {
                InputPressed?.Invoke(this, InputType.Down);
            }
            if (UnityEngine.Input.GetKeyDown(KeyCode.A))
            {
                InputPressed?.Invoke(this, InputType.Left);
            }
            if (UnityEngine.Input.GetKeyDown(KeyCode.D))
            {
                InputPressed?.Invoke(this, InputType.Right);
            }
            if (UnityEngine.Input.GetKeyDown(KeyCode.Space))
            {
                InputPressed?.Invoke(this, InputType.Enter);
            }
        }
    }
}