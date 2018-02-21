using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterWeapon : MonoBehaviour
{
    float baseDamage;
    float baseCrit;
    float baseAccuracy;

    bool fireElement;
    bool waterElement;
    bool earthElement;
    bool lightningElement;

    float fireDamage;
    float fireCrit;
    float fireAccuracy;

    float waterDamage;
    float waterCrit;
    float waterAccuracy;

    float earthDamage;
    float earthCrit;
    float earthAccuracy;

    float lightningDamage;
    float lightningCrit;
    float lightningAccuracy;

    // Use this for initialization
    void Start()
    {
        fireElement = false;
        waterElement = false;
        earthElement = false;
        lightningElement = false;

        //base
        baseDamage = 2.0f;
        baseCrit = 15.0f; // counted in percentage
        baseAccuracy = 85.0f; // counted in percentage

        //fire
        fireDamage = 3.0f;
        fireCrit = 0.0f; // counted in percentage
        fireAccuracy = 0.0f; // counted in percentage

        //water
        waterDamage = 2.0f;
        waterCrit = 0.0f; // counted in percentage
        waterAccuracy = 0.0f; // counted in percentage

        //earth
        earthDamage = 2.0f;
        earthCrit = 0.0f; // counted in percentage
        earthAccuracy = 0.0f; // counted in percentage

        //lightning
        lightningDamage = 2.0f;
        lightningCrit = 10.0f; // counted in percentage
        lightningAccuracy = 0.0f; // counted in percentage
    }

    // Update is called once per frame
    void Update()
    {

    }

    //update / improve base stats
    public void AddBaseDamage(float amt) { baseDamage += amt; }
    public float GetBaseDamage() { return baseDamage; }
    public void AddBaseCrit(float amt) { baseCrit += amt; }
    public float GetBaseCrit() { return baseCrit; }
    public void AddBaseAccuracy(float amt) { baseAccuracy += amt; }
    public float GetBaseAccuracy() { return baseAccuracy; }

    //update / improve fire stats
    public void AddFireDamage(float amt) { fireDamage += amt; }
    public float GetFireDamage() { return fireDamage; }
    public void AddFireCrit(float amt) { fireCrit += amt; }
    public float GetFireCrit() { return fireCrit; }
    public void AddFireAccuracy(float amt) { fireAccuracy += amt; }
    public float GetFireAccuracy() { return fireAccuracy; }

    //update / improve water stats
    public void AddWaterDamage(float amt) { waterDamage += amt; }
    public float GetWaterDamage() { return waterDamage; }
    public void AddWaterCrit(float amt) { waterCrit += amt; }
    public float GetWaterCrit() { return waterCrit; }
    public void AddWaterAccuracy(float amt) { waterAccuracy += amt; }
    public float GetWaterAccuracy() { return waterAccuracy; }

    //update / improve earth stats
    public void AddEarthDamage(float amt) { earthDamage += amt; }
    public float GetEarthDamage() { return earthDamage; }
    public void AddEarthCrit(float amt) { earthCrit += amt; }
    public float GetEarthCrit() { return earthCrit; }
    public void AddEarthAccuracy(float amt) { earthAccuracy += amt; }
    public float GetEarthAccuracy() { return earthAccuracy; }

    //update / improve lightning stats
    public void AddLightningDamage(float amt) { lightningDamage += amt; }
    public float GetLightningDamage() { return lightningDamage; }
    public void AddLightningCrit(float amt) { lightningCrit += amt; }
    public float GetLightningCrit() { return lightningCrit; }
    public void AddLightningAccuracy(float amt) { lightningAccuracy += amt; }
    public float GetLightningAccuracy() { return lightningAccuracy; }

    //Check if the specific element is active
    public bool FireActive() { return fireElement; }
    public bool WaterActive() { return waterElement; }
    public bool EarthActive() { return earthElement; }
    public bool LightningActive() { return lightningElement; }

    //deactivate all elements
    public void deactivateAllElements()
    {
        fireElement = false;
        waterElement = false;
        earthElement = false;
        lightningElement = false;
    }

    //Reset all damages
    public void resetAllDamages()
    {
        //base
        baseDamage = 2.0f;
        baseCrit = 15.0f; // counted in percentage
        baseAccuracy = 85.0f; // counted in percentage

        //fire
        fireDamage = 3.0f;
        fireCrit = 0.0f; // counted in percentage
        fireAccuracy = 0.0f; // counted in percentage

        //water
        waterDamage = 2.0f;
        waterCrit = 0.0f; // counted in percentage
        waterAccuracy = 0.0f; // counted in percentage

        //earth
        earthDamage = 2.0f;
        earthCrit = 0.0f; // counted in percentage
        earthAccuracy = 0.0f; // counted in percentage

        //lightning
        lightningDamage = 2.0f;
        lightningCrit = 10.0f; // counted in percentage
        lightningAccuracy = 0.0f; // counted in percentage
    }

    //activate individual elements
    public void ActivateFire() { fireElement = true; }
    public void ActivateWater() { waterElement = true; }
    public void ActivateEarth() { earthElement = true; }
    public void ActivateLightning() { lightningElement = true; }
}
