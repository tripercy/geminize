using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Vector3 dest;
    void Start()
    {
        dest = transform.position;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, dest, moveSpeed * Time.deltaTime);
        
        if (Vector3.Distance(transform.position, dest) < Mathf.Epsilon) {
            Vector2 input;
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            if (input.x != 0) {
                dest += new Vector3(input.x, 0, 0);
            } else if (input.y != 0) {
                dest += new Vector3(0, input.y, 0);
            }
        }
    }
}
