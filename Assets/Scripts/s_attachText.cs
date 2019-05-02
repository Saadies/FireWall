using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s_attachText : MonoBehaviour
{
    public GameObject text;
    public float lifetime = 2; 
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,lifetime);
    }

    public void spawnText(string textContent)
    {
        //Spawn Text Prefab and set itself as parent
        GameObject newText = Instantiate(text, gameObject.transform);

        newText.GetComponent<s_attachToGameObject>().setText(textContent); 
        newText.GetComponent<s_attachToGameObject>().setParentTransform(gameObject); 


    }
}
