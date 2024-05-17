using CommunityToolkit.Mvvm.Messaging.Messages;
using coursework.Domain.Model;

namespace coursework.UI.Messenger
{
    internal class ProdComposMessenger : ValueChangedMessage<ProdComposition>
    {
        public ProdComposMessenger(ProdComposition value) : base(value)
        {
        }
    }
}
