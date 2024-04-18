using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTrigger : MonoBehaviour
{
    public GameObject FirstButton;
    public GameObject SecondButton;
    public int Cost = 100;

    private ScoreManager _scoreManager;
    // Start is called before the first frame update
    void Start()
    {
        FirstButton.SetActive(false);
        SecondButton.SetActive(false);
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
            if (Cost <= _scoreManager.CoinAmount)
            {
                FirstButton.SetActive(true);
                SecondButton.SetActive(true);
            }

            if (_scoreManager.CoinAmount <= Cost)
            {
                FirstButton.SetActive(false);
                SecondButton.SetActive(false);
            }

        }
    }
    public void OnTriggerExit2D(Collider2D col)
    {
        if (!col.gameObject.CompareTag("Player")) return;
        FirstButton.SetActive(false);
        SecondButton.SetActive(false);
    }
}
