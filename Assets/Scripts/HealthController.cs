using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    public Slider slider;
    protected float maxHealth;
    protected float health;

    // Start is called before the first frame update
    void Start()
    {
        //slider.maxValue = maxHealth;
        //slider.value = maxHealth;
        slider.fillRect.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void UpdateHealth(float value)
    {
        health += value;
        slider.value += value;
    }

    public virtual void SetMaxHealth(float value)
    {
        maxHealth = value;
        slider.maxValue = value;
    }
    public virtual void SetHealth(float value)
    {
        if (value < 0)
        {
            Debug.LogError("Health value cannot be negative.");
        }
        else
        {
            health = value;
            slider.value = value;
            UpdateHealth(0);
        }
    }
}
