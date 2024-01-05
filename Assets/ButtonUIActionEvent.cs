using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonUIActionEvent : MonoBehaviour
{
    public PlayerProfileUI playerProfileUI;
    public void HangoutTalk()
    {
        playerProfileUI.UseAction(1);
        PlayerData.instance.currentActivity = "Hangout";
        SceneLoader.instance.loadActivityScene();
    }
    public void GoToActivity()
    {
        playerProfileUI.UseAction(1);
        PlayerData.instance.currentActivity = SceneLoader.instance.currentScene;
        if (SceneLoader.instance.currentScene != "Lecture")
        {
            SceneLoader.instance.loadActivityScene();
        }
        else
        {
            SceneLoader.instance.loadLectureScene();
        }
    }
    public void BackToMapScene()
    {
        SceneLoader.instance.loadScene("MapScene");
    }
}
