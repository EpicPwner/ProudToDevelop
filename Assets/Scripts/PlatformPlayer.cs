using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPlayer : MonoBehaviour {

    public float speed = 250.0f;
    public float jumpForce = 15.0f;
    

    private Rigidbody2D _body;
    private Animator _anim;
    private BoxCollider2D _box;
    bool grounded = false;
    

    // Use this for initialization
    void Start () {
        _body = GetComponent<Rigidbody2D>(); //Assign the name _body to the component RigidBody2D from the gameObject it's attached to.
        _anim = GetComponent<Animator>();
        _box = GetComponent<BoxCollider2D>();
       
    }
	
	// Update is called once per frame
	void Update () {


        bool fKey = Input.GetKeyDown(KeyCode.F); //punch Input
        float deltaX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;   //Movimento horizontal do objecto.
        Vector2 movement = new Vector2(deltaX, _body.velocity.y);
        _body.velocity = movement;

        Vector3 max = _box.bounds.max;
        Vector3 min = _box.bounds.min;
        Vector2 corner1 = new Vector2(max.x, min.y - 0.1f);     //Pontos para detetar o chão
        Vector2 corner2 = new Vector2(min.x, min.y - 0.2f);



        Collider2D hit = Physics2D.OverlapArea(corner1, corner2);


     
            if (hit != null)
            {
                grounded = true;
            }


       
        _body.gravityScale = grounded && deltaX == 0 ? 0 : 1;  // se o o player object tiver grounded e nao existir movimento horizontal a gravityScale do rigidbody component do Player object é 0. Caso contrario é 1 (se estiver a mover-se e o não estiver em contacto com um collider).
        if (grounded && Input.GetKeyDown(KeyCode.Space))
        {
            _body.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
       
        }


 
   
        MovingPlatform platform = null;
        if (hit != null)
        {
            platform = hit.GetComponent<MovingPlatform>();
        }
        if (platform != null)
        {
            transform.parent = platform.transform;
        }
        else
        {
            transform.parent = null;
        }       

        _anim.SetFloat("speed", Mathf.Abs(deltaX));
        _anim.SetBool("F key", fKey);
        _anim.SetBool("Ground", grounded);

        Vector3 pScale = Vector3.one; 
        if (platform != null)
        {
            pScale = platform.transform.localScale; //???????? wtffff?
        }

        if (deltaX != 0)
        {
            transform.localScale = new Vector3(Mathf.Sign(deltaX) / pScale.x, 1/pScale.y, 1); //????????
        }
      
      
	}

}
