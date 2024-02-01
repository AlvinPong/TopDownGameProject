using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int CoinAmount = 100;
    public TMP_Text CoinText;
    public TMP_Text ShopCoinText;

    protected string SavedCoins = "PlayerSavedCoins";
    // Start is called before the first frame update
    void Start()
    {
        CoinText = GameObject.Find("CoinAmount").GetComponent<TMP_Text>();
        CoinAmount = PlayerPrefs.GetInt(SavedCoins, 100);
    }

    // Update is called once per frame
    void Update()
    {
        if (CoinText != null)
        {
            CoinText.text = CoinAmount.ToString();
        }
        if (ShopCoinText != null)
        {
            ShopCoinText.text = CoinAmount.ToString();
        }
        PlayerPrefs.SetInt(SavedCoins, CoinAmount);
    }
    public void AddCoin(int AddAmount)
    {
        CoinAmount += AddAmount;
    }
}
