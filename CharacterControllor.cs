using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllor : MonoBehaviour
{
    public float speed = 1.0f;
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    private Vector3 charPos;
    private SpriteRenderer _spriteRenderer;

    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        charPos = transform.position;
    }

    //private void FixedUpdate() //50 fps
    //{
    //    _rigidbody2D.velocity = new Vector2(speed, 0f);
    //}

    void Update() // per frame 300 kere calisir
    {
        charPos = new Vector3((charPos.x +(Input.GetAxis("Horizontal") * speed * Time.deltaTime)),charPos.y);
        transform.position = charPos;
        if (Input.GetAxis("Horizontal") == 0.0f)
        {
            _animator.SetFloat("speed", 0.0f);
        }
        else
        {
            _animator.SetFloat("speed", 1.0f);
        }


        if (Input.GetAxis("Horizontal") > 0.01f)
        {
            _spriteRenderer.flipX = false;
        }else if (Input.GetAxis("Horizontal") < -0.01f)
        {
            _spriteRenderer.flipX = true;
        }
    }

}
