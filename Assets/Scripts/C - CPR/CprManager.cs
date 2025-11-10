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
    public float totalNotes;
    public float totalHit;
    public float normalHit;
    public float goodHit;
    public float perfectHit;
    public float missedHit;
    public GameObject nextScenarioPrototype;
    //public Text precentHitText, normalText, goodText, perfectText, missText, finalScore;
    void Start()
    {
        instance = this;
        hitText.text = "Hit: 0 / 30";
        currentMissed = 0;
        totalNotes = FindObjectsOfType<NoteObject>().Length;
    }
    void Update()
    {
        totalHit = normalHit + goodHit + perfectHit + missedHit;
        if (!startPlaying)
        {
            if (Input.anyKeyDown)
            {
                startPlaying = true;
                bScrl.hasStarted = true;
                theMusic.Play();
            }
        }
        else
        {
            if (totalHit == totalNotes)
            {
                nextScenarioPrototype.SetActive(true);
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
        missedHit = currentMissed;
    }
    public void NormalHit()
    {
        NoteHit();
        normalHit++;
    }
    public void GoodHit()
    {
        NoteHit();
        goodHit++;
    }
    public void PerfectHit()
    {
        NoteHit();
        perfectHit++;
    }
}
