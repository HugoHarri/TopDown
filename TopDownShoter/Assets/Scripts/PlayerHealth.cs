using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int health = 100; // Здоровье игрока
    private GameManager gameManager;
    private Renderer playerRenderer; // Рендерер игрока
    private Color originalColor; // Исходный цвет игрока

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        playerRenderer = GetComponent<Renderer>(); // Получить рендерер игрока
        originalColor = playerRenderer.material.color; // Сохранить исходный цвет
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health < 0)
        {
            health = 0;
        }

        Debug.Log("Player took damage. Current health: " + health);

        // Окрашиваем игрока в красный цвет при получении урона
        FlashRed();

        if (health <= 0)
        {
            Die(); // Умирает, если здоровье <= 0
        }
    }

    private void FlashRed()
    {
        playerRenderer.material.color = Color.red; // Меняем цвет на красный
        Invoke("ResetColor", 0.2f); // Возвращаем цвет через 0.2 секунды
    }

    private void ResetColor()
    {
        playerRenderer.material.color = originalColor; // Возвращаем исходный цвет
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