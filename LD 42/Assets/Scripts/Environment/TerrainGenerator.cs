using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    public GameObject platform;
    public Transform genPoint;
    public Transform delPoint;

    public ObjectPooler op;
    public ObjectPooler rockPool;
    public ObjectPooler shipPool;

    [SerializeField]
    private float _rockThreshold;
    [SerializeField]
    private float _shipThreshold;

    private float _platWidth;


    void Start(){
        _platWidth = platform.GetComponent<BoxCollider2D>().size.x;
    }
    void Update(){
        //ground
        if(transform.position.x < genPoint.position.x){
            transform.position = new Vector3(transform.position.x + _platWidth, transform.position.y, transform.position.z);
            GameObject newGround = op.GetPooledObject();
            newGround.transform.position = transform.position;
            newGround.transform.rotation = transform.rotation;
            newGround.SetActive(true);
        }

        //rocks
        if(Random.Range(0f, 100f) < _rockThreshold){
            GameObject newRock = rockPool.GetPooledObject();

            Vector3 rockPosition = new Vector3(0f, 0.5f, 0f);

            newRock.transform.position = transform.position + rockPosition;
            newRock.transform.rotation = transform.rotation;
            newRock.SetActive(true);
        }
        //ship
        if (Random.Range(0f, 100f) < _shipThreshold)
        {
            GameObject newShip = shipPool.GetPooledObject();

            Vector3 shipPosition = new Vector3(0f, 2.25f, 0f);

            newShip.transform.position = transform.position + shipPosition;
            newShip.transform.rotation = transform.rotation;
            newShip.SetActive(true);
        }
    }
}
