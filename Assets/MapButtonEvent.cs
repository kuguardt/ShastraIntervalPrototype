using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapButtonEvent : MonoBehaviour
{
    public Image ButtonImage;
    public GameObject DetailBox;

    public Sprite icon;
    public string locationName;
    private MapDetailBox m_DetailBox;

    Color baseButtonColor = new Color(1.0f, 1.0f, 0);

    public void Start()
    {
        m_DetailBox = DetailBox.GetComponent<MapDetailBox>();
        DetailBox.SetActive(false);
        m_DetailBox.SetDetailBox(icon, locationName);
    }

    public void Update()
    {
        if (UpdateBaseColor())
        {
            ButtonImage.color = baseButtonColor;
        }
        else
        {
            baseButtonColor = new Color(1.0f, 1.0f, 0);
            ButtonImage.color = baseButtonColor;
        }
    }

    public bool UpdateBaseColor()
    {
        foreach (FriendData data in FriendDataStorage.instance.friends)
        {
            if (data.currentlocation == locationName)
            {
                if (baseButtonColor != new Color(1.0f, 0.5f, 0))
                {
                    baseButtonColor = new Color(1.0f, 0.5f, 0);
                }
                return true;
            }
        }
        return false;
    }

    public void OnButtonEnter()
    {
        DetailBox.SetActive(true);
        ButtonImage.color = new Color(1,0,0);
    }

    public void LoadScene()
    {
        SceneLoader.instance.loadScene(locationName);
    }

    public void OnButtonExit()
    {
        DetailBox.SetActive(false);
        ButtonImage.color = baseButtonColor;
    }
}
