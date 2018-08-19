using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryLeft : MonoBehaviour {
    public BoundaryController bc;

	void Start () {
        bc = FindObjectOfType<BoundaryController>();
    }
	
	void Update () {
        if (transform.localScale.x < 9 && bc.isMovingBoundaries)
        {
            transform.localScale += new Vector3(bc.speed, 0, 0);
        }
        else
        {
            transform.localScale = transform.localScale;
        }

        if (bc.isResetBoundaries)
        {
            transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
        }
    }
}
