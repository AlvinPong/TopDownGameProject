using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public Slider Slider;
    public Color Low;
    public Color High;
    public Vector3 Offset; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Slider.transform.position = Camera.main.WorldToScreenPoint(transform.position + Offset);
    }
    public void SetHealth(float health, float MaxHealth)
    {
        Slider.gameObject.SetActive(health < MaxHealth);
        Slider.value = health;
        Slider.maxValue = MaxHealth;
        Debug.Log("Health is set");
        Slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(Low, High, Slider.normalizedValue);
    }
}
