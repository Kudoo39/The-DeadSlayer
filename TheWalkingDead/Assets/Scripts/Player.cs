using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveForce = 10f;
    public float jumpForce = 8f;
    private float movement;

    public Rigidbody2D myBody;
    public SpriteRenderer sr;

    public Animator animate;
    private string Walk_Animation = "Walk";
    private int grounded = 0;
    private string Ground_Tag = "Ground";
    private string Enemy_Tag = "Enemy";

    AudioSource jumpsound;
    // Start is called before the first frame update
    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animate = GetComponent<Animator>();
    }
    void Start()
    {
        jumpsound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
            if (Input.GetKeyDown(KeyCode.UpArrow) && grounded < 2)
            {
                grounded += 1;
                myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
                jumpsound.Play();
            }
            if  (Input.GetButtonDown("Jump") && grounded < 2)
            {
                grounded += 1;
                myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
                jumpsound.Play();
            }
    }
    private void FixedUpdate()
    {
        Keyboard();
        AnimateThePlayer();
    }
    void Keyboard()
    {
        movement = Input.GetAxis("Horizontal"); //if only GetAxis, the value can be 0.1, 0.2 ,etc.
                                                   //if we press A key or left arrow key, the value will be negative
                                                   //if we press D key or right arrow key, the value will be negative

        transform.position += new Vector3(movement, 0f, 0f) * moveForce * Time.deltaTime;
    }
    void AnimateThePlayer()
    {
        if(movement > 0)
        {
            animate.SetBool(Walk_Animation, true);
            sr.flipX = false;
        }
        else if (movement < 0)
        {
            animate.SetBool(Walk_Animation, true);
            sr.flipX = true;
        }
        else
        {
            animate.SetBool(Walk_Animation, false);
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(Ground_Tag))
        {
            grounded = 0;
        }

        Enemy enemy = collision.gameObject.GetComponent<Enemy>(); 
        if (collision.gameObject.CompareTag(Enemy_Tag))
        {    
            foreach(ContactPoint2D point in collision.contacts)
            {
                if (point.normal.y >= 0.5f)
                {
                    Vector2 velocity = myBody.velocity;
                    velocity.y = jumpForce;
                    myBody.velocity = velocity;
                    Destroy(enemy.gameObject);
                    Debug.Log("Head");
                    if((enemy.name == "Minotaur") || (enemy.name == "Minotaur(Clone)"))
                    {
                        Score.Instance.AddScore();
                        Score.Instance.AddScore();
                    }
                    else
                    {
                        Score.Instance.AddScore();
                    }
                    jumpsound.Play();
                }
                if (point.normal.y < 0.5f)
                {
                    Debug.Log("-1 health");
                    PlayerHealth.Instance.Damage();
                    break;
                    //if (playerHealth == 0)
                    //{
                    //    Destroy(gameObject);
                    //    Debug.Log("Body");
                    //    Application.LoadLevel("End");
                    //}
                
                }
            }
        }
    }
}

