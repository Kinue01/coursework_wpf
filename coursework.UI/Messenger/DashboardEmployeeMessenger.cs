using CommunityToolkit.Mvvm.Messaging.Messages;
using coursework.Domain.Model;

namespace coursework.UI.Messenger
{
    class DashboardEmployeeMessenger : ValueChangedMessage<Employee>
    {
        public DashboardEmployeeMessenger(Employee value) : base(value)
        {
        }
    }
}
