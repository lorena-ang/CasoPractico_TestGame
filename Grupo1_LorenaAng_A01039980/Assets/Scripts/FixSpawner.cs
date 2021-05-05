using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixSpawner : MonoBehaviour
{
    public GameObject Power;
    public GameObject Rock;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(InstanciarObj());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     IEnumerator InstanciarObj()
    {   
        while (true)
        {
            float rand_v = Random.Range(1, 12);
            yield return new WaitForSeconds(1);

            if (rand_v == 1)
            {
                Instantiate(Power, new Vector3(Random.Range(-8, 8), 6, 0), Quaternion.identity);
            }
            else
            {
                Instantiate(Rock, new Vector3(Random.Range(-8, 8), 6, 0), Quaternion.identity);
            }
        }
    }
}