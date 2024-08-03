using System;
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public bool isMoving;
    private Vector2 input;
    private Animator animator;
    public LayerMask solidObjectsLayer;
    public VectorValue startingPoint;
    
    private void Start() {
        print(startingPoint.initialValue);
        transform.position = startingPoint.initialValue;
    }
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!isMoving)
        {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            if (input.x != 0)
            {
                input.y = 0;
            }
            else
            {
                input.x = 0;
            }

            if (input != Vector2.zero)
            {

                animator.SetFloat("moveX", input.x);
                animator.SetFloat("moveY", input.y);
                var dest = transform.position;
                dest.x += input.x;
                dest.x += (float) (0.03 - (dest.x - Math.Floor(dest.x)));
                dest.y += input.y;
                dest.y += (float) (0.03 - (dest.y - Math.Floor(dest.y)));

                if (!IsWalkable(dest))
                {
                    StartCoroutine(Move(dest));
                }
            }
        }
        animator.SetBool("isMoving", isMoving);
    }
    IEnumerator Move(Vector3 dest)
    {
        isMoving = true;

        while (Vector3.Distance(transform.position, dest) > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, dest, moveSpeed * Time.deltaTime);
            yield return null;
        }

        transform.position = dest;

        isMoving = false;
    }

    private bool IsWalkable(Vector3 dest)
    {
        if (Physics2D.OverlapCircle(dest, 0, solidObjectsLayer) != null)
        {
            return true;
        }
        return false;
    }
}
