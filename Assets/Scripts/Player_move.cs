using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_move : MonoBehaviour
{
    float input; //���� ��������
    float speed = 3f;
    Rigidbody2D rb;

    bool isGrounded; //��������� ���������� �� �����
    [SerializeField]
    LayerMask ground; //������ �� ���� �����
    float jumpSpeed = 3f; //�������� ������
    [SerializeField]
    Transform feets;


    private void Start()
    {
        //��������� ������ �� ���������� ��������� �������
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        input = Input.GetAxis("Horizontal"); //���������� ������� <- ->
        rb.velocity = new Vector2(input*speed, rb.velocity.y); //����������� ������ �������

        //�������� ��� �������� ����� �� �����
        isGrounded = Physics2D.OverlapCircle(feets.position, 0.1f, ground);

        //���� ����� ����� �� ����� � ����� ������
        if(isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * jumpSpeed; //������
        }
    }
}
