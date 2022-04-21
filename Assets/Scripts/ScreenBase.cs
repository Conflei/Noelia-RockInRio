using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenBase : MonoBehaviour
{
    public CanvasGroup cg { set; get; }

    public AppController appController { set; get; }

    private void Awake()
    {
        appController = GameObject.FindGameObjectWithTag("AppController").GetComponent<AppController>();
        cg = GetComponent<CanvasGroup>();
    }

    public virtual void ShowScreen() { }
    public virtual void HideScreen() { }

    public IEnumerator ShowScreenWorker()
    {

        while (cg.alpha < 1f)
        {
            cg.alpha += 0.02f;
            yield return null;
        }
        cg.blocksRaycasts = true;
        cg.interactable = true;
        yield return null;
    }

    public IEnumerator HideScreenWorker()
    {
        while (cg.alpha > 0f)
        {
            cg.alpha -= 0.02f;
            yield return null;
        }
        cg.blocksRaycasts = false;
        cg.interactable = false;
        yield return null;
    }

}
