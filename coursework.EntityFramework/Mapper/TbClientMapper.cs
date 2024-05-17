using coursework.Domain.Model;
using coursework.EntityFramework.Model;

namespace coursework.EntityFramework.Mapper
{
    public class TbClientMapper
    {
        public Client MapFromModel(TbClient client)
        {
            return new Client(client.ClientId, client.ClientLastname, client.ClientFirstname, client.ClientMiddlename, client.ClientLogin, client.ClientRegDate, client.ClientBirthday);
        }
    }
}
