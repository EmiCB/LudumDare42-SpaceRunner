using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour {
    public GameObject platformDestPoint;

	void Start(){
        platformDestPoint = GameObject.Find("platform dest point");
	}
	void Update (){
		if (transform.position.x < platformDestPoint.transform.position.x){
            gameObject.SetActive(false);
        }
	}
}
