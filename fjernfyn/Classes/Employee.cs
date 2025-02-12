namespace fjernfyn
{
    public class Employee
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email {  get; set; }
        public Department Department { get; set; }

        public Employee(string username, string password, string mail, Department dep) 
        {
            Username = username;
            Password = password;
            Email = mail;
            Department = dep;
        }

    }
}
