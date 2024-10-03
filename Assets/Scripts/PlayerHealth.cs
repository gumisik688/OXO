using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float playerHealth = 100f;
    [SerializeField] Canvas healthCanvas;

    public TextMeshProUGUI healthText;

    private void Start()
    {
        healthCanvas.enabled = true;
    }

    private void Update()
    {
        healthText.text = playerHealth.ToString();
        if(playerHealth <= 0)
        {
            healthText.text = "0";
        }
    }
        

    public void TakeDamage(float damage)
    {
        playerHealth -= damage;
        if (playerHealth <= 0)
        {             
                GetComponent<DeathHandler>().HandleDeath();
        }
    }
}
