using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Virus1Script : MonoBehaviour {
	public float radius;
	public float speed;
    public float spawnBorder = 0.8f;
    protected float startX;
    protected float screenHeight;

    private CameraShake cameraShake;
    
    
    private GameObject target;
	// Use this for initialization
	void Start () {
        Object.Destroy(gameObject, 10f);

        Camera cam = Camera.main;

        cameraShake = cam.GetComponent<CameraShake>();
	}
	
	// Update is called once per frame
	void Update () {


	}

    void OnDestroy()
    {

        cameraShake.Shake();

        Object.Destroy(transform.parent.gameObject);
    }
}

