using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatFood : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnCollisionEnter(Collision other)
    {
        CharacterInstance character = other.gameObject.GetComponent<CharacterInstance>();

        if (other.gameObject.name == "Character")
        {
            if (character.GetHealth() < 20)
            {
                int health;
                health = Random.Range(1, 10);
                character.AddHealth(health);
            }

            Destroy(gameObject);
        }
    }
}
