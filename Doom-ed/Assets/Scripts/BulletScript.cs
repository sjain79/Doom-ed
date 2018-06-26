using UnityEngine;

public class BulletScript : MonoBehaviour
{

    [SerializeField]
    float speed;

    Rigidbody2D myRigidbody;
    Animator myAnimator;

    private void Awake()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }

    private void Start()
    {
        //Destroy(gameObject, 5);
    }

    private void Update()
    {
        myRigidbody.velocity = transform.right * speed;
        //Debug.Log(myRigidbody.velocity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Destroy(gameObject);       
        myAnimator.SetTrigger("Explode");
    }

    public void DestoryAtTheEnd()
    {
        Destroy(gameObject);
    }
}
