using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crossbow : MonoBehaviour
{
    bool validPos = false;
    Collider2D thisCollider;
    Vector2 mousePos = new Vector2(0, 0);
    public GameObject arrow;
    public float cooldown = 1.0f;
    float time;
    

    // Start is called before the first frame update
    void Start()
    {
        thisCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = new Vector2(999, 999);

        time += Time.deltaTime;

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
                Instantiate(arrow, gameObject.transform.position,new Quaternion());
                StartCoroutine(disable(cooldown));
            }

            
        }

        validPos = false;

        
    }

    IEnumerator disable(float time)
    {
        thisCollider.enabled = false ;
        yield return new WaitForSeconds(time);
        thisCollider.enabled = true;
    }

}
