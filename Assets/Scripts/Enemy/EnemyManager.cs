using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    [SerializeField]
    float RefreshRate = 10.0f;

    [SerializeField]
    EnemySpawner[] spawners;

    [SerializeField]
    Waypoints[] paths;

    Waypoints selected;
    int smallest;

    float difficultyspawn;
    static float basedifficulty = 5.0f;

    // Use this for initialization
    void Start () {
        smallest = 10;
        difficultyspawn = basedifficulty;
	}
	
	// Update is called once per frame
	void Update () {
        //Pause timer if the player is in battle 
        if (CharacterInstance.Instance.GetInBattle())
            return;

            RefreshRate -= Time.deltaTime;
        difficultyspawn = basedifficulty + GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterInventory>().getTotalResource();

        if (RefreshRate <= 0f)
        {

            foreach (Waypoints p in paths)
            {
                if (p.GetPatrols() <= smallest && p.GetPatrols() <= p.GetMaxPatrols())
                {
                    smallest = p.GetPatrols();
                    selected = p;
                }

            }

            if(selected.GetPatrols() < selected.GetMaxPatrols())
                selected.GetClosetsSpawn().SpawnNormal(selected);

            RefreshRate = 10.0f;
            smallest = 10;
        }
	}

    public float GetDifficulty()
    {
        return difficultyspawn;
    }
}
