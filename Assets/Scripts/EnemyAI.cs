using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class EnemyAI : MonoBehaviour {


    

    public float speed = 400f;
    public float jumpForce = 6.0f;
    private float deltaX = 0;
    private int _movementChance;
    private int _jumpChance;
    bool newMove = true;
    bool grounded = true;

    private Rigidbody2D _EnemyBody;
   // private BoxCollider2D _EnemyCollider;
    private Animator _EmemyAnim;

    private Vector2 movement;

	
	void Start () {

        _EnemyBody = GetComponent<Rigidbody2D>();
        //_EnemyCollider = GetComponent<BoxCollider2D>();
        _EmemyAnim = GetComponent<Animator>();
       
	}
	
	void Update () {

        if (newMove)
        {           
            StartCoroutine("MovingAI");

        }
        if (grounded)
        {
            StartCoroutine("JumpAI");
        }

        _EmemyAnim.SetBool("ground", grounded);
        _EmemyAnim.SetFloat("speed", Mathf.Abs(deltaX));

    }

    private IEnumerator MovingAI()
    {
        newMove = false;
        _movementChance = Random.Range(0, 100);

        Vector3 EnemyScale = transform.localScale;
        

        if (_movementChance >= 0 && _movementChance < 40)
        {
            //Debug.Log("Right");
            float deltaX = speed * Time.deltaTime;
            movement = new Vector2(deltaX, _EnemyBody.velocity.y);
            transform.localScale = new Vector3(Mathf.Sign(deltaX), EnemyScale.y, EnemyScale.z);
            yield return new WaitForSeconds(Random.Range(0.2f, 0.7f));
            //go right until max x
        }

        else if (_movementChance >= 40 && _movementChance < 80)
        {
            //Debug.Log("Left");
            float deltaX = -speed * Time.deltaTime; 
            movement = new Vector2(deltaX, _EnemyBody.velocity.y);
            transform.localScale = new Vector3(Mathf.Sign(deltaX), EnemyScale.y, EnemyScale.z);
            yield return new WaitForSeconds(Random.Range(0.2f , 0.7f));
            //go left until min x
        }
        else if (_movementChance >= 80 && _movementChance < 100)
        {
           // Debug.Log("Standby");
            float deltaX = 0;
            movement = new Vector2(deltaX, _EnemyBody.velocity.y);
            yield return new WaitForSeconds(Random.Range(1.0f, 2.5f));
            //go right until max x
        }
   
        _EnemyBody.velocity = movement;
        
        newMove = true;
    }

    private IEnumerator JumpAI()
    {
        _jumpChance = Random.Range(0, 100);
        jumpForce = Random.Range(jumpForce, 8);

        if (_jumpChance > 0 && _jumpChance < 50 && grounded)
        {
            
            //Debug.Log("Jump");
            _EnemyBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

        }
        grounded = false;
        yield return new WaitForSeconds(2.0f);
        grounded = true;
    }
}
