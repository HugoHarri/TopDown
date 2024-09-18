using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class CapsuleController : MonoBehaviour
{
    public Camera mainCamera; // ������, ����� ������� �� ����� ��������

    void Update()
    {
        // �������� ������� ������� � ������� �����������
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Mathf.Abs(mainCamera.transform.position.z); // ������ Z-���������� ��� �������

        Vector3 worldMousePosition = mainCamera.ScreenToWorldPoint(mousePosition);

        // ������� ����������� �� ������� � ������� ����
        Vector3 direction = new Vector3(worldMousePosition.x - transform.position.x,
                                         worldMousePosition.y - transform.position.y,
                                         worldMousePosition.z - transform.position.z);

        // ���������, ��� ����������� �� �������
        if (direction != Vector3.zero)
        {
            // ������� ���� �������� ������ ��� Z
            float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;

            // ������� ������� ������ ��� Z
            Quaternion targetRotation = Quaternion.Euler(0, angle, 0);

            // ������� ��������
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
        }
    }
}

