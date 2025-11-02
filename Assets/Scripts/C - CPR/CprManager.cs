using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
public class CprManager : MonoBehaviour
{
    public AudioSource theMusic;
    public bool startPlaying;
    public BeatScroller bScrl;
    public static CprManager instance;
    public int currentScore;
    public int scorePerNote = 100;
    public int currentMissed;
    public Text hitText;
    public Text missedText;
    void Start()
    {
        instance = this;
        hitText.text = "Hit: 0 / 30";
        currentMissed = 0;
    }
    void Update()
    {
        if (!startPlaying)
        {
            if (Input.anyKeyDown)
            {
                startPlaying = true;
                bScrl.hasStarted = true;
                theMusic.Play();
            }
        }
    }
    public void NoteHit()
    {
        currentScore += scorePerNote;
        hitText.text = "Hit: "+currentScore+" / 30";
    }
    public void NoteMiss()
    {
        currentMissed += 1;
        missedText.text = "Missed: " + currentMissed;
    }
    public void NormalHit()
    {
        NoteHit();
    }
    public void GoodHit()
    {
        NoteHit();
    }
    public void PerfectHit()
    {
        NoteHit();
    }
}
