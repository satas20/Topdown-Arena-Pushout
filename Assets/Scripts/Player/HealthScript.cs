using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float maxHealth;
    [SerializeField] private float currentHealth;
    [SerializeField] private Slider healthbar;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void takeDamage(float damage){
        currentHealth -= damage;
        if (currentHealth <= 0) { Destroy(gameObject); }
    }
    public float missingHealth() { return maxHealth / currentHealth; }

    private void updateUI(){
        healthbar.maxValue = maxHealth;
        healthbar.value = currentHealth;
    }
}
