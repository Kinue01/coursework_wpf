namespace coursework.Domain.Model
{
    public class Paytype
    {
        public int TypeId { get; set; }

        public string TypeName { get; set; }

        public Paytype(int typeId, string typeName)
        {
            TypeId = typeId;
            TypeName = typeName;
        }
    }
}
