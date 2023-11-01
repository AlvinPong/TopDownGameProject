using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArmorBarUI : MonoBehaviour
{
    public float AnimationSpeed = 1.0f;

    public Image Armor;

    bool IsAnimating = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetArmor(float value)
    {
        if (IsAnimating) return;
        StartCoroutine(AnimateArmorBar(value));
    }
    IEnumerator AnimateArmorBar(float value)
    {
        IsAnimating = true;
        
        float currentValue = Armor.fillAmount;

        float targetValue = value;

        float duration = AnimationSpeed;

        while (duration > 0)
        {
            Armor.fillAmount = Mathf.Lerp(targetValue, currentValue, duration/ AnimationSpeed);
            duration -= Time.deltaTime;
            yield return null;
        }

        IsAnimating = false;
    }
}
