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
    bool speedDecreased = false;
    public GameOver GameOverOb;
    public Text Lives;

    public void GameOverFunc()
    {
        GameOverOb.Setup();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");

        if (int.Parse(Lives.text) <= 0)
        {
            GameOverFunc();
        }
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

        if (other.tag == "Meteorite")
        {
            // De esta manera se va reduciendo a la mitad la velocidad, pero se va regresando la velocidad de tal manera que siga siendo jugable
            if (!speedDecreased)
            {
                speed /= 2;
                speedDecreased = true;
                StartCoroutine(RegresarSpeed(5));
            }
            Destroy(other.gameObject);
        }
    }
    
    IEnumerator RegresarOrig(float wait)
    {
        yield return new WaitForSeconds(wait);
        transform.localScale = new Vector3(2,1,1);
    }

    IEnumerator RegresarSpeed(float wait)
    {
        speedDecreased = false;
        yield return new WaitForSeconds(wait);
        speed *= 2;
    }
}