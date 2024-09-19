using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100; // Максимальное здоровье
    private int currentHealth;   // Текущее здоровье

    void Start()
    {
        currentHealth = maxHealth; // Устанавливаем текущее здоровье на максимальное при старте
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Уменьшаем текущее здоровье на полученный урон
        if (currentHealth <= 0)
        {
            Die(); // Если здоровье ниже или равно 0, вызываем метод смерти
        }
    }

    private void Die()
    {
        // Логика смерти (например, удалить объект, показать экран Game Over и т.д.)
        Debug.Log("Player has died.");
        Destroy(gameObject); // Уничтожаем капсулу (можно заменить на другую логику)
    }

    public int GetCurrentHealth()
    {
        return currentHealth; // Метод для получения текущего здоровья, если нужно
    }
}
