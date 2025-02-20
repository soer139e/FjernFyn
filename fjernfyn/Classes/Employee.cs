namespace fjernfyn
{
    public class Employee
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email {  get; set; }
        public Department Department { get; set; }

        //TODO: constructor chain, so that the user can only input the username and password, and get away with it.

        public Employee(string username, string password, string mail, Department dep) 
        {
            Username = username;
            Password = password;
            Email = mail;
            Department = dep;
        }

    }
}
