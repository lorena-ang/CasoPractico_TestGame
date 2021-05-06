using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteSpawner : MonoBehaviour
{
    public GameObject Meteorite;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(InstanciarMeteorite());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator InstanciarMeteorite()
    {   
        while (true)
        {
            yield return new WaitForSeconds(4);
            Instantiate(Meteorite, new Vector3(Random.Range(-8, 8), 6, 0), Quaternion.identity);
        }
    }
}
