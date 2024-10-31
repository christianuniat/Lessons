using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimientoSideScroll : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float jump;

    float movX;
    Rigidbody2D rbtopdown;
    Animator anim;
    int jumps = 2;

    public checkpoints checkpoint;
    public int savedCheckpoint;
    // Start is called before the first frame update
    void Start()
    {
       rbtopdown = GetComponent<Rigidbody2D>();
       anim = GetComponent<Animator>();
       transform.position = checkpoint.checkpoint.position;
        //esto es lo mismo pero para el sistema de guardado.
       transform.position = checkpoint.transforms[savedCheckpoint].position;
    }

    // Update is called once per frame
    void Update()
    {
        movX = Input.GetAxisRaw("Horizontal");
        anim.SetFloat("movX", movX);


        if (Input.GetButtonDown("Jump") && jumps > 0)
        {
            rbtopdown.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
            jumps--;
        }
    }

    void FixedUpdate()
    {
        rbtopdown.velocity = new Vector2(movX* speed, rbtopdown.velocity.y);
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo")) jumps = 2;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Muerte")) transform.position = checkpoint.transforms[savedCheckpoint].position;
        if (other.gameObject.CompareTag("Checkpoint")) 
        {
            checkpoint.checkpoint.position = other.transform.position;
            other.enabled = false;
            savedCheckpoint++;
        }
    }
}
