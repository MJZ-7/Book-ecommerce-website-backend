namespace sda_onsite_2_csharp_backend_teamwork_The_countryside_developers
{
    public class User
    {


        public string UserId { get; set; }
        public string FullName { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public User(string userId, string fullName, string role, string email, string password)
        {

            UserId = userId;
            FullName = fullName;
            Role = role;
            Email = email;
            Password = password;


        }

        public User(){}
    }
}