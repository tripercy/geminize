using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    private Vector2 input;
    private Vector2 velocity = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {

    }

    void Update() {
        input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            if (input.x != 0)
            {
                input.y = 0;
            }

            if (input != Vector2.zero)
            {
                velocity = input;
            }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // if (!isMoving)
        // {
        //     input.x = Input.GetAxisRaw("Horizontal");
        //     input.y = Input.GetAxisRaw("Vertical");

        //     if (input.x != 0)
        //     {
        //         input.y = 0;
        //     }

        //     if (input != Vector2.zero)
        //     {
        //         print(isMoving);
        //         isMoving = true;

        //         var targetPos = transform.position;
        //         targetPos.x += input.x;
        //         targetPos.y += input.y;


        //         Move(targetPos);
        //     }
        // }
        
        
        if (velocity.sqrMagnitude > Mathf.Epsilon) {
            Vector3 targetPos = transform.position;

            targetPos.x += velocity.x;
            targetPos.y += velocity.y;

            transform.position = targetPos;
            velocity = Vector3.MoveTowards(velocity, Vector2.zero, 1 / moveSpeed * Time.deltaTime);
            print(velocity);
        } else {
            velocity = Vector2.zero;
        }
    }

    void Move(Vector3 targetPos)
    {

        // while ((targetPos - transform.position).sqrMagnitude < Mathf.Epsilon)
        // {
        //     targetPos = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
        //     // yield return null;
        // }
        // transform.position = targetPos;

        // isMoving = false;
        // print("Firing");
    }
}
