using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateChallenge : MonoBehaviour
{
    public Transform canvasQuest;
    public CircleCollider2D colisor;
    // Start is called before the first frame update
    void Start()
    {
        colisor = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canvasQuest.gameObject.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player")){
            canvasQuest.gameObject.SetActive(false);
        }
    }
}
