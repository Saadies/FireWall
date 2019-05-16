using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnCorpse : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Clean up in case of bug
        Destroy(gameObject, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnDestroy()
    {

    }

}
