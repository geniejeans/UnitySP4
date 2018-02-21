using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour {

    [SerializeField]
    GameObject target;

	// Use this for initialization
	void Start () {
        Set();
    }
	
	// Update is called once per frame
	void Update () {
        Set();
	}

    void Set()
    {
        gameObject.transform.position = new Vector3(target.transform.position.x, target.transform.position.y + 50, target.transform.position.z);
    }
}
