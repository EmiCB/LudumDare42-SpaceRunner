using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryController : MonoBehaviour {
    public float speed = 0.1f;
    public float waitTime;
    public bool isMovingBoundaries;
    public bool isResetBoundaries;

    void Start()
    {
        StartCoroutine(Wait());
    }
    public IEnumerator Wait()
    {
        isMovingBoundaries = false;
        yield return new WaitForSeconds(waitTime);
        isMovingBoundaries = true;
    }
}
