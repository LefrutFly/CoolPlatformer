using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Proyecto26;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using static UnityEditor.ShaderData;
using static System.Net.Mime.MediaTypeNames;


public class LoginMenu : MonoBehaviour
{
    private const string AUTH_KEY = "AIzaSyD4dWBcwHSifSIu0Rj1la_LkcYtJnbNuh0";

    [SerializeField] private GameObject startMenu;

    [Header("Sign In")]
    [SerializeField] private GameObject signInMenu;
    [SerializeField] private TMP_InputField signInEmail;
    [SerializeField] private TMP_InputField signInPassword;

    [Header("Sign Un")]
    [SerializeField] private GameObject signUpMenu;
    [SerializeField] private TMP_InputField signUpLogin;
    [SerializeField] private TMP_InputField signUpEmail;
    [SerializeField] private TMP_InputField signUpPassword;

    [Space(32)]
    [SerializeField] private Button loginButton;
    [SerializeField] private Button registrButton;
    [SerializeField] private Button openSignUpMenuButton;
    [SerializeField] private Button openSignInMenuButton;
    [SerializeField] private TMP_Text errorText;


    private void OnEnable()
    {
        openSignUpMenuButton.onClick.AddListener(OpenSignUpMenu);
        openSignInMenuButton.onClick.AddListener(OpenSignInMenu);
        loginButton.onClick.AddListener(SignIn);
        registrButton.onClick.AddListener(SignUp); 
    }

    private void OnDisable()
    {
        openSignUpMenuButton.onClick.RemoveListener(OpenSignUpMenu);
        openSignInMenuButton.onClick.RemoveListener(OpenSignInMenu);
        loginButton.onClick.RemoveListener(SignIn);
        registrButton.onClick.RemoveListener(SignUp);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            BackToStartMenu();
        }
    }


    private void OpenSignUpMenu()
    {
        startMenu.SetActive(false);
        signInMenu.SetActive(false);
        signUpMenu.SetActive(true);
        errorText.text = "";
    }

    private void OpenSignInMenu()
    {
        startMenu.SetActive(false);
        signInMenu.SetActive(true);
        signUpMenu.SetActive(false);
        errorText.text = "";
    }

    private void BackToStartMenu()
    {
        startMenu.SetActive(true);
        signInMenu.SetActive(false);
        signUpMenu.SetActive(false);
        signInEmail.text = "";
        signInPassword.text = "";
        signUpLogin.text = "";
        signUpEmail.text = "";
        signUpPassword.text = "";
        errorText.text = "";
    }


    private void SignIn()
    {
        Debug.Log("1");
        string email = signInEmail.text;
        string password = signInPassword.text;

        SignIn(email, password);
    }

    private void SignIn(string email, string password)
    {
        Debug.Log("2");
        errorText.text = "Search Account...";
        errorText.color = Color.white;

        string data = "{\"email\":\"" + email + "\",\"password\":\"" + password + "\",\"returnSecureToken\":true}";

        RestClient.Post<AuthData>(
            $"https://identitytoolkit.googleapis.com/v1/accounts:signInWithPassword?key={AUTH_KEY}",
            data,
            SignInCallback
            );
    }

    private void SignInCallback(RequestException exception, ResponseHelper helper, AuthData data)
    {
        try
        {
            Debug.Log("3");
            errorText.text = "Account Initialised";
            errorText.color = Color.green;

            GetUserByEmail(data.Email);
        }
        catch (Exception ex)
        {
            errorText.text = ex.Message;
            errorText.color = Color.red;
        }
    }

    private void GetUserByEmail(string email)
    {
        Debug.Log("4");
        DataBase.FindUserByEmail(email, GetUserByEmail);
    }

    private void GetUserByEmail(RequestException exception, ResponseHelper helper)
    {
        try
        {
            Debug.Log("5");
            Debug.Log(helper.Text);
            Dictionary<string, UserData> dict = JsonConvert.DeserializeObject<Dictionary<string, UserData>>(helper.Text);

            foreach (KeyValuePair<string, UserData> kvp in dict)
            {
                Debug.Log("6");
                var data = kvp.Value;
                Debug.Log(data);

                break;
            }
        }
        catch (Exception ex)
        {
            Debug.Log("User Data not Loaded!" + "\n" + ex.ToString());
        }
    }

    private void SignUp()
    {
        string email = signUpEmail.text;
        string login = signUpLogin.text;
        string password = signUpPassword.text;

        bool IsEmailEmpty = string.IsNullOrEmpty(email) || string.IsNullOrWhiteSpace(email);
        bool IsLoginEmpty = string.IsNullOrEmpty(login) || string.IsNullOrWhiteSpace(login);
        bool IsPasswordEmpty = string.IsNullOrEmpty(password) || string.IsNullOrWhiteSpace(password);

        errorText.text = "Waiting, you'r account creating...";
        errorText.color = Color.white;

        if (!IsLoginEmpty && !IsLoginEmpty && !IsPasswordEmpty)
        {
            DataBase.GetUserByLogin(login, GetUserByLoginCallback);
        }
    }

    private void GetUserByLoginCallback(RequestException exception, ResponseHelper helper, UserData userData)
    {
        if (userData == null)
        {
            if (signUpPassword.text.Length >= 6)
            {
                string data = "{\"email\":\"" +
                    signUpEmail.text + "\",\"password\":\"" +
                    signUpPassword.text + "\",\"returnSecureToken\":true}";

                RestClient.Post<AuthData>(
                    $"https://identitytoolkit.googleapis.com/v1/accounts:signUp?key={AUTH_KEY}",
                    data,
                    SignUpcallback
                    );
            }
            else
            {
                errorText.text = "Password less than 6 characters!";
                errorText.color = Color.red;
            }
        }
        else
        {
            errorText.text = "Account with you'r login have in system!";
            errorText.color = Color.red;
        }
    }

    private void SignUpcallback(RequestException exception, ResponseHelper helper, AuthData data)
    {
        try
        {
            string login = signUpLogin.text;
            string email = signUpEmail.text;
            string password = signUpPassword.text;

            errorText.text = "Account created!";
            errorText.color = Color.green;

            var userData = new UserData(login, email, password);

            DataBase.SendToDataBase(userData, login);
        }
        catch (Exception ex)
        {
            errorText.text = ex.Message;
            errorText.color = Color.red;
        }
    }
}