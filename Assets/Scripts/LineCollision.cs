using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineCollision : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col.gameObject.name + " : " + gameObject.name + " : " + Time.time);
        if (col.gameObject.tag == "enemy")
        {
            Destroy(col.gameObject);
        }
    }
}
