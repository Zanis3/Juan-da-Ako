using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChoiceScript : MonoBehaviour
{
    public Animator animate;
    public string clip;
    public void ClipToPlay()
    {
        animate.SetTrigger(clip);
    }
}
