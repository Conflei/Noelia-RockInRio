using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScreen : ScreenBase
{
    int musicId;

    public AudioSource musicSource;
    public AudioClip[] clips;
    // Start is called before the first frame update
    void Start()
    {
        musicId = Random.Range(0, 3);
        print("music ID " + musicId);
        //musicSource.clip = clips[musicId];
    }

    public void TouchButton(int index)
    {
        // animate button touched
        
        NextScreen(index == musicId);
        
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
