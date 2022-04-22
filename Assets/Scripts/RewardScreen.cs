using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardScreen : ScreenBase
{
    public GameObject vaso;
    // Start is called before the first frame update
    void Start()
    {
        Animate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Animate() {

        StartCoroutine(AnimateWorker());
        StartCoroutine(Pulse());

    }

    public IEnumerator AnimateWorker()
    {
        while (true)
        {
            iTween.RotateBy(vaso, new Vector3(0f, 0f, -.15f), 2f);
            yield return new WaitForSeconds(2f);
            iTween.RotateBy(vaso, new Vector3(0f, 0f, .15f), 2f);
            yield return new WaitForSeconds(2f);
        }
    }

    public IEnumerator Pulse()
    {
        while (true)
        {
            iTween.ScaleTo(vaso, iTween.Hash("scale", Vector3.one * 0.8f, "time", 0.25f, "easeType", iTween.EaseType.easeInExpo));
            yield return new WaitForSeconds(0.25f);
            iTween.ScaleTo(vaso, iTween.Hash("scale", Vector3.one, "time", 0.25f, "easeType", iTween.EaseType.easeOutExpo));
            yield return new WaitForSeconds(0.25f);
        }
    }

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
