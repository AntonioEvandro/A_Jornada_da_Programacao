using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateChallenge : MonoBehaviour
{
    public Transform canvasQuest;
    public void ActiveQuest()
    {
        canvasQuest.gameObject.SetActive(true);
    }
    public void DesactiveQuest()
    {
        canvasQuest.gameObject.SetActive(false);
    }
}
