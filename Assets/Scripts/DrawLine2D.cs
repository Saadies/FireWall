﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UnityLibrary
{
    public class DrawLine2D : MonoBehaviour
    {

        [SerializeField]
        protected LineRenderer m_LineRenderer;
        [SerializeField]
        protected bool m_AddCollider = false;
        [SerializeField]
        protected EdgeCollider2D m_EdgeCollider2D;
        protected List<Vector2> m_Points;
        public float[] lineLength = new float[10];
        [SerializeField]
        protected float lineLength_max = 30f;
        [SerializeField]
        protected float normMaxDist = 60f;

        private int touchframes = 0;
        private float shootbarrierDelay = 50f;

        [SerializeField]
        private float startY;
        public GameObject player;

        //debug
        public Vector2 normalizedDEBUG;

        public virtual LineRenderer lineRenderer
        {
            get
            {
                return m_LineRenderer;
            }
        }

        public virtual bool addCollider
        {
            get
            {
                return m_AddCollider;
            }
        }

        public virtual EdgeCollider2D edgeCollider2D
        {
            get
            {
                return m_EdgeCollider2D;
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
            if (m_EdgeCollider2D == null && m_AddCollider)
            {
                Debug.LogWarning("DrawLine: Edge Collider 2D not assigned, Adding and Using default Edge Collider 2D.");
                CreateDefaultEdgeCollider2D();
            }
            m_Points = new List<Vector2>();

            startY = player.transform.position.y - shootbarrierDelay;
        }

        protected virtual void Update()
        {

            if (Input.touchCount > 0)
            {
                touchframes++;
                Touch touch = Input.GetTouch(0);

                Vector2 thisPos;
                thisPos = touch.position;

                Vector2 mousePosition = Camera.main.ScreenToWorldPoint(thisPos);

                switch (touch.phase)
                {
                    case TouchPhase.Began:


                        touchframes = 0;

                        break;
                    case TouchPhase.Moved:
                        if (touchframes == 2)
                        {
                            Reset();
                        }
                        if (startY < mousePosition.y)
                        {
                            getPosition(true);
                        }
                        break;
                    case TouchPhase.Ended:
                        if (startY < mousePosition.y)
                        {
                            getPosition(true);
                        }
                        break;
                    case TouchPhase.Canceled:
                        break;

                }
            }
            if (Input.GetMouseButtonDown(0))
            {
                touchframes++;
            }
            if (Input.GetMouseButton(0))
            {
                touchframes++;
                Vector2 thisPos;
                thisPos = Input.mousePosition;
                Vector2 mousePosition = Camera.main.ScreenToWorldPoint(thisPos);

                if (touchframes == 2)
                {
                    Reset();
                }
                    if (startY < mousePosition.y && touchframes >= 2)
                {
                    getPosition(false);
                }
            }
            if (!Input.GetMouseButton(0))
            {
                touchframes = 0;
            }
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
                lineLength[1] = 0;
            }
            if (m_EdgeCollider2D != null && m_AddCollider)
            {
                m_EdgeCollider2D.Reset();
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

        protected virtual void getPosition(bool mobile)
        {
            if (lineLength[0] <= lineLength_max)
            {
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
                

                Vector2 mousePosition = Camera.main.ScreenToWorldPoint(thisPos);


                if (!m_Points.Contains(mousePosition))
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





