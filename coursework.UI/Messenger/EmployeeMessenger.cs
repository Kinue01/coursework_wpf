using CommunityToolkit.Mvvm.Messaging.Messages;
using coursework.Domain.Model;

namespace coursework.UI.Messenger
{
    internal class EmployeeMessenger : ValueChangedMessage<Employee>
    {
        public EmployeeMessenger(Employee value) : base(value)
        {
        }
    }
}
