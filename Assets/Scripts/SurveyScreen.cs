using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

using System.IO;

public class SurveyScreen : ScreenBase
{
    public TMP_InputField nameField;
    public TMP_InputField cedulaField;
    public TMP_InputField birthdayField;
    public TMP_InputField mailField;
    public TMP_InputField phoneField;
    //public TMP_InputField toggleField;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Animate() { }

    public void CheckAndSave()
    {

        appController.user.nombre = nameField.text;
        appController.user.cedula = cedulaField.text;
        appController.user.nacimiento = birthdayField.text;
        appController.user.email = mailField.text;
        appController.user.telefono = phoneField.text;
        appController.user.mayoredad = "YES";

        var db = PlayerPrefs.GetString("DB");
        List<User> users = new List<User>();

        if (db.Length > 5)
        {
            User[] userDB = JsonHelper.FromJson<User>(db); // JsonUtility.FromJson<User[]>(db);

            if (userDB.Length > 0)
            {
                foreach (User user in userDB)
                {
                    users.Add(user);
                }
            }
        }
        
        
        users.Add(appController.user);print(" List " + users.Count);

        var newArray = users.ToArray(); print(" Arr " + newArray[0].nombre);

        var json = JsonHelper.ToJson<User>(newArray); //JsonUtility.ToJson(newArray);

        PlayerPrefs.SetString("DB", json);
        
        print(json);

        string path = Application.persistentDataPath + "/settings.txt";
        //Write some text to the test.txt file
        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine(json);
        writer.Close();

    }

    public void NextScreen()
    {
        CheckAndSave();
        appController.LoadScreen(Screens.Final);

    }

    public override void ShowScreen()
    {
        StartCoroutine(ShowScreenWorker());
    }



    public override void HideScreen()
    {
        StartCoroutine(HideScreenWorker());
    }
}


public static class JsonHelper
{
    public static T[] FromJson<T>(string json)
    {
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
        return wrapper.Items;
    }

    public static string ToJson<T>(T[] array)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper);
    }

    public static string ToJson<T>(T[] array, bool prettyPrint)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper, prettyPrint);
    }

    [SerializeField]
    private class Wrapper<T>
    {
        public T[] Items;
    }
}
