using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementsController : MonoBehaviour
{
    Vector3 position;
    Rigidbody rb;
    float vertical;
    public float speed = 3f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + Vector3.down * Time.deltaTime * speed;
    }

    private void FixedUpdate()
    {     
        position = rb.position;
        
        if (position.y <= -4)
        {
            Destroy(gameObject);
        }
    }
}
