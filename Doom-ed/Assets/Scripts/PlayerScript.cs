using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    Rigidbody2D myRigidbody;
    Animator myAnimator;
    SpriteRenderer mySpriteRenderer;

    bool isFiring;

    private void Awake()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        PlayerInput();
        SetAnimatorValues();
    }


    private void PlayerInput()
    {
        if (Input.GetKey(KeyCode.A))
        {
            myRigidbody.velocity = new Vector2(-2, myRigidbody.velocity.y);
            //transform.rotation =  Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 180);
            mySpriteRenderer.flipX = true;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            myRigidbody.velocity = new Vector2(2, myRigidbody.velocity.y);
            mySpriteRenderer.flipX = false;
        }
        else
        {
            myRigidbody.velocity = new Vector2(0, myRigidbody.velocity.y);
        }

        if (Input.GetMouseButton(0))
        {
            isFiring = true;        }
        else
        {
            isFiring = false;
        }
    }


    private void SetAnimatorValues()
    {
        myAnimator.SetFloat("Velocity", Mathf.Abs(myRigidbody.velocity.x));
        myAnimator.SetBool("isFiring", isFiring);
    }
}
