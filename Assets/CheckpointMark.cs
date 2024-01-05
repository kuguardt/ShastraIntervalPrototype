using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckpointMark : MonoBehaviour
{
    public float checkpointMark = 10.0f;
    public Image checkpointBG;

    public Slider progressSlider;

    private void Update()
    {
        if (progressSlider.value >= checkpointMark)
        {
            checkpointBG.color = new Color(1, 0, 0);
        }
    }
}
