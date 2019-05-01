using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class virusParent : MonoBehaviour
{
    Animator m_Animator;


    void OnDestroy()
    {
        Object.Destroy(transform.parent.gameObject);
    }

    private void Start()
    {
        setSpeed(0.5f);
    }

    private void Awake()
    {
        m_Animator = GetComponent<Animator>();
    }

    public void setSpeed(float newSpeed)
    {
        m_Animator.speed = newSpeed;
    }

}
