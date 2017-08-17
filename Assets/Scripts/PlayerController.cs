using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public static PlayerController instance;
    private Rigidbody2D rigidBody2D;
    [SerializeField] private float jumpForce;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Animator animator;
    [SerializeField] private float runningSpeed = 1.5f;
    private Vector2 velocidad;
    private Vector3 startingPosition;

    //-----Métodos API------
    private void Awake()
    {
        if (instance==null)
        {
            instance = this;
        }else if(instance !=this)
        {
            Destroy(gameObject);
        }
        rigidBody2D = GetComponent<Rigidbody2D>();
        animator.SetBool("isAlive", true);
        startingPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update ()
    {
        if (GameManager.Instance.CurrentGameState == GameState.inGame)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Left mouse button clicked!");
                Jump();
            }
            animator.SetBool("isGrounded", IsGrounded());
        }
            
    }

    private void FixedUpdate()
    {
        if (GameManager.Instance.CurrentGameState == GameState.inGame)
        {
            if (rigidBody2D.velocity.x < runningSpeed)
            {
                velocidad.x = runningSpeed;
                velocidad.y = rigidBody2D.velocity.y;
                rigidBody2D.velocity = velocidad;
            }
        }
            
    }

    //-----Métodos custom-----
    private void Jump()
    {
        if (IsGrounded())
        {
            rigidBody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
    
    bool IsGrounded()
    {
        if (Physics2D.Raycast(this.transform.position,Vector2.down,0.2f, groundLayer.value))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Kill()
    {
        GameManager.Instance.GameOver();
        animator.SetBool("isAlive", false);
        this.gameObject.SetActive(false);
    }

    public void StartGame()
    {
        this.transform.position = startingPosition;
        this.gameObject.SetActive(true);
        animator.SetBool("isAlive", true);
    }
}
