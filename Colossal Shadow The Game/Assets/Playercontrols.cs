using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontrols : MonoBehaviour
{
    public Rigidbody2D rb;

    private void Update()
     {
        if (Input.GetKey(KeyCode.A))
         {
            rb.velocity = new Vector2(-5, 0);
         }
        if (Input.GetKey(KeyCode.D))
         {
            rb.velocity = new Vector2(5, 0);
         }
        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity = new Vector2(0, 10);
        }






    }
    
}
