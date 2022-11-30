using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    private SpriteRenderer animationSprite;
    public GameObject hammer;
    private float horizontalInput;
    public float speed;
    public Sprite runAnim;
    public Sprite standAnim;
    private bool ladder = false;
    private bool isGrounded = false;

    // Start is called before the first frame update
    void Start()
    {
        animationSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput > 0)
        {
            moveRight();
        }
        if (horizontalInput < 0)
        {
            moveLeft();
        }
        if (horizontalInput == 0)
        {
            animationSprite.sprite = standAnim;
        }
        if (Input.GetKeyDown(KeyCode.W) && ladder)
        {
            climbUp();
        }
        if (Input.GetKeyDown("space") && isGrounded)
        {
            
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            hammer.transform.rotation = Quaternion.Euler(0f, 0f, -112f);
        }
        if(Input.GetKeyUp(KeyCode.Mouse0))
        {
            hammer.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }


    }
  void moveRight()
  {
        transform.Translate(Vector2.right * horizontalInput * Time.deltaTime * speed);
        transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        animationSprite.sprite = runAnim;
  }
  void moveLeft()
  {
        transform.Translate(Vector2.left * horizontalInput * Time.deltaTime * speed);
        transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        animationSprite.sprite = runAnim;
  }
    void climbUp()
    {
        Debug.Log("up");
        transform.Translate(Vector2.up * Time.deltaTime * speed);
        isGrounded = false;

    }
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Ground"))
    //    {
    //        //ladder = false;
    //        isGrounded = true;
    //    }
    //}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ladder"))
        {
            ladder = true;

        }
        if (collision.gameObject.CompareTag("Objective"))
        {
            GameManager.gamePlayManager.levelComple();

        }

    }
}
