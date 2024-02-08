using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTrigger : MonoBehaviour
{
    public GameObject FirstButton;
    public GameObject SecondButton;
    // Start is called before the first frame update
    void Start()
    {
        FirstButton.SetActive(false);
        SecondButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerStay2D(Collider2D col)
    {
        if (!col.gameObject.CompareTag("Player")) return;
        FirstButton.SetActive(true);
        SecondButton.SetActive(true);
    }
    public void OnTriggerExit2D(Collider2D col)
    {
        if (!col.gameObject.CompareTag("Player")) return;
        FirstButton.SetActive(false);
        SecondButton.SetActive(false);
    }
}
