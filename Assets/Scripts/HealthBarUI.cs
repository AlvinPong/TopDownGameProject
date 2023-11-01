using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    public float AnimationSpeed = 2.0f;

    public Image HealthBar;

    bool IsAnimating = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetHealth(float value)
    {
        if (IsAnimating) return;
        StartCoroutine(AnimateHealthBar(value));
    }
    IEnumerator AnimateHealthBar(float value)
    {
        IsAnimating = true;
        float currentValue = HealthBar.fillAmount;

        float targetValue = value;

        float duration = AnimationSpeed;

        while (duration > 0)
        {
            HealthBar.fillAmount = Mathf.Lerp(targetValue, currentValue, duration / AnimationSpeed);

            duration -= Time.deltaTime;
            yield return null;
        }

        IsAnimating = false;
    }
}
