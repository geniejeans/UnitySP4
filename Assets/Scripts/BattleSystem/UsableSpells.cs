using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsableSpells : MonoBehaviour
{

    [SerializeField]
    GameObject slotsPanel; 


	// Use this for initialization
	void Start ()
    {
	}
	void OnEnable()
    {
        CharacterInstance.Instance.GetWeapon().deactivateAllElements();
        CharacterInstance.Instance.GetWeapon().resetAllDamages();

        //Iterating through the whole weapon slots
        for (int i = 0; i < slotsPanel.transform.childCount; ++i)
        {
            //Resetting the spells button slots 
            transform.GetChild(i).gameObject.SetActive(false);
            //This is the slotsPanel(parent)
            if (slotsPanel.transform.GetChild(i).childCount > 0)
            {
                //These there are the children for weapon slot(FirstSlotPanel, SecondSlotPanel, ThirdSlotPanel, FourthSlotPanel)
                switch (slotsPanel.transform.GetChild(i).GetChild(0).GetComponent<CraftItem>().type)
                {
                    case "Fire":
                        CharacterInstance.Instance.GetWeapon().ActivateFire();
                        transform.GetChild(0).gameObject.SetActive(true);
                        AddFire(slotsPanel.transform.GetChild(i).GetChild(0).GetComponent<CraftItem>().stats);
                        break;
                    case "Water":
                        CharacterInstance.Instance.GetWeapon().ActivateWater();
                        transform.GetChild(1).gameObject.SetActive(true);
                        AddWater(slotsPanel.transform.GetChild(i).GetChild(0).GetComponent<CraftItem>().stats);
                        break;
                    case "Earth":
                        CharacterInstance.Instance.GetWeapon().ActivateEarth();
                        transform.GetChild(2).gameObject.SetActive(true);
                        AddEarth(slotsPanel.transform.GetChild(i).GetChild(0).GetComponent<CraftItem>().stats);
                        break;
                    case "Lightning":
                        Debug.Log("hello");
                        CharacterInstance.Instance.GetWeapon().ActivateLightning();
                        transform.GetChild(3).gameObject.SetActive(true);
                        AddLightning(slotsPanel.transform.GetChild(i).GetChild(0).GetComponent<CraftItem>().stats);
                        break;
                }
            }
        }
        Debug.Log("BaseDmg: " + CharacterInstance.Instance.GetWeapon().GetBaseDamage() +
                "\n FireDmg: " + CharacterInstance.Instance.GetWeapon().GetFireDamage() +
                 "\n WaterDmg: " + CharacterInstance.Instance.GetWeapon().GetWaterDamage() +
                  "\n EarthDmg: " + CharacterInstance.Instance.GetWeapon().GetEarthDamage() +
                   "\n LightningDmg: " + CharacterInstance.Instance.GetWeapon().GetLightningDamage() +
                     "\n LightningCrit: " + CharacterInstance.Instance.GetWeapon().GetLightningCrit());
    }
    // Update is called once per frame
    void Update()
    {
    }

    void AddFire(int stats)
    {
        switch (stats)
        {
            case 1:
                CharacterInstance.Instance.GetEnhancements().FirstFireEnhance(true);
                break;
            case 2:
                CharacterInstance.Instance.GetEnhancements().SecondFireEnhance(true);
                break;
            case 3:
                CharacterInstance.Instance.GetEnhancements().ThirdFireEnhance(true);
                break;
            case 4:
                CharacterInstance.Instance.GetEnhancements().FourthFireEnhance(true);
                break;
            case 5:
                CharacterInstance.Instance.GetEnhancements().FifthFireEnhance(true);
                break;
        }
    }

    void AddWater(int stats)
    {
        switch (stats)
        {
            case 1:
                CharacterInstance.Instance.GetEnhancements().FirstWaterEnhance(true);
                break;
            case 2:
                CharacterInstance.Instance.GetEnhancements().SecondWaterEnhance(true);
                break;
            case 3:
                CharacterInstance.Instance.GetEnhancements().ThirdWaterEnhance(true);
                break;
            case 4:
                CharacterInstance.Instance.GetEnhancements().FourthWaterEnhance(true);
                break;
            case 5:
                CharacterInstance.Instance.GetEnhancements().FifthWaterEnhance(true);
                break;
        }
    }

    void AddEarth(int stats)
    {
        switch (stats)
        {
            case 1:
                CharacterInstance.Instance.GetEnhancements().FirstEarthEnhance(true);
                break;
            case 2:
                CharacterInstance.Instance.GetEnhancements().SecondEarthEnhance(true);
                break;
            case 3:
                CharacterInstance.Instance.GetEnhancements().ThirdEarthEnhance(true);
                break;
            case 4:
                CharacterInstance.Instance.GetEnhancements().FourthEarthEnhance(true);
                break;
            case 5:
                CharacterInstance.Instance.GetEnhancements().FifthEarthEnhance(true);
                break;
        }
    }

    void AddLightning(int stats)
    {
        switch (stats)
        {
            case 1:
                CharacterInstance.Instance.GetEnhancements().FirstLightningEnhance(true);
                break;
            case 2:
                CharacterInstance.Instance.GetEnhancements().SecondLightningEnhance(true);
                break;
            case 3:
                CharacterInstance.Instance.GetEnhancements().ThirdLightningEnhance(true);
                break;
            case 4:
                CharacterInstance.Instance.GetEnhancements().FourthLightningEnhance(true);
                break;
            case 5:
                CharacterInstance.Instance.GetEnhancements().FifthLightningEnhance(true);
                break;
        }
    }
}
