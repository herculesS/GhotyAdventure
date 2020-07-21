using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameWon : MonoBehaviour
{
    [SerializeField] CanvasGroup group;

    public void Show()
    {
        group.alpha = 1;
        group.interactable = true;
        group.blocksRaycasts = true;
    }

}
