using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimientoTopDown : MonoBehaviour
{
    [SerializeField] float speed;

    float movX,movY;
    Rigidbody2D rbtopdown;
    Animator anim;
    
    // Start is called before the first frame update
    void Start()
    {
       rbtopdown = GetComponent<Rigidbody2D>();
       anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        movX = Input.GetAxisRaw("Horizontal");
        movY = Input.GetAxisRaw("Vertical");
        anim.SetFloat("movX", movX);
        anim.SetFloat("movY", movY);
    }

    void FixedUpdate()
    {
        rbtopdown.velocity = new Vector2(movX,movY).normalized*speed;
    }
}
