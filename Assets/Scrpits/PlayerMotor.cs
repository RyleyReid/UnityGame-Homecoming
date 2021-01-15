using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    // Start is called before the first frame update
    private CharacterController controller;
    private float verticalSpeed = 0.0f;
    private float HorizontalSpeed = 3.0f;
    private float gravity = 0.5f;
    private Vector3 moveVector;
    private bool bounce = false;
    private int count = 0;
    private bool dead = false;
    private int tokens = 0;

    void Start()
    {

        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (dead) {
            return;
        }
        if (bounce)
        {
            verticalSpeed += HorizontalSpeed;
            count++;
            if (count == 2)
            {
                count = 0;
                bounce = false;
            }
        }
        else if (Input.GetKey(KeyCode.S) && HorizontalSpeed > 1f)
        {
            transform.rotation = Quaternion.Euler(-30, 0, 0);
            if (HorizontalSpeed > 2f)
            {
                verticalSpeed -= Input.GetAxis("Vertical") * (Time.deltaTime * HorizontalSpeed);
                HorizontalSpeed -= HorizontalSpeed * 0.05f;
            }
            else {
                verticalSpeed -= (gravity * Time.deltaTime)* 1.5f;
                HorizontalSpeed -= HorizontalSpeed * 0.05f;
            }      
       }
        else if (Input.GetKey(KeyCode.W))
        {
            verticalSpeed -= Input.GetAxis("Vertical") * (Time.deltaTime * HorizontalSpeed);
            HorizontalSpeed = HorizontalSpeed * 1.01f;
            transform.rotation = Quaternion.Euler(30, 0, 0);
        }
        else
        {
            verticalSpeed -= (gravity * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.rotation = Quaternion.Euler(0, 0, 20);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.Euler(0, 0, -20);
        }
        moveVector = Vector3.zero;
        //X side to side        
        moveVector.x = Input.GetAxisRaw("Horizontal");
        //Y vertical
        if (verticalSpeed > 1.25f)
        {
            verticalSpeed = 1.25f;
        }
        moveVector.y = verticalSpeed;
        //Z speed
        if (HorizontalSpeed > 5f){
            HorizontalSpeed = 5f;
        }
        moveVector.z = HorizontalSpeed;

        controller.Move(moveVector * Time.deltaTime);
    }


    // check for a hit in the horizontal axis
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.point.z > transform.position.z + controller.radius)
        {
            gameOver();
        }
    }
    void OnTriggerEnter(Collider collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "pad")
        {
            bounce = true;
            Debug.Log("Hit Pad");

        }
        else if (collisionInfo.gameObject.tag == "floor")
        {
            Debug.Log("Hit Floor");
            gameOver();
        }
        else if (collisionInfo.gameObject.tag == "coin") {
            Debug.Log("hit token");
            tokens++;
        }
    }
    private void gameOver()
    {
        dead = true;
        GetComponent<score>().EndScore();
    }
    public int finalTokens(){
        return tokens;
    }
}
