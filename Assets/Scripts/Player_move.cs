using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_move : MonoBehaviour
{
    float input; //���� ��������
    float speed = 3f;
    Rigidbody2D rb;
    Animator anim; //��������
    bool isRunning = false;
    [SerializeField]
    float rad = 0.1f;

    bool isGrounded; //��������� ���������� �� �����
    [SerializeField]
    LayerMask ground; //������ �� ���� �����
    float jumpSpeed = 5f; //�������� ������
    [SerializeField]
    Transform feets;


    private void Start()
    {
        //��������� ������ �� ���������� ��������� �������
        rb = GetComponent<Rigidbody2D>();
        //��������� ������ �� �������� �������
        anim = GetComponent<Animator>();
        
    }

    private void Update()
    {
        input = Input.GetAxis("Horizontal"); //���������� ������� <- ->
        rb.velocity = new Vector2(input*speed, rb.velocity.y); //����������� ������ �������

        //�������� ��� �������� ����� �� �����
        isGrounded = Physics2D.OverlapCircle(feets.position, rad, ground);

        //���� ����� ����� �� ����� � ����� ������
        if(isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * jumpSpeed; //������
            anim.SetTrigger("jump");
        }

        if (isGrounded) anim.SetBool("isGrounded", true);
        else anim.SetBool("isGrounded", false);

        if (input != 0) anim.SetBool("isRunning", true); //���� ���� ���� � ���������� input(������������
                                                         //�������� <- ->) �� ��� �������� ����
        else anim.SetBool("isRunning", false); //���� ���� � input - �����
    }
}
