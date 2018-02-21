using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLight : MonoBehaviour {

    public Light lt;
    public Light lt2;

    // Use this for initialization
    void Start () {

        lt.range = 40.0f;
        lt2.range = 40.0f;
    }
	
	// Update is called once per frame
	void Update () {
        lt.range -= Time.deltaTime * Time.timeScale;
        lt2.range -= Time.deltaTime * Time.timeScale;
    }
}
