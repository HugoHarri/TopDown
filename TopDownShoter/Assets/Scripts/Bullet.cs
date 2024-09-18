using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;  // �������� ������ ����
    public int damage = 20;    // ����, ��������� �����
    public float lifetime = 2f; // ����� ����� ����, ����� �������� ��� ��������

    private void Start()
    {
        // ���������� ���� ����� �������� �����
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        // ���� �������� ������
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        // ���� ���� ������������ � ������
        if (other.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage); // ������� ���� �����
            }
            // ���������� ���� ����� ���������
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // �������� ��������� Enemy � �������� TakeDamage
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
                Debug.Log("Damage applied to enemy. Current health: " + enemy.health);
                Destroy(gameObject); // ������� ������ ����� ���������
            }
        }
    }
}
