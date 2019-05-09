using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ratScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Object.Destroy(gameObject, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnDestroy()
    {
        
        Object.Destroy(transform.parent.gameObject);
    }
}
