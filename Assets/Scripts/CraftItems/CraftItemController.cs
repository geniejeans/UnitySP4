using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftItemController : MonoBehaviour {
    public GameObject slotPrefab, itemPrefab, textPrefab;
    public Vector2 inventorySize = new Vector2(1, 4);
    public Vector2 windowSize;

    public GameObject dataBaseObject;
    CraftItemDatabase dataBase;
    ScrollPage changingPage;
    public GameObject pageArrows;


    private Transform[] slotTransform;
    private Transform[] slotTextTransform;
    private int previousPageNumber = 1;
    private int pages = 1;

    // Use this for initialization
    void Start () {

        int databaseCounter = 0;
        slotTransform = new Transform[4];
        slotTextTransform = new Transform[4];
        changingPage = pageArrows.GetComponent<ScrollPage>();
        dataBase = dataBaseObject.GetComponent<CraftItemDatabase>();

        //Calculating how many pages it needs
        if ((int)dataBase.GetListCount() > 4)
        {
            if ((int)dataBase.GetListCount() % 4 > 0)
                pages = (int)dataBase.GetListCount() / 4 + 1;
            else
                pages = (int)dataBase.GetListCount() / 4;
        }

        for (int numberOfPages = 1; numberOfPages <= pages; ++numberOfPages)
        {
            for (int x = 1; x <= inventorySize.x; ++x)
            {
                for (int y = 1; y <= inventorySize.y; ++y)
                {
                    if (numberOfPages == 1)
                    {
                        GameObject slot = Instantiate(slotPrefab) as GameObject;
                        slot.transform.SetParent(this.transform);
                        slot.transform.localScale = slotPrefab.transform.localScale;
                        slot.name = "SLOT_" + x + "_" + y;
                        slot.GetComponent<RectTransform>().anchoredPosition = new Vector3(windowSize.x / (inventorySize.x + 1) * x, windowSize.y / (inventorySize.y + 1) * -y, 0);
                        slotTransform[y - 1] = slot.transform;

                        //GameObject slotText = Instantiate(textPrefab) as GameObject;
                        //slotText.transform.parent = this.transform;
                        //slotText.transform.localScale = textPrefab.transform.localScale;
                        //slotText.name = "SLOT_TEXT_" + x + "_" + y;
                        //slotText.GetComponent<RectTransform>().anchoredPosition = new Vector3(windowSize.x / (inventorySize.x + 1) * x, windowSize.y / (inventorySize.y + 1) * -y, 0);
                        //slotTextTransform[y - 1] = slot.transform;
                    }
         
                    if (databaseCounter < dataBase.GetListCount())
                    {
                        //Repositioning the newly instantiated gameobjects from the database
                        dataBase.GetList()[databaseCounter].transform.parent = slotTransform[y-1].transform;
                        dataBase.GetList()[databaseCounter].transform.localScale = itemPrefab.transform.localScale;
                        dataBase.GetList()[databaseCounter].GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
                        //Adding at what page the item should be at
                        dataBase.AddPage(databaseCounter, numberOfPages);
                        //Don't show the rest of the items if it is not in the first page
                        if (numberOfPages > 1)
                        {
                            dataBase.GetList()[databaseCounter].GetComponent<Image>().enabled = false;
                            dataBase.GetList()[databaseCounter].GetComponentInChildren<Text>().enabled = false;
                        }
                           
                        //Iterating through the database
                        databaseCounter++;
                    }
                }
            }
        }
   
    }

    // Update is called once per frame
    void Update() {

        //Updating for if the player changes pages
        if (previousPageNumber != changingPage.GetPageNumber())
        {
            for (int i = 0; i < dataBase.GetListCount(); ++i)
            {
                //Unrender the previous page's items
                if (dataBase.GetList()[i].GetComponent<CraftItem>().atPage == previousPageNumber)
                {
                    dataBase.GetList()[i].GetComponent<Image>().enabled = false;
                    dataBase.GetList()[i].GetComponentInChildren<Text>().enabled = false;
                }
                //Render in the new page's items
                else if (dataBase.GetList()[i].GetComponent<CraftItem>().atPage == changingPage.GetPageNumber())
                {
                    dataBase.GetList()[i].GetComponent<Image>().enabled = true;
                    dataBase.GetList()[i].GetComponentInChildren<Text>().enabled = true;

                    //if (textPrefab.name.Contains("SLOT_TEXT_1_1"))
                    //{
                    //    dataBase.GetList()[i].GetComponent<CharacterInstance>().GetInventory().getFireTowerNumber();
                    //}
                }
            }
            previousPageNumber = changingPage.GetPageNumber();
        }
    }
}
