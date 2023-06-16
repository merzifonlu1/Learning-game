using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    private BoxCollider2D bcoll;
    private SpriteRenderer sprite;
    private Animator anim;

    [SerializeField] private LayerMask JumpableGround;

    private float direcX;
    [SerializeField] private float hýz = 7f;
    [SerializeField] private float zýpla = 14f;

    [SerializeField] private AudioSource jumpSoundEffect;

    public bool canMove;

    private enum DalibState {idle, run, jump, fall }
    DalibState state;

    private void Start()
    {
        canMove = true;
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        bcoll = GetComponent<BoxCollider2D>();
    }


    private void Update()
    {
        if (canMove)
        {
            direcX = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector2(direcX * hýz, rb.velocity.y);
        }


        if (Input.GetButtonDown("Jump") && GroundCheck() && canMove)
        {
            jumpSoundEffect.Play();
            rb.velocity = new Vector2(rb.velocity.x, zýpla);
        }

        if (!canMove)
        {
            anim.SetInteger("state", 0);
        }
        else
        {
            Animations();
        }
    }    
    private void Animations()
    {

        if (direcX > 0f)
        {
            state = DalibState.run;
            sprite.flipX = false;
        }
        else if (direcX < 0f)
        {
            state = DalibState.run;
            sprite.flipX = true;
        }
        else
        {
            state = DalibState.idle;
        }


        if (rb.velocity.y > .01f)
        {
            state = DalibState.jump;
        }
        else if (rb.velocity.y < -.01f)
        {
            state = DalibState.fall;
        }

        anim.SetInteger("state", (int)state);
    }

    private bool GroundCheck()
    {
        return Physics2D.BoxCast(bcoll.bounds.center, bcoll.bounds.size, 0f, Vector2.down, .1f, JumpableGround);
    }


}

