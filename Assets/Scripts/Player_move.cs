using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_move : MonoBehaviour
{
    float input; //ввод движения
    float speed = 3f;
    Rigidbody2D rb;
    Animator anim; //аниматор
    bool isRunning = false;
    [SerializeField]
    float rad = 0.1f;

    bool isGrounded; //состояние нахождения на земле
    [SerializeField]
    LayerMask ground; //ссылка на слой земли
    float jumpSpeed = 5f; //скорость прыжка
    [SerializeField]
    Transform feets;


    private void Start()
    {
        //получение ссылки на физический компонент объекта
        rb = GetComponent<Rigidbody2D>();
        //получение ссылки на аниматор объекта
        anim = GetComponent<Animator>();
        
    }

    private void Update()
    {
        input = Input.GetAxis("Horizontal"); //считывание нажатия <- ->
        rb.velocity = new Vector2(input*speed, rb.velocity.y); //перемещение самого объекта

        //проверка что персонаж стоит на земле
        isGrounded = Physics2D.OverlapCircle(feets.position, rad, ground);

        //если игрок стоит на земле и нажал пробел
        if(isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * jumpSpeed; //прыжок
            anim.SetTrigger("jump");
        }

        if (isGrounded) anim.SetBool("isGrounded", true);
        else anim.SetBool("isGrounded", false);

        if (input != 0) anim.SetBool("isRunning", true); //если есть ввод в переменной input(пользователь
                                                         //нажимает <- ->) то вкл анимация бега
        else anim.SetBool("isRunning", false); //если ноль в input - стоит
    }
}
