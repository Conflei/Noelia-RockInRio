using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurveyScreen : ScreenBase
{
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

        appController.user.name = "";
        appController.user.cedula = "";
        appController.user.nacimiento = "";
        appController.user.mail = "";
        appController.user.phone = "";
        appController.user.underage = "";
        //jsonserielize and save to disk

        NextScreen();

    }

    public void NextScreen()
    {
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
