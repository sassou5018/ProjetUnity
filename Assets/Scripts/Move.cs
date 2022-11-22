using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject player;
    public SpriteRenderer sr;
    public float speed = 5f;
    public Animator animator;
    public BoxCollider2D regularCollider;
    public BoxCollider2D SlideCollider;
    public float slideSpeed = 20f;

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
            sr.flipX = false;
        }
        if (input < 0)
        {
            sr.flipX = true;
        }
    }

    private void slide(float slideSpeed){
        regularCollider.enabled = false;
        SlideCollider.enabled = true;
        animator.SetTrigger("isSlide");
        if(sr.flipX == false){
            rb.AddForce(Vector2.left * slideSpeed);
        } else {
            rb.AddForce(Vector2.right * slideSpeed);
        }
        StartCoroutine(StopSlide());
    }

    private IEnumerator StopSlide(){
        yield return new WaitForSeconds(0.0f);
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
        if(Input.GetKeyDown(KeyCode.LeftControl)){
            slide(slideSpeed);
        }
        

    }
}


