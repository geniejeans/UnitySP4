using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blueprint : MonoBehaviour {

    public Transform spawnloc;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.position = spawnloc.position;

        if (gameObject.CompareTag("TrapBlueprint"))
            gameObject.transform.position = new Vector3(spawnloc.position.x, spawnloc.position.y - 1.15f, spawnloc.position.z);
    }
}
