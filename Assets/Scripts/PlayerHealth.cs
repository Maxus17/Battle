using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float value = 100;
    public RectTransform valueRectTransform;

    private float _maxValue;

    public GameObject gameplayUI;
    public GameObject gameOverScreen;

    void Start()
    {
        _maxValue = value;
        DrawnHealthBar();
        ShowGamePlay();
        HideGameOver();
    }
    public void DealDamage(float damage)
    {
        value -= damage;
        if (value <= 0)
        {
            HideGamePlay();
            ShowGameOver();
            GetComponent<PlayerContoller>().enabled = false;
            GetComponent<FireballCaster>().enabled = false;
            GetComponent<CameraRotations>().enabled = false;
        }
        DrawnHealthBar();
    }
    private void DrawnHealthBar()
    {
        valueRectTransform.anchorMax = new Vector2(value / _maxValue, 1);
    }
    
    public void ShowGamePlay()
    {
        gameplayUI.SetActive(true);
    }
    public void HideGamePlay()
    {
        gameplayUI.SetActive(false);
    }

    public void ShowGameOver()
    {
        gameOverScreen.SetActive(true);
    }
    public void HideGameOver()
    {
        gameOverScreen.SetActive(false);
    }
    public void AddHealth(float amount)
    {
        value += amount;
        value = Mathf.Clamp(value, 0, _maxValue);
        DrawnHealthBar();
    }
}
