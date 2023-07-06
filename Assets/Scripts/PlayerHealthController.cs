using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// INHERITANCE: The player's health bar has an extra component that states the health value
public class PlayerHealthController : HealthController
{
    public TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // POLYMORPHISM: Override method to update text component next to health bar
    public override void UpdateHealth(float value)
    {
        health += value;
        slider.value += value;
        text.text = health + " / " + maxHealth;

        GameManager.instance.SetPlayerHealth(health); // update GameManager
    }
}
