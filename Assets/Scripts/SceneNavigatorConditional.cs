using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneNavigatorConditional : MonoBehaviour
{
    public GameObject activeScene;
    public GameObject nextScene;
    public GameObject volumeT;
    public GameObject volumeF;
    public bool volumeActive = false;
    /*void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (volumeActive == true)
            {
                VolumeInactive();
            }
            else if (volumeActive == false)
            {
                VolumeActive();
            }
        }

    }*/
    public void VolumeActive()
    {
        volumeActive = true;
        volumeT.SetActive(true);
        volumeF.SetActive(false);
        activeScene.SetActive(false);
        nextScene.SetActive(true);
    }
    public void VolumeInactive()
    {
        volumeActive = false;
        volumeT.SetActive(false);
        volumeF.SetActive(true);
        activeScene.SetActive(true);
        nextScene.SetActive(false);
    }

}
