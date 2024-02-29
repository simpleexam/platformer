using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    [SerializeField]
    Transform spawn; //точка рестарта при смерти
      
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "enemy")
        {
            this.transform.position = spawn.transform.position;
        }
    }
}
