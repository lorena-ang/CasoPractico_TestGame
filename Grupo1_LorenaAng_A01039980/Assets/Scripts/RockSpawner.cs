using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    public GameObject Rock;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(InstanciarRocks(1));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator InstanciarRocks(float wait)
    {
        while (true)
        {
            yield return new WaitForSeconds(wait);
            Instantiate(Rock, new Vector3(Random.Range(-8, 8), 6, 0), Quaternion.identity);
        }
    }
}
