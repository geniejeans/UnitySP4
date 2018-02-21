using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyID : MonoBehaviour {

    int localID;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //Get which enemy is selected for battle
    public int GetID()
    {
        BattleInstance.Instance.SetEnemySelected(localID);
        return localID;
    }

    public void SetButtonEnemySelected()
    {
        BattleInstance.Instance.SetEnemySelected(localID);
    }

    public void SetID(int value)
    {
        localID = value;
    }
}
