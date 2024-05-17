using CommunityToolkit.Mvvm.Messaging.Messages;

namespace coursework.UI.Messenger
{
    class CountMessenger : ValueChangedMessage<int>
    {
        public CountMessenger(int value) : base(value)
        {
        }
    }
}
