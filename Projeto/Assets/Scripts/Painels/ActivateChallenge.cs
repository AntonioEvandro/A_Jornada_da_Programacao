using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateChallenge : MonoBehaviour
{
    public Transform canvasQuest;
    public GameObject AidsHUD;
    public void ActiveQuest()
    {
        canvasQuest.gameObject.SetActive(true);
        AidsHUD.SetActive(true);
    }
    public void DesactiveQuest()
    {
        canvasQuest.gameObject.SetActive(false);
        AidsHUD.SetActive(false);
    }
}
