using System;

[Serializable]
public class UserData
{
    public string Username;
    public string Email;
    public string Password;
    public int UnlockLevel;


    public UserData(string username, string email, string password, int unlockLevel)
    {
        Username = username;
        Email = email;
        Password = password;
        UnlockLevel = unlockLevel;
    }
}
