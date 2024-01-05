using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerProfileUI : MonoBehaviour
{
    public GameObject detailWindow;

    public TextMeshProUGUI actionText;
    public TextMeshProUGUI dayText;

    //Player Status
    public TextMeshProUGUI status_knowledge_text;
    public TextMeshProUGUI status_charm_text;
    public TextMeshProUGUI status_kindness_text;
    public TextMeshProUGUI status_proficiency_text;

    private void Start()
    {
        UpdateUIData();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            PlayerData.instance.currentAction--;
            UpdateUIData();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            PlayerData.instance.currentAction++;
            UpdateUIData();
        }
    }

    public void UseAction(int amount)
    {
        PlayerData.instance.currentAction -= amount;
        UpdateUIData();
    }

    public void NextDay()
    {
        PlayerData.instance.currentAction = PlayerData.instance.actionPerDay;
        PlayerData.instance.currentDay++;

        FriendDataStorage.instance.RandomFriendsLocation();
        UpdateUIData();
    }

    public void UpdateUIData()
    {
        actionText.text = "x " + PlayerData.instance.currentAction;
        dayText.text = "Day " + PlayerData.instance.currentDay;
    }

    public void ShowDetailWindow()
    {
        status_knowledge_text.text = PlayerData.instance.status_knowledge.ToString();
        status_charm_text.text = PlayerData.instance.status_charm.ToString();
        status_kindness_text.text = PlayerData.instance.status_kindness.ToString();
        status_proficiency_text.text = PlayerData.instance.status_proficency.ToString();

        detailWindow.SetActive(true);
    }

    public void CloseDetailWindow()
    {
        detailWindow.SetActive(false);
    }

}
