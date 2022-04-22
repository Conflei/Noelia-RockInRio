using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HomeScreen : ScreenBase
{

    public GameObject titleObj;
    public Transform titleObjFinalPos;
    public TextMeshProUGUI descText;
    private string finText = "QUE TANTO CONOCES DE MUSICA? DALE PLAY Y ADIVINA QUE MUSICA ES LA QUE SUENA";
    public Button button;

    public CanvasGroup fader;

    

    // Start is called before the first frame update
    void Start()
    {
        button.transform.localScale = Vector3.zero;
        Animate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Animate() {

        StartCoroutine(AnimateWorkerLoop());

    }

    public IEnumerator AnimateWorkerLoop()
    {

        while (cg.alpha > 0f)
        { 
            yield return StartCoroutine(AnimateWorker());
            yield return new WaitForSeconds(1f);
        }

    }

    public IEnumerator AnimateWorker()
    {
        var titleStartPos = titleObj.transform.position;
        yield return new WaitForSeconds(2f);
        iTween.MoveTo(titleObj, iTween.Hash("position", titleObjFinalPos.position, "time", 1f, "easeType", iTween.EaseType.easeOutBounce));
        yield return new WaitForSeconds(1.0f);
        yield return StartCoroutine(FillText());
        yield return new WaitForSeconds(1.0f);
        iTween.ScaleTo(button.gameObject, iTween.Hash("scale", Vector3.one, "time", 1f, "easeType", iTween.EaseType.easeOutBounce));
        yield return new WaitForSeconds(7.0f);

        while (fader.alpha > 0f)
        {
            fader.alpha -= 0.01f;
            yield return null;
        }

        titleObj.transform.position = titleStartPos;
        descText.text = "";
        button.transform.localScale = Vector3.zero;

        yield return null;

        fader.alpha = 1f;

    }

    public IEnumerator FillText()
    {
        foreach (var c in finText.ToCharArray())
        {
            descText.text += c;
            yield return new WaitForSeconds(0.025f);
        }

    }


    public void NextScreen() 
    {
        // appController.user.date = "NOW";
        if (appController == null) print("No reference to app controller");
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
