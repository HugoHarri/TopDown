using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public float speed = 3f; // Скорость движения врага
    public int health = 100; // Здоровье врага
    private Transform player; // Ссылка на игрока
    private NavMeshAgent agent; // Навигационный агент
    public int damage = 20; // Урон, наносимый врагом
    public float attackRange = 2f; // Дистанция атаки
    public float attackCooldown = 2f; // Время между атаками

    private PlayerHealth playerHealth; // Ссылка на скрипт здоровья игрока
    private float lastAttackTime; // Время последней атаки

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // Находим игрока
        agent = GetComponent<NavMeshAgent>(); // Получаем ссылку на NavMeshAgent

        if (agent == null)
        {
            Debug.LogError("NavMeshAgent component is missing.");
        }

        // Находим компонент здоровья игрока
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    private void Update()
    {
        if (player != null && agent != null)
        {
            MoveTowardsPlayer(); // Двигаемся к игроку
            AttackPlayer(); // Проверяем, можем ли атаковать игрока
        }
    }

    private void MoveTowardsPlayer()
    {
        if (agent.isActiveAndEnabled && agent.isOnNavMesh)
        {
            // Устанавливаем точку назначения для врага — позиция игрока
            agent.SetDestination(player.position);
        }
    }

    private void AttackPlayer()
    {
        // Проверяем расстояние до игрока
        if (Vector3.Distance(transform.position, player.position) <= attackRange)
        {
            // Проверяем, прошло ли достаточно времени с последней атаки
            if (Time.time >= lastAttackTime + attackCooldown)
            {
                // Наносим урон игроку
                playerHealth.TakeDamage(damage);
                Debug.Log("Enemy attacked player for " + damage + " damage.");
                lastAttackTime = Time.time; // Обновляем время последней атаки
            }
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Enemy took damage. Current health: " + health);
        if (health <= 0)
        {
            Die(); // Умираем, если здоровье <= 0
        }
    }

    private void Die()
    {
        Debug.Log("Enemy died.");
        // Логика смерти (например, удаление врага)
        Destroy(gameObject);
    }
}