using System;

namespace Features.Input.Scripts
{
    public interface IInput
    {
        public event EventHandler<InputType> InputPressed;
    }
}