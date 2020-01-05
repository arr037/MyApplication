namespace MyApp.Model
{
    public class Message
    {
        public UserNameControl UserNameControl { get; }
        public MessengerMode Mode { get; }

        public Message(UserNameControl userNameControl,MessengerMode mode)
        {
            UserNameControl = userNameControl;
            Mode = mode;
        }
    }
}