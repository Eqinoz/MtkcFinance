namespace Core.Entities.Concrete
{
    public class Users : IEntity
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserSurname{ get; set; }
        public string? Mail { get; set; }
        public byte[]? PswSalt { get; set; }
        public byte[]? PswHash { get; set; }
        public string? Phone { get; set; }
        public int? TitleId { get; set; }
        public int? CompanyId { get; set; }
    }
}
