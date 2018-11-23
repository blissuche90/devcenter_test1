namespace DevContact.Domain.Entities
{
    public class DevContact: BaseEntity
    {
        public string Fullname { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int Type { get; set; } = 0;//FrontEnd=1; BackEnd=2
    }
}
