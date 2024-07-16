using System.Collections;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
<<<<<<< Updated upstream

    private Vector3 dest;
=======
    public bool isMoving;
    private Vector2 input;
    private Animator animator;
>>>>>>> Stashed changes
    void Start()
    {

    }

    void Update()
    {
<<<<<<< Updated upstream
        transform.position = Vector3.MoveTowards(transform.position, dest, moveSpeed * Time.deltaTime);
        
        if (Vector3.Distance(transform.position, dest) < Mathf.Epsilon) {
            Vector2 input;
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            if (input.x != 0) {
                dest += new Vector3(input.x, 0, 0);
            } else if (input.y != 0) {
                dest += new Vector3(0, input.y, 0);
=======
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

                if (input.x != 0)
                {
                    dest += new Vector3(input.x, 0, 0);
                }
                else if (input.y != 0)
                {
                    dest += new Vector3(0, input.y, 0);
                }

                StartCoroutine(Move(dest));
>>>>>>> Stashed changes
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
}