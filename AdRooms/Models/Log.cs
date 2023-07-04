namespace AdRooms.Models
{
    public class Log
    {
        public int Id { get; set; }
        public string Action { get; set; }
        public string Info { get; set; }
        public DateTime Date { get; set; }
        public int? UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
    }
}
