using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarManager : MonoBehaviour
{
    public Slider progressBarSlider;

    string currentCourseName = "";
    float currentIncreaseAmount;
    float currentDuration;
    bool isIncreasing = false;

    private void Start()
    {
        UpdateProgressBar(PlayerData.instance.currentCourse);
        IncreseProgressBar(30.0f, 1.0f);
    }

    public void UpdateProgressBar(string courseName)
    {
        foreach (LectureData data in LectureDataManager.instance.lectures)
        {
            if (data.courseName == courseName)
            {
                progressBarSlider.maxValue = data.MaxProgress;
                progressBarSlider.value = data.currentProgress;
            }
        }
        currentCourseName = courseName;
    }

    private void Update()
    {
        if (isIncreasing)
        {
            float speed = currentIncreaseAmount * Time.deltaTime / currentDuration;
            progressBarSlider.value += speed;
        }
        else
        {
            UpdateProgressBar(PlayerData.instance.currentCourse);
        }
    }

    public void IncreseProgressBar(float increaseAmount, float duration)
    {
        foreach (LectureData data in LectureDataManager.instance.lectures)
        {
            if (data.courseName == currentCourseName)
            {
                data.currentProgress += increaseAmount;
            }
        }
        currentIncreaseAmount = increaseAmount;
        currentDuration = duration;
        StartCoroutine(IncresingProgressBar(increaseAmount, duration));
    }

    private IEnumerator IncresingProgressBar(float increaseAmount, float duration)
    {
        isIncreasing = true;
        yield return new WaitForSeconds(duration);
        isIncreasing = false;
    }
}
