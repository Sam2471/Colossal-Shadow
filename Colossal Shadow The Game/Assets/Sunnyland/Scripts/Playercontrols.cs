using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Playercontrols : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private Collider2D coll;


    // FSM
    private enum State { idel, running, jumping, falling, hurt }
    private State state = State.idel;

    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 15f;
    [SerializeField] private float hurtForce = 15f;
    [SerializeField] private LayerMask ground;
    [SerializeField] private AudioSource step;
    [SerializeField] private AudioSource grab;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
        step = GetComponent<AudioSource>();
        PermanentUI.perm.healthAmount.text = PermanentUI.perm.health.ToString();
    }

    private void Update()
    {
        

        float hDirection = Input.GetAxis("Horizontal");
        float vDirection = Input.GetAxis("Vertical");

        if (state != State.hurt)
        {
            Movment(hDirection);
        }

        AnimationState();
        anim.SetInteger("state", (int)state);


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Collectable")
        {
            grab.Play();
            Destroy(collision.gameObject);
            PermanentUI.perm.gem += 1;
            PermanentUI.perm.gemText.text = PermanentUI.perm.gem.ToString();
        }
        if(collision.tag == "Powerup")
        {
            Destroy(collision.gameObject);
            jumpForce = 20f;
            GetComponent<SpriteRenderer>().color = Color.yellow;
            StartCoroutine(ResetPowerup());

        }    

            
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Enemy enemy = other.gameObject.GetComponent<Enemy>();
        if (other.gameObject.tag == "Enemy")
        {
            if(state == State.falling)
            {
                enemy.JumpedOn();
                Jump();
            }
            else
            {
                HandleHealth();

                if (other.gameObject.transform.position.x < transform.position.x)
                {
                    //Enemy is to my left and should be damaged and moved right 
                    rb.velocity = new Vector2(hurtForce, rb.velocity.y);

                }
                else
                {
                    //Enemy is to my left and should be damaged and moved right
                    rb.velocity = new Vector2(-hurtForce, rb.velocity.y);
                }
            }
        }
    }

    private void HandleHealth()
    {
        state = State.hurt;
        PermanentUI.perm.health -= 1;
        PermanentUI.perm.healthAmount.text = PermanentUI.perm.health.ToString();

        if (PermanentUI.perm.health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void Movment(float hDirection)
    {

        // Move left
        if (hDirection < 0)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            transform.localScale = new Vector2(-1, 1);

        }

        //Move right
        else if (hDirection > 0)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            transform.localScale = new Vector2(1, 1);


        }

        else
        {

        }
        // Jump
        if (Input.GetButtonDown("Jump") && coll.IsTouchingLayers(ground))
        {
            Jump();
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        state = State.jumping;

    }

    private void AnimationState()
    {
        if(state == State.jumping)
        {
            if (rb.velocity.y < .1f)
                state = State.falling; 

        }
        else if(state == State.falling)
        {
            if(coll.IsTouchingLayers(ground))
            {
                state = State.idel;
            }
        }

        else if(state == State.hurt)
        {
            if(Mathf.Abs(rb.velocity.x) < .1f)
            {
                state = State.idel;
            }
        }

        else if(Mathf.Abs(rb.velocity.x) > 2f)
        {
            //Moving
            state = State.running;
        }

        else
        {
            state = State.idel;
        }
       
    }

    private void Footstep()
    {
        step.Play();
    }

    private IEnumerator ResetPowerup()
    {
        yield return new WaitForSeconds(15);
        jumpForce = 12f;
        GetComponent<SpriteRenderer>().color = Color.white;
    }
    
}
