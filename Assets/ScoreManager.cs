using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int CoinAmount;
    public TMP_Text CoinText;
    public TMP_Text ShopCoinText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (CoinText == null) return;
        CoinText.text = CoinAmount.ToString();
        ShopCoinText.text = CoinAmount.ToString();
    }
    public void AddCoin(int AddAmount)
    {
        CoinAmount += AddAmount;
    }
}
