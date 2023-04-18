using System;

[Serializable]
public class UserData
{
    public string Username;
    public string Email;
    public string Password;


    public UserData(string username, string email, string password)
    {
        Username = username;
        Email = email;
        Password = password;
    }
}
