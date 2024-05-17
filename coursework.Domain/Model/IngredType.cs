namespace coursework.Domain.Model
{
    public class IngredType
    {
        public int TypeId { get; set; }

        public string TypeName { get; set; }

        public int TypeStorageTemp { get; set; }

        public int TypeStorageHumidity { get; set; }

        public IngredType(int typeId, string typeName, int typeStorageTemp, int typeStorageHumidity)
        {
            TypeId = typeId;
            TypeName = typeName;
            TypeStorageTemp = typeStorageTemp;
            TypeStorageHumidity = typeStorageHumidity;
        }
    }
}
