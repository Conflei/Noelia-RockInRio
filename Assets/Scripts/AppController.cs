using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppController : MonoBehaviour
{
    public GameObject[] screens;

    public User user = new User();

    private Screens current = Screens.Home;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void LoadScreen(Screens screenToLoad)
    {
        
        switch (screenToLoad)
        {
            case Screens.Home:
                break;
            case Screens.Music:
                StartCoroutine(HideAndShow(screens[(int)Screens.Home], screens[(int)Screens.Music]));
                break;
            case Screens.Reward:
                StartCoroutine(HideAndShow(screens[(int)Screens.Music], screens[(int)Screens.Reward]));
                break;
            case Screens.Survey:
                StartCoroutine(HideAndShow(screens[(int)Screens.Reward], screens[(int)Screens.Survey]));
                break;
            case Screens.Final:
                if(current == Screens.Survey)
                    StartCoroutine(HideAndShow(screens[(int)Screens.Survey], screens[(int)Screens.Final]));
                else
                {
                    StartCoroutine(HideAndShow(screens[(int)Screens.Music], screens[(int)Screens.Final]));
                }
                break;
        }

        current = screenToLoad;
    }

    public IEnumerator HideAndShow(GameObject old, GameObject newScreen )
    {
        old.GetComponent<ScreenBase>().HideScreen();
        yield return new WaitForSeconds(1f);
        newScreen.GetComponent<ScreenBase>().ShowScreen();
        yield return null;
    }

    public void RestartApp()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}

public enum Screens
{ 
    Home, Music, Reward, Survey, Final
}

public class User
{ 
    public string name;
    public string cedula;
    public string nacimiento;
    public string mail;
    public string phone;
    public string date;
    public string underage;
    public string reward;
}
