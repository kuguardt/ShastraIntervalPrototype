using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LectureDataManager : MonoBehaviour
{
    public List<LectureData> lectures;
    public static LectureDataManager instance { get; private set; }
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
}
