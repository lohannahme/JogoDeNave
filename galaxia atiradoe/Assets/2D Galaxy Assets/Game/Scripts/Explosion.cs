using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TimeExplode());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator TimeExplode()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}
