using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public Transform point1, point2; // границы перемещения
    public float speed = 1f; // скорость
    public Transform startPoint; // точка старта перемещения
    Vector3 nextPoint; // следующая позиция
    void Start()
    {
        nextPoint = startPoint.position;
    }
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, nextPoint, speed * Time.deltaTime);
        //поворот
        if (transform.position == point1.position)
        {
            nextPoint = point2.position;
            transform.localScale = new Vector2(-1, 1);
        }
        else if (transform.position == point2.position)
        {
            nextPoint = point1.position;
            transform.localScale = new Vector2(1, 1);
        }
    }

}
