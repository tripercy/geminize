using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Vector3 dest;
    private Animator animator;
    void Start()
    {
        dest = transform.position;
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, dest, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, dest) < Mathf.Epsilon)
        {
            Vector2 input;
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            if (input.x != 0) {
                input.y = 0;
            } else {
                input.x = 0;
            }

            if (input != Vector2.zero)
            {
                animator.SetFloat("moveX", input.x);
                animator.SetFloat("moveY", input.y);

                if (input.x != 0)
                {
                    dest += new Vector3(input.x, 0, 0);
                }
                else if (input.y != 0)
                {
                    dest += new Vector3(0, input.y, 0);
                }
            }
        }
    }
}
