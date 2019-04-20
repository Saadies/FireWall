using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class virusParent : MonoBehaviour
{
    void OnDestroy()
    {
        Object.Destroy(transform.parent.gameObject);
    }
}
