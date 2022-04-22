using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAnimation : MonoBehaviour
{
    bool activeBtn = false;
    public void Setup()
    {
        transform.localScale = Vector3.zero;
    }
    public void Animate()
    {
        activeBtn = true;
        StartCoroutine(AnimateWorker());
    }

    public IEnumerator AnimateWorker()
    {
        iTween.ScaleTo(this.gameObject, iTween.Hash("scale", Vector3.one, "time", 0.5f, "easeType", iTween.EaseType.easeOutExpo));

        var time = Random.Range(1f, 12f);

        while (activeBtn)
        {
            yield return new WaitForSeconds(time);
            if (activeBtn)
            {
                iTween.ScaleTo(this.gameObject, iTween.Hash("scale", Vector3.one*0.8f, "time", 0.75f, "easeType", iTween.EaseType.easeInExpo));
                yield return new WaitForSeconds(0.75f);
                iTween.ScaleTo(this.gameObject, iTween.Hash("scale", Vector3.one, "time", .5f, "easeType", iTween.EaseType.easeOutBounce));
            }
            time = Random.Range(1f, 12f);
        }
    }

    public void SelectButton()
    {
        iTween.ScaleTo(this.gameObject, iTween.Hash("scale", Vector3.zero, "time", 0.75f, "easeType", iTween.EaseType.easeInExpo));
    }
}
