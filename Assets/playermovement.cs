using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:

                    this.transform.position = touch.position;


                    break;
                case TouchPhase.Moved:
                    this.transform.position = touch.position;
                    break;
                case TouchPhase.Ended:
                    this.transform.position = touch.position;
                    break;
                case TouchPhase.Canceled:

                    break;

            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            this.transform.position = mousePosition;
        }
        if (Input.GetMouseButton(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            this.transform.position = mousePosition;
        }
    }
}
