using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Vector3 position;
    Rigidbody rb;
    float horizontal;
    public float speed = 10.0f;
    public Text Rocks;
    public int score;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {     
        position = rb.position;
        position.x = position.x + horizontal * Time.fixedDeltaTime * speed;
        
        if (position.x > -8 && position.x < 8)
        {
            rb.position = position;
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Rock")
        {
            Destroy(other.gameObject);
            score++;
            Rocks.text = score.ToString();
        }

        if (other.tag == "Power")
        {
            transform.localScale = new Vector3(4,1,1);
            // Aunque no pidieron destruirlo decidí hacerlo para que se viera mejor el juego
            Destroy(other.gameObject);
            StartCoroutine(RegresarOrig(6));
        }
    }
    
    IEnumerator RegresarOrig(float wait)
    {
        yield return new WaitForSeconds(wait);
        transform.localScale = new Vector3(2,1,1);
    }
}