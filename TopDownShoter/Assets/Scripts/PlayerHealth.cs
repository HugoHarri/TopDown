using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 100; // Здоровье игрока
    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Player took damage. Current health: " + health);
        if (health <= 0)
        {
            Die(); // Умираем, если здоровье <= 0
        }
    }

    private void Die()
    {
        Debug.Log("Player died.");
        gameManager.ReloadScene(); // Перезагружаем сцену при смерти
    }
}
