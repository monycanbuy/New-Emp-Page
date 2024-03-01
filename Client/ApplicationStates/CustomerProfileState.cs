using Shared.DTOs;

namespace Client.ApplicationStates
{
    public class CustomerProfileState
    {
        public Action? Action { get; set; }
        public CustomerProfile customerProfile { get; set; } = new();
        public void CustomerUpdated() => Action!.Invoke();
    }
}
