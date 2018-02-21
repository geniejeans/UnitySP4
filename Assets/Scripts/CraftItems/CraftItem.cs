using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftItem : MonoBehaviour {
    public Sprite spriteItem;
    public string type;
    public int buttonNum;
    public bool built;
    public int fireEssence;
    public int waterEssence;
    public int earthEssence;
    public int lightningEssence;
    public int wood;
    public int metal;
    public int ectoplasm;
    public int stats;
    //Which page number is it at 
    public int atPage;
    //Add more stats later 


    bool boughtSomething;

    // Use this for initialization
    void Start () {
        boughtSomething = false;
    }
	
	// Update is called once per frame
	void Update () {
	}

    public void DeductFromInventory()
    {
        //Fire enhancements
        if (type == "Fire" && !built)
        {
            if (CharacterInstance.Instance.GetInventory().getFireEssenceNumber() >= fireEssence)
            {
                //which enhancement to use
                if (buttonNum == 1)
                {
                    CharacterInstance.Instance.GetEnhancements().FirstFireEnhance(false);
                    boughtSomething = true;
                }
                else if (buttonNum == 2)
                {
                    CharacterInstance.Instance.GetEnhancements().SecondFireEnhance(false);
                    boughtSomething = true;
                }
                else if (buttonNum == 3)
                {
                    CharacterInstance.Instance.GetEnhancements().ThirdFireEnhance(false);
                    boughtSomething = true;
                }
                else if (buttonNum == 4)
                {
                    CharacterInstance.Instance.GetEnhancements().FourthFireEnhance(false);
                    boughtSomething = true;
                }
                else if (buttonNum == 5)
                {
                    CharacterInstance.Instance.GetEnhancements().FifthFireEnhance(false);
                    boughtSomething = true;
                }

                if (boughtSomething)
                {
                    //Materials used are removed from inventory
                    CharacterInstance.Instance.GetInventory().addFireEssenceNumber(-fireEssence);
                    //already built, cant build again
                    built = true;
                    boughtSomething = false;
                    transform.GetChild(0).GetComponent<Text>().text = "1";
                }
            }
        }


        //Water Enhancements
        else if (type == "Water" && !built)
        {
            if (CharacterInstance.Instance.GetInventory().getWaterEssenceNumber() >= waterEssence)
            {
                //which enhancement to use
                if (buttonNum == 1)
                {
                    CharacterInstance.Instance.GetEnhancements().FirstWaterEnhance(false);
                    boughtSomething = true;
                }
                else if (buttonNum == 2)
                {
                    CharacterInstance.Instance.GetEnhancements().SecondWaterEnhance(false);
                    boughtSomething = true;
                }
                else if (buttonNum == 3)
                {
                    CharacterInstance.Instance.GetEnhancements().ThirdWaterEnhance(false);
                    boughtSomething = true;
                }
                else if (buttonNum == 4)
                {
                    CharacterInstance.Instance.GetEnhancements().FourthWaterEnhance(false);
                    boughtSomething = true;
                }
                else if (buttonNum == 5)
                {
                    CharacterInstance.Instance.GetEnhancements().FifthWaterEnhance(false);
                    boughtSomething = true;
                }

                if (boughtSomething)
                {
                    //Materials used are removed from inventory
                    CharacterInstance.Instance.GetInventory().addWaterEssenceNumber(-waterEssence);
                    //already built, cant build again
                    built = true;
                    boughtSomething = false;
                    transform.GetChild(0).GetComponent<Text>().text = "1";
                }
            }
        }


        //Earth Enhancements
        else if (type == "Earth" && !built)
        {
            if (CharacterInstance.Instance.GetInventory().getEarthEssenceNumber() >= earthEssence)
            {
                //which enhancement to use
                if (buttonNum == 1)
                {
                    CharacterInstance.Instance.GetEnhancements().FirstEarthEnhance(false);
                    boughtSomething = true;
                }
                else if (buttonNum == 2)
                {
                    CharacterInstance.Instance.GetEnhancements().SecondEarthEnhance(false);
                    boughtSomething = true;
                }
                else if (buttonNum == 3)
                {
                    CharacterInstance.Instance.GetEnhancements().ThirdEarthEnhance(false);
                    boughtSomething = true;
                }
                else if (buttonNum == 4)
                {
                    CharacterInstance.Instance.GetEnhancements().FourthEarthEnhance(false);
                    boughtSomething = true;
                }
                else if (buttonNum == 5)
                {
                    CharacterInstance.Instance.GetEnhancements().FifthEarthEnhance(false);
                    boughtSomething = true;
                }

                if (boughtSomething)
                {
                    //Materials used are removed from inventory
                    CharacterInstance.Instance.GetInventory().addEarthEssenceNumber(-earthEssence);
                    //already built, cant build again
                    built = true;
                    boughtSomething = false;
                    transform.GetChild(0).GetComponent<Text>().text = "1";
                }
            }
        }

        //Lightning Enhancements
        else if (type == "Lightning" && !built)
        {
            if (CharacterInstance.Instance.GetInventory().getLightningEssenceNumber() >= lightningEssence)
            {
                //which enhancement to use
                if (buttonNum == 1)
                {
                    CharacterInstance.Instance.GetEnhancements().FirstLightningEnhance(false);
                    boughtSomething = true;
                }
                else if (buttonNum == 2)
                {
                    CharacterInstance.Instance.GetEnhancements().SecondLightningEnhance(false);
                    boughtSomething = true;
                }
                else if (buttonNum == 3)
                {
                    CharacterInstance.Instance.GetEnhancements().ThirdLightningEnhance(false);
                    boughtSomething = true;
                }
                else if (buttonNum == 4)
                {
                    CharacterInstance.Instance.GetEnhancements().FourthLightningEnhance(false);
                    boughtSomething = true;
                }
                else if (buttonNum == 5)
                {
                    CharacterInstance.Instance.GetEnhancements().FifthLightningEnhance(false);
                    boughtSomething = true;
                }

                if (boughtSomething)
                {
                    //Materials used are removed from inventory
                    CharacterInstance.Instance.GetInventory().addLightningEssenceNumber(-lightningEssence);
                    //already built, cant build again
                    built = true;
                    boughtSomething = false;
                    transform.GetChild(0).GetComponent<Text>().text = "1";
                }
            }
        }


        else if (type == "Tower")
        {
            if (CharacterInstance.Instance.GetInventory().getFireEssenceNumber() >= fireEssence &&
                CharacterInstance.Instance.GetInventory().getWaterEssenceNumber() >= waterEssence &&
                CharacterInstance.Instance.GetInventory().getEarthEssenceNumber() >= earthEssence &&
                CharacterInstance.Instance.GetInventory().getLightningEssenceNumber() >= lightningEssence &&
                CharacterInstance.Instance.GetInventory().getWoodMaterialNumber() >= wood &&
                CharacterInstance.Instance.GetInventory().getScrapsMaterialNumber() >= metal &&
                CharacterInstance.Instance.GetInventory().getEctoMaterialNumber() >= ectoplasm)
            {
                if (buttonNum == 1)
                {
                    CharacterInstance.Instance.GetInventory().addFireTowerNumber(1);
                    transform.GetChild(0).GetComponent<Text>().text = CharacterInstance.Instance.GetInventory().getFireTowerNumber().ToString();
                    boughtSomething = true;
                }
                else if (buttonNum == 2)
                {
                    CharacterInstance.Instance.GetInventory().addWaterTowerNumber(1);
                    transform.GetChild(0).GetComponent<Text>().text = CharacterInstance.Instance.GetInventory().getWaterTowerNumber().ToString();
                    boughtSomething = true;
                }
                else if (buttonNum == 3)
                {
                    CharacterInstance.Instance.GetInventory().addEarthTowerNumber(1);
                    transform.GetChild(0).GetComponent<Text>().text = CharacterInstance.Instance.GetInventory().getEarthTowerNumber().ToString();
                    boughtSomething = true;
                }
                else if (buttonNum == 4)
                {
                    CharacterInstance.Instance.GetInventory().addLightningTowerNumber(1);
                    transform.GetChild(0).GetComponent<Text>().text = CharacterInstance.Instance.GetInventory().getLightningTowerNumber().ToString();
                    boughtSomething = true;
                }

                if (boughtSomething)
                {
                    //Materials used are removed from inventory
                    CharacterInstance.Instance.GetInventory().addFireEssenceNumber(-fireEssence);
                    CharacterInstance.Instance.GetInventory().addWaterEssenceNumber(-waterEssence);
                    CharacterInstance.Instance.GetInventory().addEarthEssenceNumber(-earthEssence);
                    CharacterInstance.Instance.GetInventory().addLightningEssenceNumber(-lightningEssence);
                    CharacterInstance.Instance.GetInventory().addWoodMaterialNumber(-wood);
                    CharacterInstance.Instance.GetInventory().addScrapsMaterialNumber(-metal);
                    CharacterInstance.Instance.GetInventory().addEctoMaterialNumber(-ectoplasm);
                    //already built, cant build again
                    //built = true;
                    boughtSomething = false;
                    //Debug.Log(CharacterInstance.Instance.GetInventory().getFireTowerNumber());
                }
            }
        }
    }
}
