using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardScreen : ScreenBase
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
    public void NextScreen()
    {
        appController.LoadScreen(Screens.Survey);

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
