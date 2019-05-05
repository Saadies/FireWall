using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s_attachText : MonoBehaviour
{
    public GameObject text;
    public float lifetime = 2;
    GameObject newText;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,lifetime);
    }

    public void spawnText(string textContent)
    {
        
        //Spawn Text Prefab and set Canvas as parent
        newText = Instantiate(text, GameObject.Find("Canvas").transform);

        newText.GetComponent<s_attachToGameObject>().setText(textContent); 
        newText.GetComponent<s_attachToGameObject>().setParentTransform(gameObject); 


    }

    private void OnDestroy()
    {
        Destroy(newText);
    }
}
