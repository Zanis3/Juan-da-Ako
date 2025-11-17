using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class DistanceManager : MonoBehaviour
{
    public Text distanceText;
    private float distance;
    public float finishLine;
    public GameObject victoryScreen;
    public LifeLineDashCameraMovement cam;
    public LifeLineDashLoopingBackground bg;
    public SpawnObstacles obs;
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            distance +=1 * Time.deltaTime;
            distanceText.text = distance+"/"+finishLine+" M";
        }
        if (distance >= finishLine)
        {

            cam.cameraSpeed = 0f;
            bg.backgroundSpeed = 0f;
            obs.spawnTime = 0f;
            Invoke("Delay", 1f);
        }
    }
    public void Delay()
    {
        Time.timeScale = 0f;
        victoryScreen.SetActive(true);
    }
}
