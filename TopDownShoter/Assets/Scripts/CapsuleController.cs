using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleController : MonoBehaviour
{
    public Camera mainCamera; // Камера, через которую мы будем смотреть
    public float rotationSpeed = 100f; // Скорость вращения капсулы

    void Update()
    {
        // Получаем позицию курсора в мировых координатах
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Vector3.Distance(mainCamera.transform.position, transform.position);

        Vector3 worldMousePosition = mainCamera.ScreenToWorldPoint(mousePosition);
        worldMousePosition.y = transform.position.y;

        // Вычисляем направление от капсулы к позиции мыши
        Vector3 direction = worldMousePosition - transform.position;
        direction.y = 0; // Игнорируем изменения по Y для правильного вращения

        // Проверяем, что направление не нулевое
        if (direction.magnitude > 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
