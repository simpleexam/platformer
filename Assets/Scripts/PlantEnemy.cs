using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantEnemy : MonoBehaviour
{
    [SerializeField]
    Transform playerPosition; //координаты игрока
    [SerializeField]
    float dimention; //расстояние до игрока

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
