namespace fjernfyn
{
    public class Employee
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email {  get; set; }
        public Department Department { get; set; }

        public string FullName {  get; set; }

        //TODO: constructor chain, so that the user can only input the username and password, and get away with it.

    }
}
