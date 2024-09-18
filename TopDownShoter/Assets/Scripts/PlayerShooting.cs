using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab; // Префаб пули
    public Transform firePoint;     // Точка выстрела (можно прикрепить её к капсуле)
    public float bulletSpeed = 20f; // Скорость полета пули

    void Update()
    {
        // Проверяем, нажата ли левая кнопка мыши
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Создаем пулю в позиции точки выстрела с направлением капсулы
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // Если у пули есть Rigidbody, задаем ей начальную скорость
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = firePoint.forward * bulletSpeed;
        }
    }
}
