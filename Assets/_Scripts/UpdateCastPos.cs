using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateCastPos : MonoBehaviour
{
    private Vector3 startTransform;
    private Vector3 transformDiff;
    public Transform parent;

    // Start is called before the first frame update
    void Start()
    {
        startTransform = transform.position;
        transformDiff = parent.transform.position - startTransform;
    }

    // Update is called once per frame
    void Update()
    {
        if (parent.transform.localScale.x == -1)
            transform.position = new Vector3(parent.transform.position.x + transformDiff.x, parent.transform.position.y - transformDiff.y, parent.transform.position.z - transformDiff.z);
        else
            transform.position = transform.position = new Vector3(parent.transform.position.x - transformDiff.x, parent.transform.position.y - transformDiff.y, parent.transform.position.z - transformDiff.z);
    }
}
