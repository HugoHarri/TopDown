using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // Убедитесь, что гравитация включена и работает правильно
        rb.useGravity = true;
    }

    void Update()
    {
        // Получаем ввод от пользователя (WASD)
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Движение только по горизонтальной плоскости (X, Z), исключаем вертикальное движение
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // Применяем силу для движения капсулы
        rb.AddForce(movement * moveSpeed);
    }
}