using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sSlinger : MonoBehaviour
{
    public GameObject Ball;
    public GameObject LineL;
    public GameObject LineR;
    public GameObject Slinger;

    private LineRenderer LineLRender;
    private LineRenderer LineRRender;
    //https://www.youtube.com/watch?v=7OJQ6MbHuvQ "Folow Mouse"
    [SerializeField]
    private float actualDistance;

    [SerializeField]
    private Vector2 mousePosition;

    private bool active = false;

    // Start is called before the first frame update
    void Start()
    {
        LineLRender = LineL.GetComponent<LineRenderer>();
        LineRRender = LineR.GetComponent<LineRenderer>();

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

            getWorldPos(mousePosition);

            switch (touch.phase)
            {
                case TouchPhase.Began:

                    break;
                case TouchPhase.Moved:

                    break;
                case TouchPhase.Ended:

                    active = false;
                    break;
                case TouchPhase.Canceled:
                    active = false;
                    break;
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            mousePosition = Input.mousePosition;

            getWorldPos(mousePosition);
        }

        if (Input.GetMouseButton(0))
        {
            mousePosition = Input.mousePosition;

            getWorldPos(mousePosition);

        }

        if (Input.GetMouseButtonUp(0))
        {
            active = false;
        }

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
        Vector3 worldPos;
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
