using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public float speed = 3f; // �������� �������� �����
    public int health = 100; // �������� �����
    private Transform player; // ������ �� ������
    private NavMeshAgent agent; // ������������� �����

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // ������� ������
        agent = GetComponent<NavMeshAgent>(); // �������� ������ �� NavMeshAgent

        if (agent == null)
        {
            Debug.LogError("NavMeshAgent component is missing.");
        }
    }

    private void Update()
    {
        if (player != null && agent != null)
        {
            MoveTowardsPlayer(); // ��������� � ������
        }
    }

    private void MoveTowardsPlayer()
    {
        if (agent.isActiveAndEnabled && agent.isOnNavMesh)
        {
            // ������������� ����� ���������� ��� ����� � ������� ������
            agent.SetDestination(player.position);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Enemy took damage. Current health: " + health);
        if (health <= 0)
        {
            Die(); // �������, ���� �������� <= 0
        }
    }

    private void Die()
    {
        Debug.Log("Enemy died.");
        // ������ ������ (��������, �������� �����)
        Destroy(gameObject);
    }
}
