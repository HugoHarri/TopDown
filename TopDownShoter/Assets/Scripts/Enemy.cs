using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public float speed = 3f; // Скорость движения врага
    public int health = 100; // Здоровье врага
    private Transform player; // Ссылка на игрока
    private NavMeshAgent agent; // Компонент NavMeshAgent
    public int damage = 20; // Урон, наносимый врагом
    public float attackRange = 2f; // Дальность атаки
    public float attackCooldown = 2f; // Время перезарядки атаки

    private PlayerHealth playerHealth; // Ссылка на скрипт здоровья игрока
    private float lastAttackTime; // Время последней атаки
    private Renderer enemyRenderer; // Рендерер врага
    private Color originalColor; // Исходный цвет врага

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // Найти игрока
        agent = GetComponent<NavMeshAgent>(); // Получить компонент NavMeshAgent
        enemyRenderer = GetComponent<Renderer>(); // Получить рендерер врага

        if (agent == null)
        {
            Debug.LogError("NavMeshAgent component is missing.");
        }

        // Получить компонент PlayerHealth у игрока
        playerHealth = player.GetComponent<PlayerHealth>();

        // Сохранить исходный цвет врага
        originalColor = enemyRenderer.material.color;
    }

    private void Update()
    {
        if (player != null && agent != null)
        {
            MoveTowardsPlayer(); // Перемещение к игроку
            AttackPlayer(); // Атака игрока, если в пределах досягаемости
        }
    }

    private void MoveTowardsPlayer()
    {
        if (agent.isActiveAndEnabled && agent.isOnNavMesh)
        {
            // Устанавливаем цель для NavMeshAgent
            agent.SetDestination(player.position);
        }
    }

    private void AttackPlayer()
    {
        // Проверка расстояния до игрока
        if (Vector3.Distance(transform.position, player.position) <= attackRange)
        {
            // Проверка, можно ли атаковать
            if (Time.time >= lastAttackTime + attackCooldown)
            {
                // Наносим урон игроку
                playerHealth.TakeDamage(damage);
                Debug.Log("Enemy attacked player for " + damage + " damage.");
                lastAttackTime = Time.time; // Обновление времени последней атаки
            }
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Enemy took damage. Current health: " + health);
        if (health <= 0)
        {
            Die(); // Умирает, если здоровье <= 0
        }
        else
        {
            FlashRed(); // Окрашиваем врага в красный цвет при получении урона
        }
    }

    private void FlashRed()
    {
        enemyRenderer.material.color = Color.red; // Меняем цвет на красный
        Invoke("ResetColor", 0.2f); // Возвращаем цвет через 0.2 секунды
    }

    private void ResetColor()
    {
        enemyRenderer.material.color = originalColor; // Возвращаем исходный цвет
    }

    private void Die()
    {
        Debug.Log("Enemy died.");
        // Уничтожение объекта
        Destroy(gameObject);
    }
}