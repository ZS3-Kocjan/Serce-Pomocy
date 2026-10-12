using UnityEngine;
using UnityEngine.InputSystem;

public class NewBehaviourScript : MonoBehaviour
{

    public Rigidbody2D myRygidBody;
    public int speed=1;
    public int jumpForce=100;
    public KeyCode jumpKey;
    public KeyCode rightKey;
    public KeyCode leftKey;

    public float jumpAllowDistance=0.05f;
    public bool jumped = false;
    public bool slope =false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }


    bool IsGrounded()
    {
        // RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x,transform.position.y),Vector2.down);
        // Debug.Log(Vector2.Distance(hit.point,transform.position));
        // return Vector2.Distance(hit.point, transform.position) < 0.46f;
        return myRygidBody.linearVelocity.y < jumpAllowDistance && myRygidBody.linearVelocityY >= 0;
    }


    public void moveLogic()
    {
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x,transform.position.y),Vector2.down);
        // Debug.Log(Vector2.Angle(hit.normal,Vector2.down));
        if(Vector2.Angle(hit.normal,Vector2.down) < 160 || Vector2.Angle(hit.normal,Vector2.down) > 190)
        {
            slope=true;
        }
        else
        {
            slope=false;
        }
        if(Input.GetKey(rightKey))
        {
            myRygidBody.position+=Vector2.right*Time.deltaTime*speed*(slope==true ? 1.3f: 1);
        }
        if(Input.GetKey(leftKey))
        {
            myRygidBody.position+=Vector2.left*Time.deltaTime*speed*(slope==true ? 1.3f: 1);

        }
        

    }

    public void jumpLogic()
    {
        if(Input.GetKey(jumpKey) && jumped == false)
        {
            myRygidBody.linearVelocityY += jumpForce;
            jumped=true;
        }
        else if(IsGrounded())
        {
            jumped=false;
        }

    }


    // Update is called once per frame
    void Update()
    {
        moveLogic();
        jumpLogic();
    }
}
