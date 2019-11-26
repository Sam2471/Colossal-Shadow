using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanditMovement : MonoBehaviour
{
    public float speedbl;
    private float distance;

    private bool movingRight = true;

    public Transform groundDetection;

    private void Update()
    {
        transform.Translate(Vector2.right * speedbl * Time.deltaTime);

        RaycastHit2D groundinfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 10f);
        if(groundinfo.collider == false)
        {
            if(movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
    }
}
