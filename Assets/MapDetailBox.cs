using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MapDetailBox : MonoBehaviour
{
    public Image imageIcon;
    public TextMeshProUGUI textbox;

    public void SetDetailBox(Sprite icon, string name)
    {
        imageIcon.sprite = icon;
        textbox.text = name;
    }
}
