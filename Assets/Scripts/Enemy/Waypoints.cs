using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public Transform[] points;

    EnemySpawner Spawner;

    [Header("Debug")]
    [SerializeField]
    float size = 1.0f;
    [SerializeField]
    Color color = Color.red;

    [Header("Game")]
    [SerializeField]
    int patrols = 0;
    [SerializeField]
    int maxpatrols = 3;
    [SerializeField]
    bool repeat = false;

    // Use this for initialization
    void Start()
    {
        //Get a waypoints
        points = new Transform[transform.childCount];
        for (int i = 0; i < points.Length; i++)
        {
            points[i] = transform.GetChild(i);
        }

        //Find Closest spawn point to path
        GameObject[] Spawners = GameObject.FindGameObjectsWithTag("EnemySpawner");
        float shortestDistance = Mathf.Infinity;
        foreach (GameObject s in Spawners)
        {
            float distance = Vector3.Distance(transform.position, s.transform.position);
            if (distance < shortestDistance)
            {
                shortestDistance = distance;
                EnemySpawner spawn = s.GetComponent<EnemySpawner>();
                Spawner = spawn;
            }
        }

        //Find patrols at start
        GameObject[] patrollers = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject p in patrollers)
        {
            if (p.GetComponent<Enemy>().GetPath() == this)
                patrols++;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool GetRepeat()
    {
        return repeat;
    }

    //Patrols
    public int GetPatrols()
    {
        return patrols;
    }

    public int GetMaxPatrols()
    {
        return maxpatrols;
    }

    public void AddPatrols(int amt)
    {
        patrols += amt;
    }

    public EnemySpawner GetClosetsSpawn()
    {
        return Spawner;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = color;

        Gizmos.DrawWireCube(transform.position, new Vector3(size, size, size));

        points = new Transform[transform.childCount];
        for (int i = 0; i < points.Length; ++i)
        {
            points[i] = transform.GetChild(i);
        }

        for (int j = 0; j < points.Length; ++j)
        {
            Vector3 position = points[j].position;
            if(j > 0)
            {
                Vector3 previous = points[j - 1].position;
                Gizmos.DrawLine(previous, position);
                Gizmos.DrawWireSphere(position, size);
            }
        }
        
    }
}
