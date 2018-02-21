using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthScript : MonoBehaviour {

    [SerializeField]
    float startHealth = 10.0f;

    float healthPoints;

    // Use this for initialization
    void Start () {
        healthPoints = startHealth;
    }

    public void AddHealth(float amount)
    {
        healthPoints += amount;

        // Die
        if (healthPoints <= 0)
        {
            Destroy(gameObject);
        }
    }

    public float GetHealth()
    {
        return healthPoints;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
