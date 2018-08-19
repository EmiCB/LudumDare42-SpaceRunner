using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryTop : MonoBehaviour {
    public BoundaryController bc;

    void Start()
    {
        bc = FindObjectOfType<BoundaryController>();
    }

    void Update()
    {
        if (transform.localScale.y < 25 && bc.isMovingBoundaries)
        {
            transform.localScale += new Vector3(0, bc.speed, 0);
        }
        else
        {
            transform.localScale = transform.localScale;
        }

        if (bc.isResetBoundaries)
        {
            transform.localScale = new Vector3(transform.localScale.x, 1, transform.localScale.z);
        }
    }
}
