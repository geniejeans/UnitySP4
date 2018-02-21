using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropsScript : MonoBehaviour {

    void Start(){

    }
    void Update(){

    }
    public void OnCollisionEnter(Collision other)
    {
        CharacterInventory inventory = other.gameObject.GetComponent<CharacterInventory>();

        if (other.gameObject.name == "Character")
        {
            // Set fire essence text
            if (gameObject.tag == "FireEssence")
            {
                inventory.addFireEssenceNumber(1);
            }
            // Set water essence text
            else if (gameObject.tag == "WaterEssence")
            {
                inventory.addWaterEssenceNumber(1);
            }
            // Set earth essence text
            else if (gameObject.tag == "EarthEssence")
            {
                inventory.addEarthEssenceNumber(1);
               // SetEarthEssenceText();
            }
            // Set lightning essence text
            else if (gameObject.tag == "LightningEssence")
            {
                inventory.addLightningEssenceNumber(1);
               // SetLightningEssenceText();
            }
            // Set wood material text
            else if (gameObject.tag == "WoodMaterial")
            {
                inventory.addWoodMaterialNumber(1);
               // SetWoodMaterialText();
            }
            // Set scraps material text
            else if (gameObject.tag == "ScrapsMaterial")
            {
                inventory.addScrapsMaterialNumber(1);
                //SetScrapsMaterialText();
            }
            // Set ectoplasm material text
            else if (gameObject.tag == "EctoMaterial")
            {
                inventory.addEctoMaterialNumber(1);
            }

            Destroy(gameObject);
        }
    }
}
