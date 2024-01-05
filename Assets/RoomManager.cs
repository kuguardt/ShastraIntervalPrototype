using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RoomManager : MonoBehaviour
{
    public TextMeshProUGUI roomNameText;
    public TextMeshProUGUI actionText;

    public GameObject friendButton;
    public TextMeshProUGUI friendText;

    public Image backgroundImage;

    // All Activity
    public Sprite game;
    public Sprite lecture;
    public Sprite library;
    public Sprite gym;
    public Sprite park;
    public Sprite area;

    public void Start()
    {
        InitRoomData(SceneLoader.instance.currentScene);
    }

    public void InitRoomData(string RoomName)
    {
        roomNameText.text = RoomName;
        switch (RoomName)
        {
            case "Game":
                backgroundImage.sprite = game;
                actionText.text = "Play Game";
                break;
            case "Lecture":
                backgroundImage.sprite = lecture;
                actionText.text = "Taking Course";
                break;
            case "Library":
                backgroundImage.sprite = library;
                actionText.text = "Reading Book";
                break;
            case "Gym":
                backgroundImage.sprite = gym;
                actionText.text = "Play Sport";
                break;
            case "Park":
                backgroundImage.sprite = park;
                actionText.text = "Rest";
                break;
            case "Shop":
                //backgroundImage.sprite = game;
                break;
            case "Arena":
                backgroundImage.sprite = area;
                actionText.text = "Traning";
                break;
            default:
                Debug.LogError("RoomName is not valid");
                break;
        }

        friendButton.SetActive(false);
        foreach (FriendData data in FriendDataStorage.instance.friends)
        {
            if (data.currentlocation == RoomName)
            {
                friendButton.SetActive(true);
                friendText.text = data.friendName;
            }
        }
    }
}
