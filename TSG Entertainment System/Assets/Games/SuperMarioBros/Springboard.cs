using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Springboard : MonoBehaviour
{
    public Animator Animator;
    public Collider2D Trigger;
    public GameObject Player;
    public Rigidbody2D myRB;
    public float Power;
    public float normalGravity;
    public float jumpDownGravity;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        myRB = Player.GetComponent<Rigidbody2D>();
        normalGravity = myRB.gravityScale;
        jumpDownGravity = 1.64f;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider == Trigger)
        {
            Debug.Log("Collided with: " + collision.gameObject.name + " (Trampoline)");
            
                StartCoroutine(Bounce());
        }
        else
        {
            Debug.Log("Collided with other Object, but not trampoline");
        }
    }

    public IEnumerator Bounce()
    {
        Debug.Log("Bounce");
        //Animator.SetBool("jump", true);        
        Animator.Play("Bounce");
        myRB.velocity = new Vector2(myRB.velocity.x, Power+10);
        yield return new WaitForSeconds(0.2f);       
        myRB.gravityScale = normalGravity * jumpDownGravity;
        yield return new WaitForSeconds(0.5f);
        myRB.gravityScale = normalGravity;
    }


    // Update is called once per frame
    void Update()
    {

        //Player.GetComponent<Rigidbody2D>().AddForce(transform.up * Power);

    }
}
