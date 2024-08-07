using System;
using System.Collections;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;

public enum PlayerState
{
    idle,
    walk,
    interact
}
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public PlayerState currentState;
    public Rigidbody2D player;
    private Vector3 input;
    private Animator animator;
    public LayerMask solidObjectsLayer;
    public VectorValue startingPoint;
    public PlayerInventory playerInventory;
    public SpriteRenderer receiveItem;

    private void Start()
    {
        transform.position = startingPoint.initialValue;
        currentState = PlayerState.walk;
        animator = GetComponent<Animator>();
        animator.SetFloat("moveX", 0);
        animator.SetFloat("moveY", -1);
    }

    void Update()
    {
        if (currentState == PlayerState.interact)
        {
            return;
        }

            input = Vector3.zero;
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
        
        if (currentState == PlayerState.walk)
        {
            UpdateAnimationAndMove();
        }
    }

    public void UpdateAnimationAndMove()
    {
        if (input != Vector3.zero)
        {
            MoveCharacter();
            animator.SetFloat("moveX", input.x);
            animator.SetFloat("moveY", input.y);
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
    }

    void MoveCharacter()
    {
        input.Normalize();
        player.MovePosition(transform.position + moveSpeed * Time.deltaTime * input);
    }

    public void RaiseItem()
    {
        if (currentState != PlayerState.interact)
        {
            // animator.SetBool("isRecieve", true);
            receiveItem.sprite = playerInventory.currentItem.itemSprite;
            currentState = PlayerState.interact;
        }
        else
        {
            // animator.SetBool("isRecieve", false);
            currentState = PlayerState.walk;
            receiveItem.sprite = null;
        }
    }
}
