using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sTapShoot : MonoBehaviour
{
    public GameObject shot;
    public GameObject player;
    [SerializeField]
    private float startY;
    [SerializeField]
    private Vector2 tapPos;
    [SerializeField]
    private Vector3 spawnPos;

    private void Start()
    {
        /*
        Vector3 tempStart = new Vector3(player.GetComponent<BoxCollider2D>().transform.position.x, player.GetComponent<BoxCollider2D>().transform.position.y, 0);
        startY = Camera.main.ScreenToWorldPoint(tempStart).y;
        Vector3 worldTapPos = Camera.main.ScreenToWorldPoint(new Vector3(tapPos.x, startY, 0));
        */
        //startY = 200;
        startY = player.transform.position.y;
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
                    break;
                case TouchPhase.Moved:
                    break;
                case TouchPhase.Ended:
					getPosition(true);
                    break;
                case TouchPhase.Canceled:
                    break;

            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            getPosition(false);
        }


    }

    protected virtual void getPosition(bool mobile)
    {
        if (mobile)
        {
            Touch touch = Input.GetTouch(0);
            tapPos = touch.position;
        }
        else
        {
            tapPos = Input.mousePosition;
        }



        
        Vector3 mousePos = new Vector3(tapPos.x,tapPos.y,0);
        spawnPos = Camera.main.ScreenToWorldPoint(mousePos);
        //spawnPos.y = +90;
       
        if (spawnPos.y <= startY)
        {
            GameObject newShot = Instantiate(shot,spawnPos, new Quaternion());
        }
            

    }
}
