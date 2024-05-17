using CommunityToolkit.Mvvm.Messaging.Messages;
using coursework.Domain.Model;

namespace coursework.UI.Messenger
{
    internal class WorkshopMessenger : ValueChangedMessage<Workshop>
    {
        public WorkshopMessenger(Workshop value) : base(value)
        {
        }
    }
}
