using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gullCollision : MonoBehaviour
{

    private CameraShake cameraShake;


    private GameObject target;
    [SerializeField]
    private int health = 1;


    // Use this for initialization
    void Start()
    {
        //Object.Destroy(gameObject, 5f);

        Camera cam = Camera.main;

        cameraShake = cam.GetComponent<CameraShake>();
    }

    // Update is called once per frame
    void Update()
    {


    }

    void OnDestroy()
    {

        cameraShake.Shake();

        Object.Destroy(transform.parent.gameObject);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        

        
        //Debug.Log(col.gameObject.name + " : " + gameObject.name + " : " + Time.time);
        if (col.gameObject.tag == "bullet")
        {
            if (health == 1)
            {
                Destroy(this);
            }
            health--;
            Destroy(col.gameObject);
        }
        
    }
}
