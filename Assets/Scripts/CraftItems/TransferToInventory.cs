using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransferToInventory : MonoBehaviour {

    [SerializeField]
    GameObject dataBaseObject;
    CraftItemDatabase dataBase;

    // Use this for initialization
    void Start () {
        dataBase = dataBaseObject.GetComponent<CraftItemDatabase>();
        for (int i = 0; i < dataBase.GetListCount(); ++i)
        {
            CraftItem addItem = gameObject.transform.GetChild(i).GetChild(0).GetComponent<CraftItem>();
            addItem.type = dataBase.GetList()[i].GetComponent<CraftItem>().type;
            addItem.stats = dataBase.GetList()[i].GetComponent<CraftItem>().stats;
        }
    }
}
