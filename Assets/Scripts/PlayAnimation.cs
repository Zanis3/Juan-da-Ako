using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayAnimation : MonoBehaviour
{
    public Animator animate;
    public string sceneLoad;
    public string clip;
    public string clipTwo;
    public GameObject victoryScreen;
    public void ClipToPlay()
    {
        animate.SetTrigger(clip);
    }
    public void ClipToPlay2nd()
    {
        animate.SetTrigger(clipTwo);
    }
    public void OnAnimationEnd()
    {
        victoryScreen.SetActive(true);
    }
}
