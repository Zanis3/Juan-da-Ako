using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AMQLvlSelection : MonoBehaviour
{
    public string lvlName = "";
    public GameObject loadScreen;
    public Button[] loadBtns = new Button[0];

    void Start()
    {
        switch (PlayerPrefs.GetInt("p_aidMasterQuizLevelAt"))
        {
            case 1:
                loadBtns[0].interactable=true;
                loadBtns[1].interactable=false;
                loadBtns[2].interactable=false;
                loadBtns[3].interactable=false;
                break;
            case 2:
                loadBtns[0].interactable=true;
                loadBtns[1].interactable=true;
                loadBtns[2].interactable=false;
                loadBtns[3].interactable=false;
            break;
            case 3:
                loadBtns[0].interactable=true;
                loadBtns[1].interactable=true;
                loadBtns[2].interactable=true;
                loadBtns[3].interactable=false;
            break;
             case 4:
                loadBtns[0].interactable=true;
                loadBtns[1].interactable=true;
                loadBtns[2].interactable=true;
                loadBtns[3].interactable=true;
            break;
            default:
                //loadBtns[0].interactable=false;
                loadBtns[1].interactable=false;
                loadBtns[2].interactable=false;
                loadBtns[3].interactable=false;
                break;
        }
    }
    public void OpenLevels(int levelId)
    {
        lvlName = "AMQLvl"+levelId;
        Invoke("DelayLoad",0.2f);
    }

    void DelayLoad(){
        Debug.Log("Loading scene: " + lvlName);
        SceneManager.LoadScene(lvlName);
    }
}
