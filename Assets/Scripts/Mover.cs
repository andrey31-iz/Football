using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
   [SerializeField] private float _speedPlaeyr;    
    private Rigidbody _rigidbody;
    public Vector3 jump;
    public float jumpForce = 2.0f;
    public bool isGrounded;
    Rigidbody rb;



    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }
    void OnCollisionStay()
    {
        isGrounded = true;
    }
    
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 directionVector = new Vector3(h, 0, v);        
        _rigidbody.velocity = directionVector * _speedPlaeyr;
        transform.position += Vector3.down * Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(0, 500, 0));
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
        
    }
}
