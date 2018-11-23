namespace DevContact.Domain.Entities
{
    public class Car:BaseEntity
    {
        public string Ownername { get; set; } = string.Empty;
        public string Registration { get; set; } = string.Empty;
        public int Type { get; set; } =0;//Car=1; Truck=2
    }
}
