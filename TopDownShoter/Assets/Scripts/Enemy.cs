using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public float speed = 100f; // �������� �������� �����
    public int health = 100; // �������� �����
    private Transform player; // ������ �� ������
    private NavMeshAgent agent; // ������������� �����

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // ������� ������
        agent = GetComponent<NavMeshAgent>(); // �������� ������ �� NavMeshAgent
    }

    private void Update()
    {
        if (player != null)
        {
            MoveTowardsPlayer(); // ��������� � ������
        }
    }

    private void MoveTowardsPlayer()
    {
        // ������������� ����� ���������� ��� ����� � ������� ������
        agent.SetDestination(player.position);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die(); // �������, ���� �������� <= 0
        }
    }

    private void Die()
    {
        // ������ ������ (��������, �������� �����)
        Destroy(gameObject);
    }
}
