using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantEnemy : MonoBehaviour
{
    [SerializeField]
    Transform playerPosition; //���������� ������
    [SerializeField]
    float dimention; //���������� �� ������

    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    
    void Update()
    {
        dimention = this.transform.position.x - playerPosition.position.x;

        if (dimention < 0.3)
            anim.SetTrigger("attack");
    }
}
