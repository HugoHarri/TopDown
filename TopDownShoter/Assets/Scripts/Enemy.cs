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

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // Находим игрока
        agent = GetComponent<NavMeshAgent>(); // Получаем ссылку на NavMeshAgent

        if (agent == null)
        {
            Debug.LogError("NavMeshAgent component is missing.");
        }
    }

    private void Update()
    {
        if (player != null && agent != null)
        {
            MoveTowardsPlayer(); // Двигаемся к игроку
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
