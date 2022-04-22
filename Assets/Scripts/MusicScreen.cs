using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicScreen : ScreenBase
{
    int musicId;

    public AudioSource musicSource;
    public AudioClip[] clips;

    public Sprite[] names;

    public Image[] buttons;

    public List<ButtonAnimation> btnAnims;

    private KeyValuePair<int, int>[] correctResponses = new KeyValuePair<int, int>[] {
        new KeyValuePair<int, int>(0, 0),
        new KeyValuePair<int, int>(1, 1),
        new KeyValuePair<int, int>(2, 0),
        new KeyValuePair<int, int>(3, 3)
    };

    // Start is called before the first frame update
    void Start()
    {
         musicId = Random.Range(0, 4);
         print("music ID " + musicId);
        //musicSource.clip = clips[musicId];

        
    }

    void FillImages()
    {
        for (int i = 0; i < 4; i++)
        {
            buttons[i].sprite = names[musicId * 4 + i];
            var script = buttons[i].GetComponent<ButtonAnimation>();
            btnAnims.Add(script);
            script.Setup();
        }
        StartCoroutine(AnimateBtns());
    }

    public IEnumerator AnimateBtns()
    {
        yield return new WaitForSeconds(1f);
        
        for (int i = 0; i < 4; i++)
        {
            btnAnims[i].Animate();
            yield return new WaitForSeconds(0.5f);
        }
            
    }

    public void TouchButton(int index)
    {
        StartCoroutine(TouchButtonAction(index));
        
    }

    IEnumerator TouchButtonAction(int index)
    {
        btnAnims[index].SelectButton();
        yield return new WaitForSeconds(0.5f);
        NextScreen(index == correctResponses[musicId].Value);
    }

    public void NextScreen(bool won)
    {
        print("Won? " + won);
        if (won)
            appController.LoadScreen(Screens.Reward);
        else
            appController.LoadScreen(Screens.Final);

    }

    public override void ShowScreen()
    {
        StartCoroutine(ShowScreenWorker());

        //animate buttons

        PlayClip();

        FillImages();
    }

    public void PlayClip()
    {
        musicSource.Play();
    }


    public override void HideScreen()
    {
        StartCoroutine(HideScreenWorker());
    }
}
