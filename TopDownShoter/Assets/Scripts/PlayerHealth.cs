using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

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

        if (health < 0)
        {
            health = 0;
        }

        Debug.Log("Player took damage. Current health: " + health);

        if (health <= 0)
        {
            Die(); // Умирает, если здоровье <= 0
        }
    }

    private void Die()
    {
        Debug.Log("Player died.");
        LoadMenu(); // Переход к сцене меню
    }

    private void LoadMenu()
    {
        // Загрузка сцены меню
        SceneManager.LoadScene("Menu"); 
    }
}