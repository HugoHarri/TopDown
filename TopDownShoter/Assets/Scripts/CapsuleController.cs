using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleController : MonoBehaviour
{
    public Camera mainCamera; // Камера, через которую мы будем смотреть
    public float rotationSpeed = 5f; // Скорость вращения капсулы

    void Update()
    {
        // Получаем позицию курсора в мировых координатах
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = -mainCamera.transform.position.z; // Задаем Z-координату для расчета

        Vector3 worldMousePosition = mainCamera.ScreenToWorldPoint(mousePosition);

        // Находим направление от капсулы к позиции мыши
        Vector3 direction = new Vector3(worldMousePosition.x - transform.position.x,
                                         worldMousePosition.y - transform.position.y,
                                         worldMousePosition.z - transform.position.z);

        // Проверяем, что направление не нулевое
        if (direction.magnitude > 0.1f)
        {
            // Нормализуем направление
            direction.Normalize();

            // Вычисляем угол вокруг оси Y для поворота в направлении мыши
            float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;

            // Поворот вокруг оси Y
            Quaternion targetRotation = Quaternion.Euler(0, angle, 0);

            // Плавное вращение с использованием Lerp
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}

