using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour, IDamagable
{
    private CharacterController characterController;
    private AudioSource audioSource;
    //[SerializeField] private AudioClip footstepSound;
    private Vector3 moveVec;
    [SerializeField] private float moveSpeed;
    private float moveY;
    private float moveRate;

    private float jumpTime;
    [SerializeField] private float jumpSpeed;

    public UnityAction asdf;
    [SerializeField] private float hp;

    public float Hp
    {
        get { return hp; }
        set 
        { 
            hp = value;
            if (Hp > 100) Hp = 100;
            StartCoroutine(GameManager.Instance.PlayerUIController.ChangeAll());
            if (hp <= 0)
            {
                Debug.Log("Dead");
                //dead
                characterController.enabled = false;
                GameManager.Instance.PlayableDirector.Play(GameManager.Instance.timelineClip[4]);
            }
        }
    }
    [SerializeField] private int money;

    public int Money 
    {  
        get 
        { 
            return money; 
        } 
        set 
        { 
            money = value;
            GameManager.Instance.PlayerUIController.OnChangePlayerMoney();
        }  
    }

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        
        Move();
        if (characterController.isGrounded && characterController.velocity.magnitude > 1f && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
            //Debug.Log(characterController.velocity.x);
            //Debug.Log(characterController.velocity.magnitude);
        if (Input.GetButtonDown("Jump") && characterController.isGrounded) Jump();
        Gravity();
    }

    private void Move()
    {
        float moveH = Input.GetAxisRaw("Horizontal");
        float moveV = Input.GetAxisRaw("Vertical");

        if (Input.GetButton("Dash"))
        {
            audioSource.volume = 0.4f;
            audioSource.pitch = 1.5f;
            moveSpeed = 7f;
        }
        else
        {
            audioSource.volume = 0.2f;
            audioSource.pitch = 1f;
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
        if (other.gameObject.GetComponent<DropItemController>())
        {
            Debug.Log("Pick Up");
            other.gameObject.GetComponent<DropItemController>().PickUp();
        }

    }
}
