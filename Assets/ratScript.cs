using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ratScript : MonoBehaviour
{
    public GameObject deathParticle;
    public GameObject corpse;
    // Start is called before the first frame update
    void Start()
    {
        //Clean up in case of bug
        Destroy(gameObject, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnDestroy()
    {
        //Should destroy itself onStart
        //Destroy(corpse, 0.3f);
        Instantiate(corpse, this.transform.position, this.transform.rotation);

        Vector3 particlepos = this.transform.position;
        particlepos.y = particlepos.y - 30;
        Instantiate(deathParticle, particlepos, new Quaternion());
        Destroy(transform.parent.gameObject,5f);
    }

}
