using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementScript : MonoBehaviour
{
    Vector2 startPosition;

    SpriteRenderer mySpriteRenderer;

    private void Awake()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        startPosition = (Vector2)transform.position;
    }

    private void FixedUpdate()
    {
        transform.position = startPosition + new Vector2(Mathf.Sin(Time.time), 0.0f);
    }
}
