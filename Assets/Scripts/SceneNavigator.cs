using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SceneNavigator : MonoBehaviour
{
    public GameObject activeScene;
    public GameObject nextScene;
    public void SceneNavigation()
    {
        activeScene.SetActive(false);
        nextScene.SetActive(true);
    }
}
