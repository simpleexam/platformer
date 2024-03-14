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
    Animator animator;

    bool rightOrientation;

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
        animator = GetComponent<Animator>();
        rightOrientation = true;
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
            animator.SetTrigger("jump");
        }

        //���/���� �������� ����
        if(moveInput!=0)
            animator.SetBool("isRunning", true);
        else
            animator.SetBool("isRunning", false);
        // ���/����/ �������� �������
        if (isGrounded)
            animator.SetBool("isGrounded", true);
        else
            animator.SetBool("isGrounded", false);

        if (rightOrientation && moveInput<0) Flip();
        else if (!rightOrientation && moveInput>0) Flip();

    }

    private void Flip()
    {
        rightOrientation = !rightOrientation;
        Vector2 playerScale = transform.localScale;
        playerScale.x *= -1;
        transform.localScale = playerScale;
    }

}
