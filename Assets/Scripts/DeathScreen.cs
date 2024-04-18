using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScreen : MonoBehaviour
{
    private Health _health;
    public GameObject _deathScreen;
    public float Cooldown = 3f;

    private SceneLoader _sceneLoader;
    // Start is called before the first frame update
    void Start()
    {
        _sceneLoader = GameObject.Find("GameManager").GetComponent<SceneLoader>();
        _health = GameObject.Find("Player").GetComponent<Health>();
        if (!_deathScreen)
            return;
        if (_deathScreen != null)
        {
            _deathScreen.SetActive(false);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_health.CurrentHealth <= 0)
        {
            Invoke("ActivateScreen", Cooldown);
        }
    }
    private void ActivateScreen()
    {
        _sceneLoader.LoadDeathScene();
    }
}
