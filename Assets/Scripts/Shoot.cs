using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
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
		if (Input.GetKeyDown(KeyCode.Z)) 
		{
			animator.SetBool("Shoot",true);

		}
		if (Input.GetKeyUp(KeyCode.Z))
		{
			animator.SetBool("Shoot", false);

		}
	}
}
