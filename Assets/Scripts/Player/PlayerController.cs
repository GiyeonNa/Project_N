using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour, IDamagable
{
    private CharacterController characterController;
    [SerializeField] private GroundChecker groundChecker;

    private Vector3 moveVec;
    [SerializeField] private float moveSpeed;
    //private float moveH;
    //private float moveV;
    private float moveY;
    private float moveRate;

    private float jumpTime;
    [SerializeField] private float jumpSpeed;

    [SerializeField] private float hp;
    public float Hp
    {
        get { return hp; }
        set 
        { 
            hp = value;
            if (hp <= 0) Debug.Log("Dead");
        }
    }

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if(Input.GetButtonDown("Jump") && characterController.isGrounded) Jump();
        Gravity();
    }

    private void Move()
    {
        float moveH = Input.GetAxisRaw("Horizontal");
        float moveV = Input.GetAxisRaw("Vertical");

        if (Input.GetButton("Dash"))
        {
            moveSpeed = 7f;
        }
        else
        {
            moveSpeed = 4f;
        }

        if (characterController.isGrounded) moveY = 0;
        else moveY += Physics.gravity.y * Time.deltaTime;

        moveVec = (transform.right * moveH + transform.forward * moveV).normalized * moveSpeed;
        moveVec.y = moveY;

        characterController.Move(moveVec * Time.deltaTime);
    }

    private void Jump()
    {
        jumpTime = 0.1f;
    }

    private void Gravity()
    {
        if (jumpTime > 0f)
        {
            moveY = jumpSpeed;
            jumpTime -= Time.deltaTime;
        }
        else if (characterController.isGrounded) moveY = 0;
        else moveY += Physics.gravity.y * Time.deltaTime;

        characterController.Move(Vector3.up * moveY * Time.deltaTime);
    }

    public void TakeHit(float damage, RaycastHit hit)
    {
        return;
    }

    public void TakeHit(float damage)
    {
        Hp -= damage;
    }

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<DropItem>().PickUp();
    }
}
