using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
namespace UnityLibrary
{
    public class DrawLine2D : MonoBehaviour
    {

        [SerializeField]
        private LineRenderer m_LineRenderer;
        [SerializeField]
        private LineRenderer mOld_LineRenderer;
        //[SerializeField]
        //protected bool m_AddCollider = false;
        [SerializeField]
        private EdgeCollider2D m_EdgeCollider2D;
        [SerializeField]
        private EdgeCollider2D mOld_EdgeCollider2D;



        protected List<Vector2> m_Points;
        public float[] lineLength = new float[10];
        [SerializeField]
        protected float lineLength_max = 30f;
        [SerializeField]
        protected float normMaxDist = 60f;

        private int touchframes = 0;
        private float shootbarrierDelay = 20f;

        [SerializeField]
        private float startY;
        public GameObject player;

        //debug
        public Vector2 normalizedDEBUG;

        
        /*
        public virtual bool addCollider
        {
            get
            {
                return m_AddCollider;
            }
        }
        */
        public virtual EdgeCollider2D edgeCollider2D
        {
            get
            {
                return m_EdgeCollider2D;
            }
        }

        public virtual LineRenderer lineRenderer
        {
            get
            {
                return m_LineRenderer;
            }
        }

        public virtual EdgeCollider2D old_edgeCollider2D
        {
            get
            {
                return mOld_EdgeCollider2D;
            }
        }

        public virtual LineRenderer old_lineRenderer
        {
            get
            {
                return mOld_LineRenderer;
            }
        }


        public virtual List<Vector2> points
        {
            get
            {
                return m_Points;
            }
        }

        protected virtual void Awake()
        {
            if (m_LineRenderer == null)
            {
                Debug.LogWarning("DrawLine: Line Renderer not assigned, Adding and Using default Line Renderer.");
                CreateDefaultLineRenderer();
            }
            if (m_EdgeCollider2D == null)
            {
                Debug.LogWarning("DrawLine: Edge Collider 2D not assigned, Adding and Using default Edge Collider 2D.");
                CreateDefaultEdgeCollider2D();
            }
            m_Points = new List<Vector2>();

            startY = player.transform.position.y - shootbarrierDelay;
        }

        protected virtual void Update()
        {
            Vector2 thisPos;
            Vector2 mousePosition;

            if (Input.touchCount > 0)
            {
                touchframes++;
                Touch touch = Input.GetTouch(0);

                
                thisPos = touch.position;

                mousePosition = Camera.main.ScreenToWorldPoint(thisPos);

                switch (touch.phase)
                {
                    case TouchPhase.Began:

                        touchframes = 0;
                        if (startY <= mousePosition.y)
                        {
                            //Reset();
                            disableLine();
                            getPosition(false);
                        }

                        break;
                    case TouchPhase.Moved:
                        touchframes++;

                        thisPos = Input.mousePosition;
                        mousePosition = Camera.main.ScreenToWorldPoint(thisPos);

                        if (startY < mousePosition.y)
                        {
                            getPosition(false);
                        }

                        if (touchframes >= 2 && lineLength[0] > 5)
                        {
                            enableLine();
                            ResetOldLine();
                        }

                        break;
                    case TouchPhase.Ended:
                        if (lineLength[0] > 5)
                        {
                            saveLine();
                            lineLength[1] = lineLength[0];

                        }
                        Reset();
                        break;
                    case TouchPhase.Canceled:
                        if (lineLength[0] > 5)
                        {
                            saveLine();
                            lineLength[1] = lineLength[0];

                        }
                        Reset();
                        break;

                }
            }
            if (Input.GetMouseButtonDown(0))
            {
                touchframes++;

                thisPos = Input.mousePosition;
                mousePosition = Camera.main.ScreenToWorldPoint(thisPos);

                
                if(startY <= mousePosition.y)
                {
                    //Reset();
                    disableLine();
                    getPosition(false);
                }
                
                
            }
            if (Input.GetMouseButton(0))
            {
                touchframes++;

                thisPos = Input.mousePosition;
                mousePosition = Camera.main.ScreenToWorldPoint(thisPos);

                if (startY < mousePosition.y)
                {
                    getPosition(false);
                }

                if( touchframes >=2 && lineLength[0] > 5)
                {
                    enableLine();
                    ResetOldLine();
                }

            }
            if (Input.GetMouseButtonUp(0))
            {
                if (lineLength[0] > 5) { 
                    saveLine();
                    lineLength[1] = lineLength[0];
                    
                }
                Reset();

                //save old lineLength

                //letGo = true;
            }
            if (!Input.GetMouseButton(0))
            {
                touchframes = 0;
            }
        }

        void saveLine()
        {
            if (m_EdgeCollider2D != null && m_LineRenderer != null)
            {
                Vector3[] newPos = new Vector3[m_LineRenderer.positionCount]; 
                mOld_EdgeCollider2D.points = m_EdgeCollider2D.points;

                m_LineRenderer.GetPositions(newPos);

                mOld_LineRenderer.positionCount = m_LineRenderer.positionCount;
                mOld_LineRenderer.SetPositions(newPos);

                mOld_LineRenderer.enabled = true;
                mOld_EdgeCollider2D.enabled = true;

            }
            
        }

        void copyColliderPoints()
        {
            mOld_EdgeCollider2D.points = m_EdgeCollider2D.points;

        }


        void disableLine()
        {
            //m_LineRenderer.enabled = false;
            m_EdgeCollider2D.enabled = false;
        }

        void enableLine()
        {
            m_LineRenderer.enabled = true;
            m_EdgeCollider2D.enabled = true;
        }

        protected virtual void Reset()
        {
            
            if (m_LineRenderer != null)
            {
                m_LineRenderer.positionCount = 0;
            }
            if (m_Points != null)
            {
                m_Points.Clear();
                lineLength[0] = 0;
                //lineLength[1] = 0;
            }
            if (m_EdgeCollider2D != null)
            {
                m_EdgeCollider2D.enabled = false;
            }
        }

        protected virtual void ResetOldLine()
        {

            if (mOld_LineRenderer != null)
            {
                mOld_LineRenderer.positionCount = 0;
            }
            if (m_Points != null)
            {
                //only clear points in new Line
                //m_Points.Clear();
                lineLength[1] = 0;
            }
            if (mOld_EdgeCollider2D != null)
            {
                mOld_EdgeCollider2D.enabled = false;
            }
        }

        protected virtual void CreateDefaultLineRenderer()
        {
            m_LineRenderer = gameObject.AddComponent<LineRenderer>();
            m_LineRenderer.positionCount = 0;
            m_LineRenderer.material = new Material(Shader.Find("Materials/wall"));
            m_LineRenderer.startColor = Color.white;
            m_LineRenderer.endColor = Color.white;
            m_LineRenderer.startWidth = 1.0f;
            m_LineRenderer.endWidth = 1.0f;
            m_LineRenderer.useWorldSpace = true;
        }

        protected virtual void CreateDefaultEdgeCollider2D()
        {
            m_EdgeCollider2D = gameObject.AddComponent<EdgeCollider2D>();
        }
		
		protected void enableCollider(){
			m_EdgeCollider2D.enabled = true;
		}
		protected void disableCollider(){
			m_EdgeCollider2D.enabled = false;
		}

        protected virtual bool getPosition(bool mobile)
        {
            bool setSuccess = false;

            if (lineLength[0] <= lineLength_max)
            {
                lineLength[1] = lineLength[0];
                Vector2 thisPos;
                if (mobile)
                {
                    Touch touch = Input.GetTouch(0);
                    thisPos = touch.position;
                }
                else
                {
                    thisPos = Input.mousePosition;
                }
                

                Vector2 worldPos = Camera.main.ScreenToWorldPoint(thisPos);


                if (!m_Points.Contains(worldPos))
                {

                    //add new position
                    m_Points.Add(worldPos);

                    //get linelength
                    if (m_Points.Count > 1)
                    {
                        lineLength[0] += Vector2.Distance(m_Points[m_Points.Count - 2], m_Points[m_Points.Count - 1]);
                    }

                    //check if length ok
                    if (lineLength[0] <= lineLength_max)
                    {
                        setSuccess = true;
                        realizeLine(worldPos);
                    }
                    else
                    {
						
						//Reduce length of line to max lineLength
                        //ToDo: check m_points length 
                        Vector2 dir = m_Points[m_Points.Count - 1] - m_Points[m_Points.Count - 2];
                        
						//get distance left till max linelength 
						// float dist = Mathf.Clamp(Vector2.Distance(m_Points[m_Points.Count - 2], m_Points[m_Points.Count - 1]), 0, normMaxDist);
                        float dist = lineLength_max - lineLength[1];
						
						
                        //Set new position in same direction but shorter length
					    Vector2 mousePositionNorm = m_Points[m_Points.Count - 2] + (dir.normalized * dist);

                        //replace new position
                        m_Points[m_Points.Count - 1] = mousePositionNorm;

                        realizeLine(mousePositionNorm);

                        setSuccess = true;
                        //new line length
                    }
                }
            }

            return setSuccess;

        }

        void realizeLine(Vector2 newPos)
        {
            //add position to LineRenderer
            m_LineRenderer.positionCount = m_Points.Count;
            m_LineRenderer.SetPosition(m_LineRenderer.positionCount - 1, newPos);

            //add position to edgeCollider
             if (m_EdgeCollider2D != null && m_Points.Count > 1)
             {
                 m_EdgeCollider2D.points = m_Points.ToArray();
                
             }
        }
    }
}


/*
if (Input.GetMouseButton(0) && lineLength[0] <= lineLength_max)
//if (Input.GetTouch[0]. && lineLength[0] <= lineLength_max)
{
    Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    if (!m_Points.Contains(mousePosition) )
    {
        //save old lineLength
        lineLength[1] = lineLength[0];


        //add new position
        m_Points.Add(mousePosition);

        //get linelength
        if (m_Points.Count > 1)
        {
            lineLength[0] += Vector2.Distance(m_Points[m_Points.Count - 2], m_Points[m_Points.Count - 1]);
        }

        //check if length ok
        if (lineLength[0] <= lineLength_max)
        {
            //set LineRenderer
            m_LineRenderer.positionCount = m_Points.Count;
            m_LineRenderer.SetPosition(m_LineRenderer.positionCount - 1, mousePosition);

            //set EdgeCollider
            if (m_EdgeCollider2D != null && m_AddCollider && m_Points.Count > 1)
            {
                m_EdgeCollider2D.points = m_Points.ToArray();
            }
        }
        else
        {

            //ToDo: check m_points length 
            Vector2 dir = m_Points[m_Points.Count - 1] - m_Points[m_Points.Count - 2];
            float dist = Mathf.Clamp(Vector2.Distance(m_Points[m_Points.Count - 2], m_Points[m_Points.Count - 1]), 0, normMaxDist);
            Vector2 mousePositionNorm = m_Points[m_Points.Count - 2] + (dir.normalized * dist);

            //replace new position
            m_Points[m_Points.Count - 1] = mousePositionNorm;

            //set LineRenderer
            m_LineRenderer.positionCount = m_Points.Count;
            m_LineRenderer.SetPosition(m_LineRenderer.positionCount - 1, mousePositionNorm);

            //set EdgeCollider
            if (m_EdgeCollider2D != null && m_AddCollider && m_Points.Count > 1)
            {
                m_EdgeCollider2D.points = m_Points.ToArray();
            }
        }   
    }
    */





