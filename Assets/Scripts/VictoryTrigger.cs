using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryTrigger : MonoBehaviour
{
    public GameObject Button;

    // Start is called before the first frame update
    void Start()
    {
        if(Button != null)
        {
            Button.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerStay2D(Collider2D col)
    {
        if (!col.gameObject.CompareTag("Player")) return;
        if (col.gameObject.CompareTag("Player"))
        {
            Button.SetActive(true);
        }
    }
    public void OnTriggerExit2D(Collider2D col)
    {
        if (!col.gameObject.CompareTag("Player")) return;
        if (col.gameObject.CompareTag("Player"))
        {
            Button.SetActive(false);
        }
    }
}
