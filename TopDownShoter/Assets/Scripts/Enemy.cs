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
    public int damage = 20; // ����, ��������� ������
    public float attackRange = 2f; // ��������� �����
    public float attackCooldown = 2f; // ����� ����� �������

    private PlayerHealth playerHealth; // ������ �� ������ �������� ������
    private float lastAttackTime; // ����� ��������� �����

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // ������� ������
        agent = GetComponent<NavMeshAgent>(); // �������� ������ �� NavMeshAgent

        if (agent == null)
        {
            Debug.LogError("NavMeshAgent component is missing.");
        }

        // ������� ��������� �������� ������
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    private void Update()
    {
        if (player != null && agent != null)
        {
            MoveTowardsPlayer(); // ��������� � ������
            AttackPlayer(); // ���������, ����� �� ��������� ������
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

    private void AttackPlayer()
    {
        // ��������� ���������� �� ������
        if (Vector3.Distance(transform.position, player.position) <= attackRange)
        {
            // ���������, ������ �� ���������� ������� � ��������� �����
            if (Time.time >= lastAttackTime + attackCooldown)
            {
                // ������� ���� ������
                playerHealth.TakeDamage(damage);
                Debug.Log("Enemy attacked player for " + damage + " damage.");
                lastAttackTime = Time.time; // ��������� ����� ��������� �����
            }
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