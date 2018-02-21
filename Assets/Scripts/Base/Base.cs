using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Base : MonoBehaviour {

    [SerializeField]
    int startlives = 0;
    int lives;
    [SerializeField]
    Text livesdisplay;
    [SerializeField]
    float range = 10.0f;

    GameObject player;
    bool playerinbase;

    // Use this for initialization
    void Start () {
        lives = startlives;
        livesdisplay.text = "Lives: " + lives;
        playerinbase = false;
    }

    // Update is called once per frame
    void Update()
    {
        livesdisplay.text = "Lives: " + lives;

        //Check for player in range
        player = GameObject.FindGameObjectWithTag("Player");
        float distanceToEnemy = Vector3.Distance(gameObject.transform.position, player.transform.position);

        if (Vector3.Distance(player.transform.position, gameObject.transform.position) <= range)
            Setplayerinbase(true);
        else
            Setplayerinbase(false);
    }

    public void AddLives(int amt)
    {
        lives += amt;
    }

    public int GetLives()
    {
        return lives;
    }

    public void Setplayerinbase(bool _tf)
    {
        playerinbase = _tf;
    }

    public bool Getplayerinbase()
    {
        return playerinbase;
    } 

    public float Getrange()
    {
        return range;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
