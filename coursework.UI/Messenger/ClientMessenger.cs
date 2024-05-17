using CommunityToolkit.Mvvm.Messaging.Messages;
using coursework.Domain.Model;

namespace coursework.UI.Messenger
{
    class ClientMessenger : ValueChangedMessage<Client>
    {
        public ClientMessenger(Client value) : base(value)
        {
        }
    }
}
