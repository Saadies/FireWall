using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnRatDeath : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
        Destroy(gameObject, 0.3f);
    }
    private void Awake()
    {
        ParticleSystem myParticle = gameObject.GetComponent<ParticleSystem>();
        myParticle.playbackSpeed = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
