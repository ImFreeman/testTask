using System;
using Sample.Features.Input.Scripts.Enums;

namespace Sample.Features.Input.Scripts.Interfaces
{
    public interface IInput
    {
        public event EventHandler<InputType> InputPressed;
    }
}