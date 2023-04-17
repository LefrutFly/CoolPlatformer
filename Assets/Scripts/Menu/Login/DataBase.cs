using Proyecto26;
using System;

public class DataBase
{
    public static readonly string DATA_BASE = "https://coolplatformer-1cfb4-default-rtdb.firebaseio.com/users";

    public static void SendToDataBase(UserData userData, string separator)
    {
        RestClient.Put<UserData>($"{DATA_BASE}/{separator}.json", userData);
    }

    public static void GetUserByLogin(string login, Action<RequestException, ResponseHelper, UserData> GetInfoCallback)
    {
        RestClient.Get<UserData>($"{DATA_BASE}/{login}.json", GetInfoCallback);
    }

    public static void FindUserByEmail(string email, Action<RequestException, ResponseHelper> GetInfoCallback)
    {
        RestClient.Get($"{DATA_BASE}.json?orderBy=%22Email%22&equalTo=%22{email}%22", GetInfoCallback);
    }
}
