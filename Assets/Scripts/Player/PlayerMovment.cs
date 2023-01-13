using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{

    private Rigidbody2D _RB2D;
    public float moveSpeed = 3f;
    public Vector2 direction;
    public bool canMove = true;
    public Animator _PlayerAnim;

    private Vector3 scale;
   
    void Start()
    {
        Time.timeScale = 1;
        _RB2D = gameObject.GetComponent<Rigidbody2D>();
        scale = gameObject.transform.localScale;
        //scale = gameObject.GetComponent<PlayerManager>()._MainCamera.v
    }

    void Update()
    {
        if (canMove) 
        {
           direction.x = Input.GetAxisRaw("Horizontal");
           direction.y = Input.GetAxisRaw("Vertical");

            if (direction.x == 0 && direction.y == 0)
            {

                _PlayerAnim.SetBool("Idle", true);

            }
            else 
            {
                _PlayerAnim.SetBool("Idle", false);
            }

            _PlayerAnim.SetFloat("MovmentX", Mathf.Abs(direction.x));
            _PlayerAnim.SetFloat("MovmentY", direction.y);
            if (direction.x > 0 && Time.timeScale > 0f) 
            {

                gameObject.transform.localScale = new Vector3(scale.x, scale.y, scale.z);
            }
            if (direction.x < 0 && Time.timeScale > 0f)
            {

                gameObject.transform.localScale = new Vector3(-1 * scale.x, scale.y, scale.z);
            }
        }

    }
    private void FixedUpdate()
    {
        _RB2D.MovePosition(_RB2D.position + direction * moveSpeed * Time.fixedDeltaTime );
        
    }
    public void AllowMovment() 
    {
        canMove = true;
    }
    public void ForbidMovment()
    {
        canMove = false;
        direction.x = 0;
        direction.y = 0;
    }
}

