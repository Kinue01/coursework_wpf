using CommunityToolkit.Mvvm.Messaging.Messages;
using coursework.Domain.Model;

namespace coursework.UI.Messenger
{
    class ProductMessenger : ValueChangedMessage<Product>
    {
        public ProductMessenger(Product value) : base(value)
        {
        }
    }
}
