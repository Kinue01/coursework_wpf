using CommunityToolkit.Mvvm.Messaging.Messages;
using coursework.Domain.Model;

namespace coursework.UI.Messenger
{
    class IngredientMessenger : ValueChangedMessage<Ingredient>
    {
        public IngredientMessenger(Ingredient value) : base(value)
        {
        }
    }
}
