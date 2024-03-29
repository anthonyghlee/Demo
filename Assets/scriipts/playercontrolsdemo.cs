using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playercontrolsdemo : MonoBehaviour
{
    Rigidbody rb;
    
    [SerializeField] float speed = 5f;
    [SerializeField] float jumpHeight = 5f;
    [SerializeField] float flattenHeight = .5f;

    Vector2 moveValue = Vector2.zero;
    Vector3 originalScale;

    bool isGrounded = false; 
    bool isFlattened = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
        originalScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        Move(moveValue.x, moveValue.y);
    }

    void OnMove(InputValue value)
    {
        Vector2 direction = value.Get<Vector2>();
        Debug.Log(direction);
        moveValue = direction;
        //Move(direction.x, direction.y);
    }

    private void Move(float x, float z)
    {
        rb.velocity = new Vector3(x * speed, rb.velocity.y, z * speed);
    }

    void OnJump()
    {
        if (isGrounded)
        {
            Jump();
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpHeight, rb.velocity.z);
    }

    void OnFlatten(InputValue value)
    {
        if(!isFlattened)
        {
            Flatten();
        }
        else
        {
            Unflatten();
        }
    }

    private void Flatten()
    {
        transform.localScale = new Vector3(2, flattenHeight, 2);
        isFlattened = true;
    }

    private void Unflatten()
    {
        transform.localScale = originalScale;
        isFlattened = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.gameObject.CompareTag("Ground"))
        //    isGrounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        // if (collision.gameObject.CompareTag("Ground"))
        isGrounded = false;
    }

    private void OnCollisionStay(Collision collision)
    {
        Vector3 norm = collision.GetContact(0).normal;

        if (Vector3.Angle(norm, Vector3.up) < 45f)
            isGrounded = true;
        //if (collision.gameObject.CompareTag("Ground"))
        //    isGrounded = true;
    }
}
