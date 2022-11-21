using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject player;
    public float speed = 5f;
    public Animator animator;

    private void MovePlayer()
    {
        var input = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(input * speed, rb.velocity.y);
        if(input != 0)
        {
            animator.SetBool("isRun", true);
        } else
        {
            animator.SetBool("isRun", false);
        }
        if(input > 0)
        {
            rb.transform.localScale = new Vector2((float)4.0504, (float)4.0504);
        }
        if (input < 0)
        {
            rb.transform.localScale = new Vector2((float)-4.0504, (float)4.0504);
        }
    }

    





    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        if (Input.GetButtonDown("Jump"))
        {
            animator.SetTrigger("isSlash");
        }
        

    }
}


