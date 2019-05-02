using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class s_attachToGameObject : MonoBehaviour
{
    GameObject myParent;
    public float offsetX;
    public float offsetY;
    Vector3 parentTransform;
    TextMeshProUGUI myText;
    public string enterText;

    // Start is called before the first frame update
    void Awake()
    {
        //Get Text Component on instantiation
        myText = gameObject.GetComponent<TextMeshProUGUI>();
        
    }

    public void setText(string enterText)
    {

        myText.SetText(enterText);
        //StartCoroutine(spawnText());
    }

    public void setParentTransform(GameObject parent)
    {
        myParent = parent;
    }

    // Update is called once per frame
    void Update()
    {
        //move with parent
        if (myParent != null)
        {
            parentTransform = myParent.transform.position;
            parentTransform.x += offsetX;
            parentTransform.y += offsetY;

            gameObject.transform.position = parentTransform;
        }
        else
        {
            Debug.Log(gameObject + " has no parent attached!");
        }
        
    }

    IEnumerator spawnText()
    {

        int totalVisibleCharacters = myText.textInfo.characterCount;

        int counter = 0;
        bool run = true;
        while (run)
        {
            int visibleCount = counter % (totalVisibleCharacters + 1);

            myText.maxVisibleCharacters = visibleCount;

            if (visibleCount >= totalVisibleCharacters)
            {
                yield return run = false;
            }

            yield return new WaitForSeconds(0.05f);
        }

        
    }
}
