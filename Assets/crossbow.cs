using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crossbow : MonoBehaviour
{
    bool validPos = false;
    Collider2D thisCollider;
    Animator m_Animator;
    Vector2 mousePos = new Vector2(0, 0);
    public GameObject arrow;
    public float cooldown = 1.0f;
    float time;
    public GameObject child;
    ParticleSystem ChildparticleSystem;
    

    // Start is called before the first frame update
    void Start()
    {
        thisCollider = GetComponent<Collider2D>();
        
        m_Animator = GetComponent<Animator>();

        ChildparticleSystem = child.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if(cooldown == 0)
        {
            cooldown = 0.05f;
        }
        mousePos = new Vector2(999, 999);

        time += Time.deltaTime;

        if (Input.touchCount > 0)
        {

            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    mousePos = Camera.main.ScreenToWorldPoint(touch.position);

                    validPos = true;
                break;
            }
           

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
        playAnimations();
        yield return new WaitForSeconds(time);
        thisCollider.enabled = true;
    }

    void playAnimations()
    {

        m_Animator.speed = 1 / cooldown;
        var main = ChildparticleSystem.main;
        main.simulationSpeed = 1 / cooldown;

        m_Animator.SetTrigger("shootTrigger");
        ChildparticleSystem.Stop(true);
        ChildparticleSystem.Play(true);
    }

}
