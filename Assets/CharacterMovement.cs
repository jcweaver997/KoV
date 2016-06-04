using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {

    public float jumpSpeed = 10;
    public float sideSpeed = 5;
    public float forwardSpeed = 8;
    public float backSpeed = 5;
    public float moveAccel = 10;
    public float gravity = 9.81f;
    private CharacterController cc;

	// Use this for initialization
	void Start () {
        cc = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {


	}

    void FixedUpdate()
    {
        Controls();
    }

    private float y = 0;
    float x = 0;
    float z = 0;
    void Controls()
    {

        
        if (cc.isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(cc.isGrounded);
            y = jumpSpeed;
        }

        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            x += moveAccel*Time.deltaTime*sideSpeed;
            x = Mathf.Min(x, sideSpeed);

        }else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            x -= moveAccel * Time.deltaTime *sideSpeed;
            x = Mathf.Max(x, -sideSpeed);
        }else
        {
            if (x>0)
            {
                x -= moveAccel * Time.deltaTime*sideSpeed;
                x = Mathf.Max(x, 0);
            }
            else if(x<0)
            {
                x += moveAccel * Time.deltaTime*sideSpeed;
                x = Mathf.Min(x, 0);
            }
        }

        if (Input.GetAxisRaw("Vertical") > 0)
        {
            z += moveAccel*Time.deltaTime*forwardSpeed;
            z = Mathf.Min(z, forwardSpeed);
        }
        else if (Input.GetAxisRaw("Vertical") < 0)
        {
            z -= moveAccel * Time.deltaTime*backSpeed;
            z = Mathf.Max(z, -backSpeed);
        }
        else
        {
            if (z > 0)
            {
                z -= moveAccel * Time.deltaTime*forwardSpeed;
                z = Mathf.Max(z, 0);
            }
            else if (z < 0)
            {
                z += moveAccel * Time.deltaTime*backSpeed;
                z = Mathf.Min(z, 0);
            }
        }

        cc.Move(transform.TransformDirection((new Vector3(x,y,z)))*Time.deltaTime);
        y -= Time.deltaTime*gravity;
    }
}
