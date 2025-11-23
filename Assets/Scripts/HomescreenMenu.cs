using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
public class HomescreenMenu : MonoBehaviour
{
    [SerializeField] private CanvasGroup myUiGroup;
    [SerializeField] private bool fadeIn = false;
    public VideoPlayer videos;
    public AudioSource bgm;
    public float fadeSpeed = 0f;
    public string sceneLoad;
    public string url;
    public GameObject quitConfirm;
    public GameObject inviPanel;
    public GameObject disclaimerButton;
    public void ShowUI()
    {
        fadeIn = true;
    }
    void Start()
    {
        myUiGroup.alpha = 0;
        if (videos == null)
        {
            videos = GetComponent<VideoPlayer>();
        }
        videos.loopPointReached += OnVideoEnd;
    }
    void Update()
    {
        if (fadeIn)
        {
            if (myUiGroup.alpha < 1)
            {
                myUiGroup.alpha += fadeSpeed * Time.deltaTime;
                if (myUiGroup.alpha >= 1)
                {
                    fadeIn = false;
                }
            }
        }
    }
    public void NextScene()
    {
        SceneManager.LoadScene(sceneLoad);
    }
    void OnVideoEnd(VideoPlayer vp)
    {
        fadeIn = true;
        inviPanel.SetActive(false);
        bgm.Play();
    }
    void OnDisclaimerFalse(VideoPlayer vp)
    {

        bgm.Play();
    }
    void OnDestroy()
    {
        if (videos != null) 
        {
            videos.loopPointReached -= OnVideoEnd;
        }
    }
    public void QuitConfirmation()
    {
        quitConfirm.SetActive(true);
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void ContactDeveloper()
    {
        Application.OpenURL(url);
    }
}
