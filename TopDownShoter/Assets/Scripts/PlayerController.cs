using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;  // �������� �����������
    public float rotationSpeed = 0f;  // �������� ��������

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // ������������ �������� �� X � Z � ��������� �������� �� ��� Y
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionY;
    }

    void Update()
    {
        // �������� ���� �� ��� X (����-�����) � ��� Z (������-�����)
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // ����������� �������
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.MovePosition(transform.position + movement * moveSpeed * Time.deltaTime);

        // ������� ������� ��� ��������
        if (movement != Vector3.zero)
        {
            Quaternion newRotation = Quaternion.LookRotation(movement);
            rb.MoveRotation(Quaternion.RotateTowards(transform.rotation, newRotation, rotationSpeed * Time.deltaTime));
        }
    }
}
