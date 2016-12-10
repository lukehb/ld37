using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damagable : MonoBehaviour {

    private Vector3 cameraRestorePosition;

	// Use this for initialization
	void Start () {
        cameraRestorePosition = Camera.main.transform.position;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other){
        Damager damager = other.GetComponent<Damager>();
        if(damager != null)
        {
            Camera.main.GetComponent<ScreenShakeEffect>().StartScreenShake();
        }
    }

}
