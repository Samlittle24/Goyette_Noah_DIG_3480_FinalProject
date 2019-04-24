using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour
{
    static public float speed = -5.0f;

    public Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
 
    }

    public void setfast()
    {
        rb.velocity = transform.forward * (speed);
    }
    
    public void setslow()
    {
        rb.velocity = transform.forward * speed;
    }

    
}