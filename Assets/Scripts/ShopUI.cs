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

    private ShopUpgrades _shopUpgrades;

    public string HealthUpgrade = "ShopHealthUpgrade";
    public string ArmorUpgrade = "ShopArmorUpgrade";
    public string BombUpgrade = "ShopBombUpgrade";

    private SecondScene _secondScene;
    // Start is called before the first frame update
    void Start()
    {
        _shopUpgrades = shopUI.GetComponent<ShopUpgrades>();
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
        PlayerPrefs.SetInt(HealthUpgrade, _shopUpgrades.HealthInput);
        PlayerPrefs.SetInt(ArmorUpgrade, _shopUpgrades.ArmorInput);
        PlayerPrefs.SetInt(BombUpgrade, _shopUpgrades.BombInput);
    }
    public void LoadShop()
    {
        _shopUpgrades.HealthInput = PlayerPrefs.GetInt(HealthUpgrade);
        _shopUpgrades.ArmorInput = PlayerPrefs.GetInt(ArmorUpgrade);
        _shopUpgrades.BombInput = PlayerPrefs.GetInt(BombUpgrade);
    }
}
