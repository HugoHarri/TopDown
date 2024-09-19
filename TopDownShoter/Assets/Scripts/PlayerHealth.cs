using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100; // ������������ ��������
    private int currentHealth;   // ������� ��������

    void Start()
    {
        currentHealth = maxHealth; // ������������� ������� �������� �� ������������ ��� ������
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // ��������� ������� �������� �� ���������� ����
        if (currentHealth <= 0)
        {
            Die(); // ���� �������� ���� ��� ����� 0, �������� ����� ������
        }
    }

    private void Die()
    {
        // ������ ������ (��������, ������� ������, �������� ����� Game Over � �.�.)
        Debug.Log("Player has died.");
        Destroy(gameObject); // ���������� ������� (����� �������� �� ������ ������)
    }

    public int GetCurrentHealth()
    {
        return currentHealth; // ����� ��� ��������� �������� ��������, ���� �����
    }
}
