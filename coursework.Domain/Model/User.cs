using System.Windows.Media.Imaging;

namespace coursework.Domain.Model
{
    public class User
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int Role { get; set; }
        public BitmapImage Image { get; set; }
        public string imgstr { get; set; }

        public User(string login, string pass, string email, string phone, int role, string image)
        {
            Login = login;
            Password = pass;
            Email = email;
            PhoneNumber = phone;
            Role = role;
            imgstr = image;
            
            Image = new();
            Image.BeginInit();
            Image.UriSource = new Uri("..\\..\\..\\Image\\" + image, UriKind.Relative);
            Image.CacheOption = BitmapCacheOption.OnLoad;
            Image.EndInit();
        }
    }
}
