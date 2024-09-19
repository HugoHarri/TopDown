using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5f;  // Скорость полета пули
    public int damage = 20;    // Урон, наносимый пулей
   

    void Update()
    {
        // Пуля движется вперед
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Если пуля сталкивается с врагом
        if (other.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage); // Нанести урон врагу
            }
            // Уничтожить пулю после попадания
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Получаем компонент Enemy и вызываем TakeDamage
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
                Debug.Log("Damage applied to enemy. Current health: " + enemy.health);
                Destroy(gameObject); // Удаляем снаряд после попадания
            }
        }
    }
}
