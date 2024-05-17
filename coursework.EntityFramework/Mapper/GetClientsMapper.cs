using coursework.Domain.Model;
using coursework.EntityFramework.Model;

namespace coursework.EntityFramework.Mapper
{
    public class GetClientsMapper
    {
        public Client MapFromModel(GetClient client)
        {
            return new Client(client.ClientId.GetValueOrDefault(), client.ClientLastname, client.ClientFirstname, client.ClientMiddlename, client.ClientLogin, client.ClientRegDate.GetValueOrDefault(), client.ClientBirthday);
        }
    }
}
