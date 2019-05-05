using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Object = UnityEngine.Object;

public class Text_Decrease_Script : MonoBehaviour
{

    private float startTime;
    private float step;
    public float speed_move;
    public float speed_gamma;
    public float animation_length;

    //REFERENCE https://gist.github.com/vml-rmott/6fe126299b4cb5a8c4306a92eb943100
    private Material m_Material;

    [Range(0f, 1f)]
    public float maskWipeControl;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        m_Material = GetComponent<MaskableGraphic>().materialForRendering;
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed_move * Time.deltaTime;


        maskWipeControl -= speed_gamma;

        m_Material.SetFloat("_MaskWipeControl", maskWipeControl);
        //this.transform.position = Vector2.MoveTowards(this.transform.position, new Vector2(startX, -screenHeight), step);
        this.transform.position = Vector2.MoveTowards(this.transform.position, new Vector2(this.transform.position.x, -50000), step);

        Object.Destroy(gameObject, animation_length);
    }
}
