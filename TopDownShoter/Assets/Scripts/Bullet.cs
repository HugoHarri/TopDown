using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;  // Скорость полета пули
    public int damage = 20;    // Урон, наносимый пулей
    public float lifetime = 2f; // Время жизни пули, после которого она исчезает

    private void Start()
    {
        // Уничтожить пулю через заданное время
        Destroy(gameObject, lifetime);
    }

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
}
