using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class CountdownReturn : MonoBehaviour
{
    public float time = 0.0f;

    public Image imageObj;
    public GameObject videoObj;
    public VideoPlayer videoPlayer;

    // All Activity
    public Sprite hangout;
    public Sprite game;
    public VideoClip lecture;
    public Sprite library;
    public VideoClip gym;
    public Sprite park;
    public Sprite area;

    public void Start()
    {
        imageObj.gameObject.SetActive(false);
        videoObj.SetActive(false);

        PlayScene(PlayerData.instance.currentActivity);
    }

    public void PlayScene(string scene)
    {
        switch (scene)
        {
            case "Game":
                imageObj.sprite = game;
                imageObj.gameObject.SetActive(true);
                break;
            case "Lecture":
                videoPlayer.clip = lecture;
                videoObj.SetActive(true);
                break;
            case "Library":
                imageObj.sprite = library;
                imageObj.gameObject.SetActive(true);
                break;
            case "Gym":
                videoPlayer.clip = gym;
                videoObj.SetActive(true);
                break;
            case "Park":
                imageObj.sprite = park;
                imageObj.gameObject.SetActive(true);
                break;
            case "Shop":
                break;
            case "Hangout":
                imageObj.sprite = hangout;
                imageObj.gameObject.SetActive(true);
                break;
            case "Arena":
                imageObj.sprite = area;
                imageObj.gameObject.SetActive(true);
                break;
            default:
                imageObj.sprite = game;
                imageObj.gameObject.SetActive(true);
                break;
        }
        //StartCoroutine(LoadMapScene());
    }

    public IEnumerator LoadMapScene()
    {
        yield return new WaitForSeconds(time);
        SceneLoader.instance.loadScene("MapScene");
    }
}
