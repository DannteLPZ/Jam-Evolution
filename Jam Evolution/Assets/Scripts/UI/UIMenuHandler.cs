using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMenuHandler : MonoBehaviour
{
    public void ShowCanvasGroup(CanvasGroup group)
    {
        group.alpha = 1.0f;
        group.interactable = true;
        group.blocksRaycasts = true;
    }

    public void HideCanvasGroup(CanvasGroup group)
    {
        group.alpha = 0.0f;
        group.interactable = false;
        group.blocksRaycasts = false;
    }
}
