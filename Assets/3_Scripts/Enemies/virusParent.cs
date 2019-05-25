using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class virusParent : MonoBehaviour
{
    Animator m_Animator;
    private GameObject mySprite;
    

    void OnDestroy()
    {
        /*
        if (transform.parent.gameObject != null)
        {
            Object.Destroy(transform.parent.gameObject);
        }
        */
    }

    private void Start()
    {
        //cleanup bugged
        Destroy(gameObject, 5f);

        
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

    public void enableFlutter()
    {
        m_Animator.SetBool("Flutter", true);
    }

}

