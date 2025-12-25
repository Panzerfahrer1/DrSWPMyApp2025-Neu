namespace _01RestApi.Classes {
    public class User {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }

        public int FollowerCount { get; set; }
        public bool IsVerified { get; set; }
    }
}
