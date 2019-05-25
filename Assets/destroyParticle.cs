using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyParticle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var psys = this.GetComponent<ParticleSystem>();

        //Destroy(this.gameObject, psys.main.duration);
        Destroy(this.gameObject, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
