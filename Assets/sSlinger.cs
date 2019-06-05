using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sSlinger : MonoBehaviour
{
    public GameObject Ball;
    public GameObject LineL;
    public GameObject LineR;
    public GameObject Slinger;
    public GameObject NewBall;
    public GameObject centerPivot;

    private LineRenderer LineLRender;
    private LineRenderer LineRRender;
    private Collider2D thisCollider;
    private Vector3 worldPos;

    //https://www.youtube.com/watch?v=7OJQ6MbHuvQ "Folow Mouse"
    [SerializeField]
    private float actualDistance;

    [SerializeField]
    private Vector2 mousePosition;

    public float Ballforce;
    public float forceDistance;

    private bool active = false;

    // Start is called before the first frame update
    void Start()
    {
        LineLRender = LineL.GetComponent<LineRenderer>();
        LineRRender = LineR.GetComponent<LineRenderer>();
        thisCollider = this.GetComponent<Collider2D>();

        Vector3 toObjectVector = Ball.transform.position - Camera.main.transform.position;
        Vector3 linearDistanceVector = Vector3.Project(toObjectVector, Camera.main.transform.forward);
        actualDistance = linearDistanceVector.magnitude;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            mousePosition = touch.position;

            Vector3 startPos = Camera.main.ScreenToWorldPoint(mousePosition);

            

            if (thisCollider.OverlapPoint(startPos))
            {
                active = true;

                getWorldPos(mousePosition);
            }
            if (active)
            {
                switch (touch.phase)
                {
                    case TouchPhase.Began:

                        break;
                    case TouchPhase.Moved:

                        break;
                    case TouchPhase.Ended:
                        spawnBall();
                        active = false;
                        break;
                    case TouchPhase.Canceled:
                        spawnBall();
                        active = false;
                        break;
                }
            }
            


        }

        if (Input.GetMouseButtonDown(0))
        {
            mousePosition = Input.mousePosition;

            Vector3 startPos = Camera.main.ScreenToWorldPoint(mousePosition);
            if (thisCollider.OverlapPoint(mousePosition))
            {
                active = true;

                getWorldPos(mousePosition);
            }
        }

        if (Input.GetMouseButton(0))
        {
            mousePosition = Input.mousePosition;
            if (active)
            {
                getWorldPos(mousePosition);
            }
            

        }

        if (Input.GetMouseButtonUp(0))
        {
            if (active)
            {
                spawnBall();
                active = false;
            }
            
        }

    }

    void spawnBall()
    {
        GameObject iNewBall = Instantiate(NewBall, Ball.transform.position, new Quaternion(), this.transform);
        Rigidbody2D iNewBallRigidbody = iNewBall.GetComponent<Rigidbody2D>();

        Vector3 direction = centerPivot.transform.position - iNewBall.transform.position;
        float distance = Vector2.Distance(centerPivot.transform.position, iNewBall.transform.position);
        distance = distance / forceDistance;
        Debug.Log(distance);

        iNewBallRigidbody.AddForce(direction*(Ballforce*distance),ForceMode2D.Impulse);
    }

    void resetLineRender()
    {
        //LineL : -8,-20,-16| 0,0,1.1
        //LineR:   8,-20, -16 | 0,0,1.1

    }
    void setLines(float x, float y, float z)
    {
        LineLRender.SetPosition(1,new Vector3(x,y,z));
        LineRRender.SetPosition(1, new Vector3(x, y, z));
    }

    void getWorldPos(Vector3 mousePosition)
    {
        
        mousePosition.z = actualDistance;

        

        worldPos = Camera.main.ScreenToWorldPoint(mousePosition);

        setLines(worldPos.x, worldPos.y, worldPos.z);

        setBall(worldPos);
    }

    void setBall(Vector3 position)
    {
        Ball.transform.position = position;

        
    }


}
