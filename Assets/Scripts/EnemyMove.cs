using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public Transform point1, point2; // ������� �����������
    public float speed = 1f; // ��������
    public Transform startPoint; // ����� ������ �����������
    Vector3 nextPoint; // ��������� �������
    void Start()
    {
        nextPoint = startPoint.position;
    }
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, nextPoint, speed * Time.deltaTime);
        //�������
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
