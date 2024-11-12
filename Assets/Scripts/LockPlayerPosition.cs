using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockPlayerPosition : MonoBehaviour
{
    private Vector3 fixedPosition;

    // Start is called before the first frame update
    void Start()
    {
          fixedPosition = transform.position;
    }

    void Update()
    {
         transform.position = fixedPosition;

    }
}

