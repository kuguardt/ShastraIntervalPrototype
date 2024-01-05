using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum LocationName
{
    Game = 0,
    Lecture = 1,
    Library = 2,
    Gym = 3,
    Park = 4,
    Shop = 5,
    Arena = 6
}

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader instance { get; private set; }

    public string currentScene = ":D";

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    public string LocationEnumString(int location)
    {
        switch (location)
        {
            case 0:
                return "Game";
            case 1:
                return "Lecture";
            case 2:
                return "Library";
            case 3:
                return "Gym";
            case 4:
                return "Park";
            case 5:
                return "Shop";
            case 6:
                return "Arena";
            default:
                return "Map";
        }
    }

    public string LocationEnumString(LocationName location)
    {
        switch (location)
        {
            case LocationName.Game:
                return "Game";
            case LocationName.Lecture:
                return "Lecture";
            case LocationName.Library:
                return "Library";
            case LocationName.Gym:
                return "Gym";
            case LocationName.Park:
                return "Park";
            case LocationName.Shop:
                return "Shop";
            case LocationName.Arena:
                return "Arena";
            default:
                return "Map";
        }
    }


    public void loadScene(string name)
    {
        switch (name)
        {
            case "Game":
            case "Library":
            case "Gym":
            case "Park":
            case "Arena":
            case "Shop":
            case "Lecture":
            case "Hangout":
                SceneManager.LoadScene("RoomScene");
                break;
            default:
                SceneManager.LoadScene("MapScene");
                break;
        }
        currentScene = name;
    }

    public void loadActivityScene()
    {
        SceneManager.LoadScene("ActivityScene");
    }

    public void loadLectureScene()
    {
        SceneManager.LoadScene("LectureScene");
    }
}
