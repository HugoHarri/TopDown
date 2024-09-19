using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab; // Префаб пули
    public Transform firePoint;     // Точка выстрела
    public float bulletSpeed = 20f; // Скорость полета пули

    private bool isShooting = false; // Флаг для контроля автоматической стрельбы

    void Update()
    {
        // Проверяем, нажата ли левая кнопка мыши
        if (Input.GetMouseButton(0))
        {
            if (!isShooting)
            {
                isShooting = true;
                InvokeRepeating("Shoot", 0f, 0.1f); // Начинаем автоматическую стрельбу
            }
        }
        else
        {
            if (isShooting)
            {
                isShooting = false;
                CancelInvoke("Shoot"); // Останавливаем автоматическую стрельбу
            }
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
