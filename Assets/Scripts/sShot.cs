using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sShot : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Object.Destroy(gameObject, 0.8f);
        Object.Destroy(transform.parent.gameObject, 0.8f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
