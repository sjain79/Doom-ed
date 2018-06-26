using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    Rigidbody2D myRigidbody;
    Animator myAnimator;
    SpriteRenderer mySpriteRenderer;

    [SerializeField]
    GameObject bullet;

    bool isFiring, isCrouching;

    [SerializeField]
    float fireRate;
    float timeElasped;

    private void Awake()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        timeElasped = (float)Time.time;
    }

    private void Update()
    {
        PlayerInput();
        SetAnimatorValues();
    }


    private void PlayerInput()
    {
        if (Input.GetKey(KeyCode.S))
        {
            isCrouching = true;
        }
        else
        {
            isCrouching = false;
        }

        if (!isCrouching)
        {
            if (Input.GetKey(KeyCode.A))
            {
                myRigidbody.velocity = new Vector2(-2, myRigidbody.velocity.y);
                mySpriteRenderer.flipX = true;
                transform.GetChild(0).transform.localPosition = new Vector2(-0.111f, 0);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                myRigidbody.velocity = new Vector2(2, myRigidbody.velocity.y);
                transform.GetChild(0).transform.localPosition = new Vector2(0.111f, 0);
                mySpriteRenderer.flipX = false;
            }
            else
            {
                myRigidbody.velocity = new Vector2(0, myRigidbody.velocity.y);
            }

        }

        //shotting logic for crouch position still remains

        if (Input.GetMouseButton(0))
        {
            if ((timeElasped + fireRate) < (float)Time.time)
            {
                timeElasped = (float)Time.time;
                GameObject tempBullet = Instantiate(bullet, transform.GetChild(0).transform.position, Quaternion.identity);
                if (mySpriteRenderer.flipX)
                {
                    tempBullet.transform.rotation = Quaternion.Euler(0, 0, 180);
                }
                else
                {
                    tempBullet.transform.rotation = Quaternion.Euler(0, 0, 0);
                }

                isFiring = true;
            }
        }
        else
        {
            isFiring = false;
        }
    }


    private void SetAnimatorValues()
    {
        myAnimator.SetFloat("Velocity", Mathf.Abs(myRigidbody.velocity.x));
        myAnimator.SetBool("isFiring", isFiring);
        myAnimator.SetBool("isCrouching", isCrouching);
    }
}
