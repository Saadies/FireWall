using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooter1Collision : MonoBehaviour
{
    public float radius;
    public float speed;
    public float spawnBorder = 0.8f;
    protected float startX;
    protected float screenHeight;

    private CameraShake cameraShake;


    private GameObject target;
    [SerializeField]
    private int health = 10;


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
        

        if (health == 1)
        {
            Destroy(this);
        }
        //Debug.Log(col.gameObject.name + " : " + gameObject.name + " : " + Time.time);
        if (col.gameObject.tag == "bullet")
        {
            health--;
            Destroy(col.gameObject);
        }
        
    }
}
