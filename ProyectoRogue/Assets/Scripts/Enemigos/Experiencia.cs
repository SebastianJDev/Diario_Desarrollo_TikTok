using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Experiencia : MonoBehaviour
{
    //Iman
    public float ImanRange;
   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Player":
                Destroy(this.gameObject);
                break;
        }
    }
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, ImanRange);
    }
}
