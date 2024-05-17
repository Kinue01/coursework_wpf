using CommunityToolkit.Mvvm.Messaging.Messages;
using coursework.Domain.Model;

namespace coursework.UI.Messenger
{
    internal class SupplierMesenger : ValueChangedMessage<Supplier>
    {
        public SupplierMesenger(Supplier value) : base(value)
        {
        }
    }
}
