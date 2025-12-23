using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;

    GameObject spriteObject;

    Rigidbody2D body;
    Animator anim;

    void Start()
    {
        spriteObject = transform.GetChild(0).gameObject;

        body = GetComponent<Rigidbody2D>();
        anim = spriteObject.GetComponent<Animator>();
    }

    void Update()
    {
        Move();
        Animate();
    }

    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector2 move = new Vector2(x, y);
        move = move.normalized * movementSpeed;

        body.linearVelocity = move;
    }

    void Animate()
    {
        if (body.linearVelocity.magnitude == 0)
        {
            anim.SetInteger("State", 0);
        }
        else
        {
            anim.SetInteger("State", 1);
            
            bool facingLeft = body.linearVelocityX < 0;
            spriteObject.GetComponent<SpriteRenderer>().flipX = facingLeft;
        }
    }
}
