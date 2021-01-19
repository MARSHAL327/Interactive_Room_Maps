using System;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[System.Serializable]
public class AllUser
{
    [System.Serializable]
    public struct User
    {
        public string name;
        public string password;
        public string role;
    }

    public User[] users;
}

public class LogIn : MonoBehaviour
{
    public InputField userInput;
    public InputField passwordInput;
    public Text invalidDataTextField;
    public Button ExitBtn;

    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(() =>
        {
            LogInUser(userInput.text, passwordInput.text);
        });

        ExitBtn.onClick.AddListener(() =>
        {
            Application.Quit();
        });
    }

    public void LogInUser(string userName, string userPassword)
    {
        string pathToFile = "Assets/users.json";
        string readAllFile = File.ReadAllText(pathToFile);
        bool invalidData = false;
        AllUser activeUser = JsonUtility.FromJson<AllUser>(readAllFile);

        for (int i = 0; i < activeUser.users.Length; i++)
        {
            if ( userName == activeUser.users[i].name && userPassword == activeUser.users[i].password )
            {
                UserData.name = activeUser.users[i].name;
                UserData.role = activeUser.users[i].role;
                invalidData = false;
                break;
            }
            else
            {
                invalidData = true;
            }
        }

        if (invalidData)
        {
            invalidDataTextField.text = "Неверные данные";
        } else
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
