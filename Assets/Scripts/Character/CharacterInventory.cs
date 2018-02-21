using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterInventory : MonoBehaviour
{

    [SerializeField]
    Text fireText;

    [SerializeField]
    Text waterText;

    [SerializeField]
    Text earthText;

    [SerializeField]
    Text lightningText;

    [SerializeField]
    Text woodText;

    [SerializeField]
    Text scrapsText;

    [SerializeField]
    Text ectoText;

    [SerializeField]
    Text fireTowerText;

    [SerializeField]
    Text waterTowerText;

    [SerializeField]
    Text earthTowerText;

    [SerializeField]
    Text lightningTowerText;

    private int numberOfFireEssence;
    private int numberOfWaterEssence;
    private int numberOfEarthEssence;
    private int numberOfLightningEssence;
    private int numberOfWoodMaterial;
    private int numberOfScrapsMaterial;
    private int numberOfEctoMaterial;

    private int total;

    private int numberOfFireTower;
    private int numberOfWaterTower;
    private int numberOfEarthTower;
    private int numberOfLightningTower;

    // Use this for initialization
    void Start()
    {
        numberOfFireEssence = 50;
        numberOfWaterEssence = 50;
        numberOfEarthEssence = 50;
        numberOfLightningEssence = 50;
        numberOfWoodMaterial = 50;
        numberOfScrapsMaterial = 50;
        numberOfEctoMaterial = 50;
        total = 0;

        numberOfFireTower = 0;
        numberOfWaterTower = 0;
        numberOfEarthTower = 0;
        numberOfLightningTower = 0;

        setFireText();
        setWaterText();
        setEarthText();
        setLightningText();
        setWoodText();
        setScrapsText();
        setEctoText();
    }

    // Update is called once per frame
    void Update()
    {
        setFireText();
        setWaterText();
        setEarthText();
        setLightningText();
        setWoodText();
        setScrapsText();
        setEctoText();

        if (Input.GetKeyDown(KeyCode.Q))
            AddResource();
    }

    //For materials
    public int getFireEssenceNumber() { return numberOfFireEssence; }
    public int getWaterEssenceNumber() { return numberOfWaterEssence; }
    public int getEarthEssenceNumber() { return numberOfEarthEssence; }
    public int getLightningEssenceNumber() { return numberOfLightningEssence; }
    public int getWoodMaterialNumber() { return numberOfWoodMaterial; }
    public int getScrapsMaterialNumber() { return numberOfScrapsMaterial; }
    public int getEctoMaterialNumber() { return numberOfEctoMaterial; }
    public int getTotalResource() { return total; }
    public void AddResource() { addEarthEssenceNumber(1); } //if this is for testing, remember to remove

    public void addFireEssenceNumber(int amt) { numberOfFireEssence += amt; total += amt; }
    public void addWaterEssenceNumber(int amt) { numberOfWaterEssence += amt; total += amt; }
    public void addEarthEssenceNumber(int amt) { numberOfEarthEssence += amt; total += amt; }
    public void addLightningEssenceNumber(int amt) { numberOfLightningEssence += amt; total += amt; }
    public void addWoodMaterialNumber(int amt) { numberOfWoodMaterial += amt; total += amt; }
    public void addScrapsMaterialNumber(int amt) { numberOfScrapsMaterial += amt; total += amt; }
    public void addEctoMaterialNumber(int amt) { numberOfEctoMaterial += amt; total += amt; }

    public void setFireText() { fireText.text = getFireEssenceNumber().ToString(); }
    public void setWaterText() { waterText.text = getWaterEssenceNumber().ToString(); }
    public void setEarthText() { earthText.text = getEarthEssenceNumber().ToString(); }
    public void setLightningText() { lightningText.text = getLightningEssenceNumber().ToString(); }
    public void setWoodText() { woodText.text = getWoodMaterialNumber().ToString(); }
    public void setScrapsText() { scrapsText.text = getScrapsMaterialNumber().ToString(); }
    public void setEctoText() { ectoText.text = getEctoMaterialNumber().ToString(); }

    //For items
    public int getFireTowerNumber() { return numberOfFireTower; }
    public int getWaterTowerNumber() { return numberOfWaterTower; }
    public int getEarthTowerNumber() { return numberOfEarthTower; }
    public int getLightningTowerNumber() { return numberOfLightningTower; }

    public void addFireTowerNumber(int amt) { numberOfFireTower += amt; }
    public void addWaterTowerNumber(int amt) { numberOfWaterTower += amt; }
    public void addEarthTowerNumber(int amt) { numberOfEarthTower += amt; }
    public void addLightningTowerNumber(int amt) { numberOfLightningTower += amt; }

    public void setFireTowerText() { fireTowerText.text = getFireTowerNumber().ToString(); }
    public void setWaterTowerText() { waterTowerText.text = getWaterTowerNumber().ToString(); }
    public void setEarthTowerText() { earthTowerText.text = getEarthTowerNumber().ToString(); }
    public void setLightningTowerText() { lightningTowerText.text = getLightningTowerNumber().ToString(); }
}