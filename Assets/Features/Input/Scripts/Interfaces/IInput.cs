using System;
using Features.Input.Scripts.Enums;

namespace Features.Input.Scripts.Interfaces
{
    public interface IInput
    {
        public event EventHandler<InputType> InputPressed;
    }
}