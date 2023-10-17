using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float jump;
    [SerializeField] private Animator animator;
    [SerializeField] GameManager gameManager;

    private Rigidbody2D rb;
    private bool isGrounded;
    private bool isDead;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector2.up * jump);
            animator.SetTrigger("Jump");
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            animator.SetBool("Slide", true);
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            animator.SetBool("Slide", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            animator.SetBool("Death", true);
            gameManager.gameOver();
        }
    }
}