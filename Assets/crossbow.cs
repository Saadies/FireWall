using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crossbow : MonoBehaviour
{
    bool validPos = false;
    Collider2D thisCollider;
    Vector2 mousePos = new Vector2(0, 0);
    public GameObject arrow;
    public float cooldown = 0.2f;
    float time;

    // Start is called before the first frame update
    void Start()
    {
        thisCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.time;

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            mousePos = Camera.main.ScreenToWorldPoint(touch.position);

            validPos = true;

        }

        if (Input.GetMouseButtonDown(0))
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            validPos = true;
        }

        //ignore touches on cooldown
        if(time < cooldown)
        {
            validPos = false;
        }

        if (validPos)
        {
            if (thisCollider.OverlapPoint(mousePos))
            {
                Instantiate(arrow, gameObject.transform);
            }

            time = 0f;
        }

        validPos = false;

        
    }

}
