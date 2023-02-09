using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterContoller2 : MonoBehaviour
{
    
    public float jumpForce=7.0f;
    public float speed = 3.0f;
    private float moveDirection;

    private bool jump;
    private bool grounded;
    private bool moving;
    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;

    void Awake()
    {
        _animator = GetComponent<Animator>();
        grounded = true;
    }

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();   
    }

    private void FixedUpdate()
    {
        if (_rigidbody2D.velocity != Vector2.zero)
        {
            _animator.SetBool("moving", true);
        }
        else
        {
            _animator.SetBool("moving", false);
            _animator.SetFloat("speed", 0.0f);
            //grounded = true;
        }

        _rigidbody2D.velocity = new Vector2(speed * moveDirection, _rigidbody2D.velocity.y);

        if (jump == true)
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, jumpForce);
            jump = false;
        }
    }

    private void Update()
    {
        
        if (grounded==true && (Input.GetKey(KeyCode.A) || (Input.GetKey(KeyCode.D))))
        {
            if (Input.GetKey(KeyCode.A))
            {
                moveDirection = -1.0f;
                _spriteRenderer.flipX = true;
                _animator.SetFloat("speed", speed);
            }else if (Input.GetKey(KeyCode.D))
            {
                moveDirection = 1.0f;
                _spriteRenderer.flipX = false;
                _animator.SetFloat("speed", speed);
            }
            else if (grounded == true)
            {
                moveDirection = 0.0f;
                _animator.SetFloat("speed", 0.0f);
                
            }
        }

        if (grounded == true && (Input.GetKey(KeyCode.W)))
        {
            jump = true;
            grounded = false;
            _animator.SetTrigger("jump");
            _animator.SetBool("grounded", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) //yere dusmek icin
    {
        if (collision.gameObject.CompareTag("platform"))
        {
            _animator.SetBool("grounded", true);
            grounded = true;
        }
    }
}
