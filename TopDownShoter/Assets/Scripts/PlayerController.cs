using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;  // Скорость перемещения
    private Rigidbody rb;         // Ссылка на компонент Rigidbody

    // Метод Start вызывается при запуске
    void Start()
    {
        // Получаем ссылку на компонент Rigidbody
        rb = GetComponent<Rigidbody>();

        // Ограничиваем вращение по X и Z, но не ограничиваем движение по Y
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }

    // FixedUpdate вызывается на каждом фиксированном обновлении физики
    void FixedUpdate()
    {
        // Получаем ввод по оси X (лево-право) и оси Z (вперед-назад)
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Создаем вектор для перемещения
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // Перемещаем капсулу с использованием физики
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
