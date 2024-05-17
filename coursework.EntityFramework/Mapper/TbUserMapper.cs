using coursework.Domain.Model;
using coursework.EntityFramework.Model;

namespace coursework.EntityFramework.Mapper
{
    public class TbUserMapper
    {
        public User MapFromModel(TbUser user)
        {
            return new User(user.UserLogin, user.UserPassword, user.UserEmail, user.UserPhone, user.UserRoleId, user.UserImage);
        }
    }
}
