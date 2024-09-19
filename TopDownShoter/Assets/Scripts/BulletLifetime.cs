using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLifetime : MonoBehaviour
{
    public float lifetime = 52f; // Время жизни пули в секундах

    void Start()
    {
        // Запускаем метод DestroyBullet через заданное время
        Destroy(gameObject, lifetime);
    }
}
