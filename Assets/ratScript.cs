using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ratScript : MonoBehaviour
{
    public GameObject deathParticle;
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
        GameObject corpse = Instantiate(gameObject.gameObject, this.transform.position, new Quaternion());
        Destroy(corpse, 0.3f);
        Instantiate(deathParticle, this.transform.position, new Quaternion());
        Object.Destroy(transform.parent.gameObject);
    }
}
