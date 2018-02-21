using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    [Header("Display")]

    [SerializeField]
    float size = 1.0f;

    [SerializeField]
    Color color = Color.blue;

    [Header("Enemy Types")]

    [SerializeField]
    GameObject Normal;

    [SerializeField]
    GameObject Fast;

    [SerializeField]
    GameObject Tank;

    // Use this for initialization
    void Start () {
        //StartCoroutine("SpawnEnemy", 5.0f);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnDrawGizmos()
    {
        Gizmos.color = color;

        Gizmos.DrawWireCube(transform.position, new Vector3(size, size, size));
    }

    //IEnumerator SpawnEnemy(float waitTime)
    //{
    //    for (int i = 0; i < 10; ++i)
    //    {
    //        yield return new WaitForSeconds(waitTime);
    //        Instantiate(Normal, transform.position, Quaternion.identity);
    //    }
    //}

    public void SpawnNormal(Waypoints p)
    {
        Enemy NormalE = Normal.GetComponent<Enemy>();
        NormalE.Assignpath(p);
        NormalE.SetisLeader(true);
        NormalE.SetEnemySize(3);
        Instantiate(NormalE, transform.position, Quaternion.identity);
    }

    public void SpawnTank(Waypoints p)
    {
        Enemy TankE = Tank.GetComponent<Enemy>();
        TankE.Assignpath(p);
        TankE.SetisLeader(true);
        Instantiate(TankE, transform.position, Quaternion.identity);
    }

    public void SpawnFast(Waypoints p)
    {
        Enemy FastE = Fast.GetComponent<Enemy>();
        FastE.Assignpath(p);
        FastE.SetisLeader(true);
        Instantiate(FastE, transform.position, Quaternion.identity);
    }
}
