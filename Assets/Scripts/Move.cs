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
    public BoxCollider2D regularCollider;
    public BoxCollider2D SlideCollider;

    private void MovePlayer()
    {
        var input = Input.GetAxisRaw("Horizontal");
        var slideSpeed = speed*5;
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
            if (Input.GetKeyDown(KeyCode.LeftControl)){
                slide(speed, slideSpeed);
            }
        }
        if (input < 0)
        {
            rb.transform.localScale = new Vector2((float)-4.0504, (float)4.0504);
            if (Input.GetKeyDown(KeyCode.LeftControl)){
                slide(speed, slideSpeed);
            }
        }
    }

    private void slide(float input, float slideSpeed){
        regularCollider.enabled = false;
        SlideCollider.enabled = true;
        animator.SetTrigger("isSlide");
        rb.velocity = new Vector2(input * slideSpeed, rb.velocity.y);
        StartCoroutine(StopSlide());
    }

    private IEnumerator StopSlide(){
        yield return new WaitForSeconds(1.0f);
        regularCollider.enabled = true;
        SlideCollider.enabled = false;
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


