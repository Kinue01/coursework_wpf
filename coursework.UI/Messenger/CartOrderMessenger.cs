using CommunityToolkit.Mvvm.Messaging.Messages;
using coursework.Domain.Model;

namespace coursework.UI.Messenger
{
    internal class CartOrderMessenger : ValueChangedMessage<List<CartOrder>>
    {
        public CartOrderMessenger(List<CartOrder> value) : base(value)
        {
        }
    }
}
