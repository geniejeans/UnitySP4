using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeFragments : MonoBehaviour
{
    [SerializeField]
    Transform text;

    private int lifeFragments;

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
            character.AddLifeFragments(1);

            Destroy(gameObject);
        }
    }
}