using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleController : MonoBehaviour
{
    public Camera mainCamera; // ������, ����� ������� �� ����� ��������
    public float rotationSpeed = 500f; // �������� �������� �������

    void Update()
    {
        // �������� ������� ������� � ������� �����������
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Mathf.Abs(mainCamera.transform.position.z); // ������ Z-���������� ��� �������

        Vector3 worldMousePosition = mainCamera.ScreenToWorldPoint(mousePosition);

        // ������� ����������� �� ������� � ������� ����
        Vector3 direction = new Vector3(worldMousePosition.x - transform.position.x,
                                         0, // ���������� ��������� �� ��� Y ��� ����������� ��������
                                         worldMousePosition.z - transform.position.z);

        // ���������, ��� ����������� �� �������
        if (direction.magnitude > 0.1f)
        {
            // ������� ���� �������� ������������ ��� Y
            float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;

            // ������� ������� ������ ������ ��� Y
            Quaternion targetRotation = Quaternion.Euler(0, angle, 0);

            // ������� �������� � �������������� RotateTowards
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
