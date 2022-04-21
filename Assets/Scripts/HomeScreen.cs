using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeScreen : ScreenBase
{
    public GameObject[] components;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Animate() { }
    public void NextScreen() 
    {
        appController.user.date = "NOW";
        appController.LoadScreen(Screens.Music);

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
