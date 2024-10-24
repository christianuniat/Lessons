using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    public float jump;
    Rigidbody2D rigid;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        rigid.velocity = new Vector2(moveHorizontal * speed,rigid.velocity.y);

        
        animator.SetBool("Run", !(Input.GetAxis("Horizontal")==0));
        animator.SetBool("Jump", !(rigid.velocity.y == 0));


        if (Input.GetAxis("Horizontal") > 0) GetComponent<SpriteRenderer>().flipX = true;
        if(Input.GetAxis("Horizontal") < 0) GetComponent<SpriteRenderer>().flipX = false;


        if (Input.GetKeyDown(KeyCode.Space) && rigid.velocity.y==0) 
        {
            rigid.AddForce(new Vector2(0,jump), ForceMode2D.Impulse);
        }
    }
}
