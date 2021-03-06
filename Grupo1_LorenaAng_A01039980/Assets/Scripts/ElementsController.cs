using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElementsController : MonoBehaviour
{
    Vector3 position;
    Rigidbody rb;
    float vertical;
    public float speed = 3f;
    public Text Lives;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Lives = GameObject.Find("Lives").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + Vector3.down * Time.deltaTime * speed;
    }

    private void FixedUpdate()
    {     
        position = rb.position;
        
        if (position.y <= -4 && gameObject.tag == "Rock")
        {
            int lives = int.Parse(Lives.text) - 1;
            Lives.text = lives.ToString();
            Destroy(gameObject);
        }
        else if (position.y <= -4)
        {
            Destroy(gameObject);
        }
    }
}
