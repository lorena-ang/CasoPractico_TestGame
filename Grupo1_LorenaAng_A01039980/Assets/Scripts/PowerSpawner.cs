using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerSpawner : MonoBehaviour
{
    public GameObject Power;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(InstanciarPower(15));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator InstanciarPower(float wait)
    {
        while (true)
        {
            yield return new WaitForSeconds(wait);
            Instantiate(Power, new Vector3(Random.Range(-8, 8), 6, 0), Quaternion.identity);
        }
    }
}
