using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    float moveInput;
    float moveSpeed = 3.5f;
    float jumpSpeed = 3f;
    Rigidbody2D body;

    [SerializeField]
    LayerMask groundLayer; //������ �� ���� Ground
    [SerializeField]
    float checkRadius = 0.1f; //������ ��� �������� ���������� �� �����
    
    bool isGrounded;
    [SerializeField]
    Transform feets;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        moveInput = Input.GetAxis("Horizontal");

        body.velocity = new Vector2(moveInput * moveSpeed, body.velocity.y);

        isGrounded = Physics2D.OverlapCircle(feets.position, checkRadius, groundLayer);
        Debug.Log(isGrounded);

        if(isGrounded && Input.GetKeyDown(KeyCode.Space)) //���� ����� �� ����� � ������ ������
        {
            body.velocity = Vector2.up * jumpSpeed;

        }
    }

}
