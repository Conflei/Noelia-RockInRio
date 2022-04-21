using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalScreen : ScreenBase
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
        StartCoroutine(HideAndRestart());

    }

    public IEnumerator HideAndRestart()
    {
        yield return StartCoroutine(HideScreenWorker());
        appController.RestartApp();

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
