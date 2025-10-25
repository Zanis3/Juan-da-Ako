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
    public void VolumeActive()
    {
        volumeT.SetActive(false);
        volumeF.SetActive(true);
        activeScene.SetActive(true);
        nextScene.SetActive(false);
    }
    public void VolumeInactive()
    {
        volumeT.SetActive(true);
        volumeF.SetActive(false);
        activeScene.SetActive(false);
        nextScene.SetActive(true);
    }

}
