using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public static PlayerData instance { get; private set; }

    public string playerName;
    public int actionPerDay;
    public int currentAction;
    public int currentDay;

    public int status_knowledge;
    public int status_charm;
    public int status_kindness;
    public int status_proficency;

    public string currentActivity;

    public string currentCourse;

    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("DataStorage");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
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
}
