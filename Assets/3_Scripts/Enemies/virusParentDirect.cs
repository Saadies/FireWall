﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class virusParentDirect : MonoBehaviour
{
    Animator m_Animator;
    private GameObject mySprite;

    void OnDestroy()
    {
    }

    private void Start()
    {
        setSpeed(0.7f);

        
    }

    private void Awake()
    {
        mySprite = gameObject.transform.GetChild(0).gameObject;
        m_Animator = GetComponent<Animator>();
    }

    public void spawnText(string myText)
    {
        mySprite.GetComponent<s_attachText>().spawnText(myText);
    }

    public void setSpeed(float newSpeed)
    {
        m_Animator.speed = newSpeed;
    }

}
