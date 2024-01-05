using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHoverEvent : MonoBehaviour
{
    public Image ButtonImage;

    public void OnButtonEnter()
    {
        ButtonImage.color = new Color(1, 0, 0);
    }

    public void OnButtonExit()
    {
        ButtonImage.color = new Color(1, 1, 0);
    }
}
