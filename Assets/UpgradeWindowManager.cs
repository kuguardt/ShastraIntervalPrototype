using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class UpgradeWindowManager : MonoBehaviour
{
    public float MovingTime = 1.0f;
    public float Distance = 100.0f;

    //Player Status
    public TextMeshProUGUI status_knowledge_text;
    public TextMeshProUGUI status_charm_text;
    public TextMeshProUGUI status_kindness_text;
    public TextMeshProUGUI status_proficiency_text;

    //Upgrade Status
    public TextMeshProUGUI upgrade_knowledge_text;
    public TextMeshProUGUI upgrade_charm_text;
    public TextMeshProUGUI upgrade_kindness_text;
    public TextMeshProUGUI upgrade_proficiency_text;

    //Original Upgrade Status Position
    Transform upgrade_knowledge_trans;
    Transform upgrade_charm_trans;
    Transform upgrade_kindness_trans;
    Transform upgrade_proficiency_trans;

    bool isMoving = false;

    [Serializable]
    public struct ActivityUpgrade 
    {
        public string ActivityName;

        public int upgrade_knowledge;
        public int upgrade_charm;
        public int upgrade_kindness;
        public int upgrade_proficency;
    }
    [SerializeField]
    public List<ActivityUpgrade> activities;

    public void UpgradeStatus(string activity)
    {
        foreach (ActivityUpgrade data in activities)
        {
            if (data.ActivityName == activity)
            {
                upgrade_knowledge_text.text = "+ " + data.upgrade_knowledge;
                upgrade_charm_text.text = "+ " + data.upgrade_charm;
                upgrade_kindness_text.text = "+ " + data.upgrade_kindness;
                upgrade_proficiency_text.text = "+ " + data.upgrade_proficency;

                upgrade_knowledge_text.gameObject.SetActive(data.upgrade_knowledge != 0);
                upgrade_charm_text.gameObject.SetActive(data.upgrade_charm != 0);
                upgrade_kindness_text.gameObject.SetActive(data.upgrade_kindness != 0);
                upgrade_proficiency_text.gameObject.SetActive(data.upgrade_proficency != 0);

                PlayerData.instance.status_knowledge += data.upgrade_knowledge;
                PlayerData.instance.status_charm += data.upgrade_charm;
                PlayerData.instance.status_kindness += data.upgrade_kindness;
                PlayerData.instance.status_proficency += data.upgrade_proficency;
            }
        }
        StartCoroutine(PlayerUpgradeAnimation());
    }

    private void Start()
    {
        UpdateStatusUI();

        upgrade_knowledge_trans = upgrade_knowledge_text.gameObject.transform;
        upgrade_charm_trans = upgrade_charm_text.gameObject.transform;
        upgrade_kindness_trans = upgrade_kindness_text.gameObject.transform;
        upgrade_proficiency_trans = upgrade_proficiency_text.gameObject.transform;

        UpgradeStatus(PlayerData.instance.currentActivity);
    }

    private void Update()
    {
        if (isMoving)
        {
            float speed = Distance * Time.deltaTime / MovingTime;

            upgrade_knowledge_text.gameObject.transform.position += new Vector3(speed, 0, 0);
            upgrade_charm_text.gameObject.transform.position += new Vector3(speed, 0, 0);
            upgrade_kindness_text.gameObject.transform.position += new Vector3(speed, 0, 0);
            upgrade_proficiency_text.gameObject.transform.position += new Vector3(speed, 0, 0);
        }
        else
        {
            upgrade_knowledge_text.gameObject.transform.position = upgrade_knowledge_trans.position;
            upgrade_charm_text.gameObject.transform.position = upgrade_charm_trans.position;
            upgrade_kindness_text.gameObject.transform.position = upgrade_kindness_trans.position;
            upgrade_proficiency_text.gameObject.transform.position = upgrade_proficiency_trans.position;
        }
    }

    private IEnumerator PlayerUpgradeAnimation()
    {
        isMoving = true;
        yield return new WaitForSeconds(MovingTime);
        isMoving = false;
        UpdateStatusUI();
        upgrade_knowledge_text.gameObject.SetActive(false);
        upgrade_charm_text.gameObject.SetActive(false);
        upgrade_kindness_text.gameObject.SetActive(false);
        upgrade_proficiency_text.gameObject.SetActive(false);
    }

    public void UpdateStatusUI()
    {
        status_knowledge_text.text = PlayerData.instance.status_knowledge.ToString();
        status_charm_text.text = PlayerData.instance.status_charm.ToString();
        status_kindness_text.text = PlayerData.instance.status_kindness.ToString();
        status_proficiency_text.text = PlayerData.instance.status_proficency.ToString();
    }
}
