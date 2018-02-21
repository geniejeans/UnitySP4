using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementScript : MonoBehaviour {

    [SerializeField]
    float movementSpeed = 1.0f;

    [SerializeField]
    float searchDist = 10.0f;

    [SerializeField]
    GameObject target;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 distvec = (target.transform.position - gameObject.transform.position);
        float dist = Mathf.Abs(distvec.magnitude);

        if (dist < searchDist)
        {
            // chase
            gameObject.transform.position += (target.transform.position - gameObject.transform.position).normalized * (Time.deltaTime * movementSpeed);
        }
    }

    //public void OnCollisionStay(Collision other)
    //{
    //    if (other.gameObject.name == "Character")
    //    {
    //        CharacterInstance character = other.gameObject.GetComponent<CharacterInstance>();
    //        character.AddHealth(-0.1f);
    //        Debug.Log(character.GetHealth());
    //    }
    //}
}
