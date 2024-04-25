using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTrigger : MonoBehaviour
{
    public GameObject FirstButton;
    public GameObject SecondButton;
    
    public int Cost = 100;
    public int Cost2 = 100;

    private ScoreManager _scoreManager;
    // Start is called before the first frame update
    void Start()
    {
        if (FirstButton != null)
        {
            FirstButton.SetActive(false);
        }
        if (SecondButton != null)
        {
            SecondButton.SetActive(false);
        }
        
        _scoreManager = FindObjectOfType<ScoreManager>();
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
            if (Cost <= _scoreManager.CoinAmount && FirstButton != null)
            {
                FirstButton.SetActive(true);
            }
            else
            {
                FirstButton.SetActive(false);
            }
            if (Cost2  <= _scoreManager.CoinAmount && SecondButton != null)
            {
                SecondButton.SetActive(true);
            }
            else
            {
                SecondButton.SetActive(false);
            }

        }
    }
    public void OnTriggerExit2D(Collider2D col)
    {
        if (!col.gameObject.CompareTag("Player")) return;

        if (FirstButton != null)
        {
            FirstButton.SetActive(false);
        }
        if (SecondButton != null)
        {
            SecondButton.SetActive(false);
        }
    }
}
