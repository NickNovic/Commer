namespace Models.Account
{
    public class RegistrationModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public static explicit operator Account(RegistrationModel model)
        {
            Account account = new Account
            {
                Name = model.Name,
                Email = model.Email,
                Password = model.Password
            };
            return account;
        }
    }
}