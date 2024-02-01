using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUI : MonoBehaviour
{
    public GameObject shopUI;
    protected bool PlayerInRange = false; 
    protected bool InShop = false;

    //indicate shop is available or unavailable
    protected bool IsOpen = false;

    private SpawnManager spawnManager;
    // Start is called before the first frame update
    void Start()
    {
        if(shopUI != null)
            shopUI.SetActive(false);
        spawnManager = GameObject.FindObjectOfType<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnManager.MaxPerWave > 0 || spawnManager.CurrentZombies > 0) return;
        if (!PlayerInRange)
            return;
        if (InShop)
            return;
        if(Input.GetKeyDown(KeyCode.E))
        {
            shopUI.SetActive(true);
            InShop = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.gameObject.CompareTag("Player"))
            return;
        PlayerInRange = true;
        //Debug.Log("InRange");
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (!col.gameObject.CompareTag("Player"))
            return;
        PlayerInRange = false;
        //Debug.Log("NotInRange");
    }
    public void CloseUI()
    {
        if (!InShop)
            return;
        shopUI.SetActive(false);
        InShop = false;
    }
}
