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

    public string HealthUpgrade = "ShopHealthUpgrade";
    public string ArmorUpgrade = "ShopArmorUpgrade";
    public string BombUpgrade = "ShopBombUpgrade";

    public int HealthInput = 0;
    public int ArmorInput = 0;
    public int BombInput = 0;

    private SecondScene _secondScene;
    // Start is called before the first frame update
    void Start()
    {
        
        LoadShop();
        if (shopUI != null)
            shopUI.SetActive(false);
        spawnManager = GameObject.FindObjectOfType<SpawnManager>();
        _secondScene = GameObject.Find("GameManager").GetComponent<SecondScene>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnManager.MaxPerWave > 0 || spawnManager.CurrentZombies > 0 || !PlayerInRange || InShop) return;
        
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
        SaveShop();
        shopUI.SetActive(false);
        InShop = false;
    }
    public void SaveShop()
    {
        PlayerPrefs.SetInt(HealthUpgrade, HealthInput);
        PlayerPrefs.SetInt(ArmorUpgrade, ArmorInput);
        PlayerPrefs.SetInt(BombUpgrade, BombInput);
    }
    public void LoadShop()
    {
        HealthInput = PlayerPrefs.GetInt(HealthUpgrade);
        ArmorInput = PlayerPrefs.GetInt(ArmorUpgrade);
        BombInput = PlayerPrefs.GetInt(BombUpgrade);
    }
}
