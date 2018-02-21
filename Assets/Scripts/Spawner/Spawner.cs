using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public static Spawner instance;

    [SerializeField]
    GameObject turretblueprint;
    [SerializeField]
    GameObject turret;
    [SerializeField]
    Transform spawnerloc;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one Spawner in scene!");
            return;
        }
        instance = this;
    }

    private void Update()
    {
        spawnerloc.position = GameObject.FindGameObjectWithTag("Player").transform.position;
        spawnerloc.position = new Vector3(spawnerloc.position.x + GameObject.FindGameObjectWithTag("Player").transform.forward.x * 2.5f, spawnerloc.position.y + 0.6f, spawnerloc.position.z + GameObject.FindGameObjectWithTag("Player").transform.forward.z * 2.5f);
    }

    public void SpawnTurret()
    {
        //Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
        // Vector3 mousePositionInWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (GameObject.FindGameObjectWithTag("Base").GetComponent<Base>().Getplayerinbase())
        {
            turretblueprint.SetActive(true);
            spawnerloc = GameObject.FindGameObjectWithTag("Spawner").transform.GetChild(0).transform;
            Instantiate(turretblueprint, spawnerloc.position, Quaternion.identity);
            turretblueprint.GetComponent<Blueprint>().spawnloc = spawnerloc;
        }
        else
            Debug.Log("Player not in base");
    }

    public void BuildTurret()
    {
        Instantiate(turret, spawnerloc.transform.position, Quaternion.identity);
    }

    public void CancelTurret()
    {
        GameObject[] blueprints = GameObject.FindGameObjectsWithTag("TowerBlueprint");
        foreach (GameObject blueprint in blueprints)
        {
            blueprint.SetActive(false);
        }
    }
}
