using System;

[Serializable]
public class UserData
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }


    public UserData(string username, string email, string password)
    {
        Username = username;
        Email = email;
        Password = password;
    }
}
