using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour {

    [SerializeField]
    string enemytag = "Enemy";
    public float inputDelay = 0.1f;
    public float forwardVel = 12;
    public float rotateVel = 100;

    //Temporary positions to set it up to battle
    Vector3 tempPosition;
    Quaternion tempRotation;

    //Previous position and rotation of the player
    Vector3 prevPosition;
    Quaternion prevRotation;

    //Turning and moving
    Quaternion targetRotation;
//    Rigidbody rBody;
    float forwardInput, turnInput;
    float verticalVelocity;
    float gravity = 20.0f;
    float jumpForce = 10.0f;
    CharacterController controller;
     Animator animate;

    public Quaternion TargetRotation
    {
        get { return targetRotation; }
    }

    // Use this for initialization
    void Start()
    {
        targetRotation = transform.rotation;
        forwardInput = turnInput = 0;
        controller = GetComponent<CharacterController>();
        animate = GetComponent<Animator>();
    }
    void GetInput()
    {
        forwardInput = Input.GetAxis("Vertical");
        turnInput = Input.GetAxis("Horizontal");

        if (forwardInput != 0)
            animate.SetBool("isRunning", true);
        else
            animate.SetBool("isRunning", false);
    }
    // Update is called once per frame
    void Update()
    {
        if (controller.isGrounded)
        {
            verticalVelocity = -gravity * Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                verticalVelocity = jumpForce;
            }
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }

        if (!CharacterInstance.Instance.GetInBattle())
        {
            GetInput();
            Turn();
            Vector3 moveVector = Vector3.zero;
            moveVector.x = transform.forward.x * forwardInput * forwardVel;
            moveVector.y = verticalVelocity * 2.0f;
            moveVector.z = transform.forward.z * forwardInput * forwardVel;
            controller.Move(moveVector * Time.deltaTime);
            animate.SetBool("inBattle", false);
        }
        else
        {
            forwardInput = 0.0f;
            turnInput = 0.0f;
            transform.position = tempPosition;
            transform.rotation = tempRotation;
            animate.SetBool("isRunning", false);
            animate.SetBool("inBattle", false);

            if (BattleInstance.Instance.GetBattleFinished())
            {
                transform.position = prevPosition;
                transform.rotation = prevRotation;
                CharacterInstance.Instance.SetInBattle(false);
                BattleInstance.Instance.SetBattleFinished(false);
            }
        }

       
      
    }

    void Turn()
    {
        targetRotation *= Quaternion.AngleAxis(rotateVel * turnInput * Time.deltaTime, Vector3.up);
        transform.rotation = targetRotation;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == enemytag && !CharacterInstance.Instance.GetInBattle())
        {
            //Storing the previous transform
            prevPosition = transform.position;
            prevRotation = transform.rotation;
            

            //Shifting the player to the bottom
            tempRotation = new Quaternion(0.0f, 0.0f, 0.0f, 1.0f);
            tempPosition = new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y + 60.0f, gameObject.transform.localPosition.z);

            //Shifting the enemy to the bottom
            //collision.gameObject.GetComponent<Enemy>().enabled = false;

            //Create a new battle plane
            CharacterInstance.Instance.SetInBattle(true);

            BattleInstance.Instance.SetBattle(collision, gameObject);
            //animate.SetBool("inBattle", true);
            animate.Play("engage");
        }
    }
}
