using CommunityToolkit.Mvvm.Messaging.Messages;
using coursework.Domain.Model;

namespace coursework.UI.Messenger
{
    internal class UserMessenger : ValueChangedMessage<User>
    {
        public UserMessenger(User value) : base(value)
        {
        }
    }
}
