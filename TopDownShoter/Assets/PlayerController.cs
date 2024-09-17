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
        // ���������, ��� ���������� �������� � �������� ���������
        rb.useGravity = true;
    }

    void Update()
    {
        // �������� ���� �� ������������ (WASD)
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // �������� ������ �� �������������� ��������� (X, Z), ��������� ������������ ��������
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // ��������� ���� ��� �������� �������
        rb.AddForce(movement * moveSpeed);
    }
}