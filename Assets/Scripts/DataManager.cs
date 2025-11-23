using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public int vnLevelAt;
    public int achievementLevelAt;
    public int aidMasterQuizLevelAt;
    public int lifeLineDashLevelAt;
    public int galleryLevelAt;
    public int gameCode;

    void Start()
    {
        switch (gameCode)
        {
            case 1:
                if (vnLevelAt > PlayerPrefs.GetInt("p_vnLevelAt", 0))
                {
                    PlayerPrefs.SetInt("p_vnLevelAt", vnLevelAt);
                    PlayerPrefs.Save();
                }
            break;
            case 2:
                if (achievementLevelAt > PlayerPrefs.GetInt("p_achievementLevelAt", 0))
                {
                    PlayerPrefs.SetInt("p_achievementLevelAt", vnLevelAt);
                    PlayerPrefs.Save();
                }
            break;
            case 3:
                if (aidMasterQuizLevelAt > PlayerPrefs.GetInt("p_aidMasterQuizLevelAt", 0))
                {
                    PlayerPrefs.SetInt("p_aidMasterQuizLevelAt", vnLevelAt);
                    PlayerPrefs.Save();
                }
            break;
            case 4:
                if (lifeLineDashLevelAt > PlayerPrefs.GetInt("p_lifeLineDashLevelAt", 0))
                {
                    PlayerPrefs.SetInt("p_lifeLineDashLevelAt", vnLevelAt);
                    PlayerPrefs.Save();
                }
            break;
            case 5:
                if (galleryLevelAt > PlayerPrefs.GetInt("p_galleryLevelAt", 0))
                {
                    PlayerPrefs.SetInt("p_galleryLevelAt", vnLevelAt);
                    PlayerPrefs.Save();
                }
            break;
            default:
            break;
        }
    }
    public void DataLoad()
    {
        vnLevelAt = PlayerPrefs.GetInt("p_vnLevelAt", 0);
        achievementLevelAt = PlayerPrefs.GetInt("p_achievementLevelAt", 0);
        aidMasterQuizLevelAt = PlayerPrefs.GetInt("p_aidMasterQuizLevelAt", 0);
        lifeLineDashLevelAt = PlayerPrefs.GetInt("p_lifeLineDashLevelAt", 0);
        galleryLevelAt = PlayerPrefs.GetInt("p_galleryLevelAt", 0);
    }
    public void UnlockEverything()
    {
        PlayerPrefs.SetInt("p_vnLevelAt", 5);
        PlayerPrefs.SetInt("p_achievementLevelAt", 5);
        PlayerPrefs.SetInt("p_aidMasterQuizLevelAt", 5);
        PlayerPrefs.SetInt("p_lifeLineDashLevelAt", 5);
        PlayerPrefs.SetInt("p_galleryLevelAt", 5);
        PlayerPrefs.Save();
    }
}
