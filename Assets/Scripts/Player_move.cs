using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_move : MonoBehaviour
{
    float input; //ввод движения
    float speed = 3f;
    Rigidbody2D rb;

    bool isGrounded; //состояние нахождения на земле
    [SerializeField]
    LayerMask ground; //ссылка на слой земли
    float jumpSpeed = 3f; //скорость прыжка
    [SerializeField]
    Transform feets;


    private void Start()
    {
        //получение ссылки на физический компонент объекта
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        input = Input.GetAxis("Horizontal"); //считывание нажатия <- ->
        rb.velocity = new Vector2(input*speed, rb.velocity.y); //перемещение самого объекта

        //проверка что персонаж стоит на земле
        isGrounded = Physics2D.OverlapCircle(feets.position, 0.1f, ground);

        //если игрок стоит на земле и нажал пробел
        if(isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * jumpSpeed; //прыжок
        }
    }
}
