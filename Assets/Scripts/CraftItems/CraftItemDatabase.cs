using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftItemDatabase : MonoBehaviour {

    public Sprite[] spriteItem;
    public string[] type;
    public int[] buttonNum; 
    public int[] fireEssence;
    public int[] waterEssence;
    public int[] earthEssence;
    public int[] lightningEssence;
    public int[] wood;
    public int[] metal;
    public int[] ectoplasm;
    public int[] stats;
    public GameObject prefab;
    [SerializeField]
    private List<GameObject> itemList;

    void Awake()
    {
        itemList = new List<GameObject>();
        for (int i = 0; i < spriteItem.Length; ++i)
        {
            //Making a new gameobject here so it can be accessed 
            GameObject itemObject = Instantiate(prefab) as GameObject;
            CraftItem item = itemObject.GetComponent<CraftItem>();
            itemObject.GetComponent<Image>().sprite = spriteItem[i];
            item.spriteItem = spriteItem[i];
            item.type = type[i];
            item.stats = stats[i];
            item.built = false;

            if (buttonNum.Length > 0)
                item.buttonNum = buttonNum[i];
            if (fireEssence.Length > 0)
                item.fireEssence = fireEssence[i];
            if (waterEssence.Length > 0)
                item.waterEssence = waterEssence[i];
            if (earthEssence.Length > 0)
                item.earthEssence = earthEssence[i];
            if (lightningEssence.Length > 0)
                item.lightningEssence = lightningEssence[i];
            if (wood.Length > 0)
                item.wood = wood[i];
            if (metal.Length > 0)
                item.metal = metal[i];
            if (ectoplasm.Length > 0)
                item.ectoplasm = ectoplasm[i];
            itemList.Add(itemObject);
        }
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

    public int GetListCount()
    {
        return itemList.Count;
    }

    public List<GameObject> GetList()
    {
        return itemList;
    }

    public void AddPage(int placing, int pageNumber)
    {
        itemList[placing].GetComponent<CraftItem>().atPage = pageNumber;
    }
}
