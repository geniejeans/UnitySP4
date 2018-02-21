using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponEnhancements : MonoBehaviour {

    CharacterWeapon weapon;

    //Fire checks
    bool FirstFire;
    bool SecondFire;
    bool ThirdFire;
    bool FourthFire;
    bool FifthFire;
   // bool LastFire;

    //Water checks
    bool FirstWater;
    bool SecondWater;
    bool ThirdWater;
    bool FourthWater;
    bool FifthWater;

    //Earth checks
    bool FirstEarth;
    bool SecondEarth;
    bool ThirdEarth;
    bool FourthEarth;
    bool FifthEarth;

    //Lightning checks
    bool FirstLightning;
    bool SecondLightning;
    bool ThirdLightning;
    bool FourthLightning;
    bool FifthLightning;

    // Use this for initialization
    void Start () {
        weapon = gameObject.GetComponent<CharacterWeapon>();

        FirstFire = false;
        SecondFire = false;
        ThirdFire = false;
        FourthFire = false;
        FifthFire = false;
        //LastFire = false;

        FirstWater = false;
        SecondWater = false;
        ThirdWater = false;
        FourthWater = false;
        FifthWater = false;

        FirstEarth = false;
        SecondEarth = false;
        ThirdEarth = false;
        FourthEarth = false;
        FifthEarth = false;

        FirstLightning = false;
        SecondLightning = false;
        ThirdLightning = false;
        FourthLightning = false;
        FifthLightning = false;
    }
	
	// Update is called once per frame
	void Update () {
	}

    //when buy, call these functions

    //Fire enhancements
    public void FirstFireEnhance(bool addDamage)
    {
        if (addDamage)
        {
            weapon.AddFireDamage(2.0f);
            weapon.AddFireCrit(0.0f);
            weapon.AddFireAccuracy(0.0f);
        }

        else
            FirstFire = true;
    }
    public void SecondFireEnhance(bool addDamage)
    {
        if (addDamage)
        {
            weapon.AddFireDamage(4.0f);
            weapon.AddFireCrit(0.0f);
            weapon.AddFireAccuracy(0.0f);
        }
        else
            SecondFire = true;
    }
    public void ThirdFireEnhance(bool addDamage)
    {
        if (addDamage)
        {
            weapon.AddFireDamage(5.0f);
            weapon.AddFireCrit(0.0f);
            weapon.AddFireAccuracy(0.0f);

            weapon.AddBaseDamage(2.0f);//bonus, add base damage
            weapon.AddBaseCrit(2.0f);
            weapon.AddBaseAccuracy(0.0f);
        }
        
        else
            ThirdFire = true;
    }
    public void FourthFireEnhance(bool addDamage)
    {
        if (addDamage)
        {
            weapon.AddFireDamage(7.0f);
            weapon.AddFireCrit(2.0f);
            weapon.AddFireAccuracy(0.0f);
        }
       
        else
            FourthFire = true;
    }
    public void FifthFireEnhance(bool addDamage)
    {
        if (addDamage)
        {
            weapon.AddFireDamage(11.0f);
            weapon.AddFireCrit(0.0f);
            weapon.AddFireAccuracy(5.0f);

            weapon.AddBaseDamage(3.0f);
            weapon.AddBaseCrit(3.0f);
            weapon.AddBaseAccuracy(2.0f);
        }

        else
            FifthFire = true;
    }
    //public void LastFireEnhance()
    //{
    //    weapon.AddFireDamage(8.0f);
    //    weapon.AddFireCrit(3.0f);
    //    weapon.AddFireAccuracy(0.0f);

    //    LastFire = true;
    //}

    //Fire checks
    public bool GetFirstFire() { return FirstFire; }
    public bool GetSecondFire() { return SecondFire; }
    public bool GetThirdFire() { return ThirdFire; }
    public bool GetFourthFire() { return FourthFire; }
    public bool GetFifthFire() { return FifthFire; }
   // public bool GetLastFire() { return LastFire; }


    //Water enhancements
    public void FirstWaterEnhance(bool addDamage)
    {
        if (addDamage)
        {
            weapon.AddWaterDamage(1.0f);
            weapon.AddWaterCrit(1.0f);
            weapon.AddWaterAccuracy(0.0f);
        }
       
        else
            FirstWater = true;
    }
    public void SecondWaterEnhance(bool addDamage)
    {
        if (addDamage)
        {
            weapon.AddWaterDamage(3.0f);
            weapon.AddWaterCrit(1.0f);
            weapon.AddWaterAccuracy(2.0f);

        }
        else
            SecondWater = true;
    }
    public void ThirdWaterEnhance(bool addDamage)
    {
        if (addDamage)
        {
            weapon.AddWaterDamage(4.0f);
            weapon.AddWaterCrit(2.0f);
            weapon.AddWaterAccuracy(0.0f);

            weapon.AddBaseDamage(2.0f);//bonus, add base damage
            weapon.AddBaseCrit(2.0f);
            weapon.AddBaseAccuracy(0.0f);

        }
        else
            ThirdWater = true;
    }
    public void FourthWaterEnhance(bool addDamage)
    {
        if (addDamage)
        {
            weapon.AddWaterDamage(6.0f);
            weapon.AddWaterCrit(1.0f);
            weapon.AddWaterAccuracy(3.0f);
        }
          
        else
            FourthWater = true;
    }
    public void FifthWaterEnhance(bool addDamage)
    {
        if (addDamage)
        {
            weapon.AddWaterDamage(10.0f);
            weapon.AddWaterCrit(3.0f);
            weapon.AddWaterAccuracy(0.0f);

            weapon.AddBaseDamage(3.0f);
            weapon.AddBaseCrit(3.0f);
            weapon.AddBaseAccuracy(2.0f);
        }
    
        else
            FifthWater = true;
    }

    //Water checks
    public bool GetFirstWater() { return FirstWater; }
    public bool GetSecondWater() { return SecondWater; }
    public bool GetThirdWater() { return ThirdWater; }
    public bool GetFourthWater() { return FourthWater; }
    public bool GetFifthWater() { return FifthWater; }


    //Earth enhancements
    public void FirstEarthEnhance(bool addDamage)
    {
        if (addDamage)
        {
            weapon.AddEarthDamage(1.0f);
            weapon.AddEarthCrit(1.0f);
            weapon.AddEarthAccuracy(0.0f);
        }
          
        else
            FirstEarth = true;
    }
    public void SecondEarthEnhance(bool addDamage)
    {
        if (addDamage)
        {
            weapon.AddEarthDamage(3.0f);
            weapon.AddEarthCrit(1.0f);
            weapon.AddEarthAccuracy(2.0f);
        }
      
        else
            SecondEarth = true;
    }
    public void ThirdEarthEnhance(bool addDamage)
    {
        if (addDamage)
        {
            weapon.AddEarthDamage(4.0f);
            weapon.AddEarthCrit(2.0f);
            weapon.AddEarthAccuracy(0.0f);

            weapon.AddBaseDamage(2.0f);//bonus, add base damage
            weapon.AddBaseCrit(2.0f);
            weapon.AddBaseAccuracy(0.0f);
        }
     
        else
            ThirdEarth = true;
    }
    public void FourthEarthEnhance(bool addDamage)
    {
        if (addDamage)
        {
            weapon.AddEarthDamage(6.0f);
            weapon.AddEarthCrit(1.0f);
            weapon.AddEarthAccuracy(3.0f);
        }
    
        else
            FourthEarth = true;
    }
    public void FifthEarthEnhance(bool addDamage)
    {
        if (addDamage)
        {
            weapon.AddEarthDamage(10.0f);
            weapon.AddEarthCrit(3.0f);
            weapon.AddEarthAccuracy(0.0f);

            weapon.AddBaseDamage(3.0f);
            weapon.AddBaseCrit(3.0f);
            weapon.AddBaseAccuracy(2.0f);
        }
  
        else
            FifthEarth = true;
    }

    //Earth checks
    public bool GetFirstEarth() { return FirstEarth; }
    public bool GetSecondEarth() { return SecondEarth; }
    public bool GetThirdEarth() { return ThirdEarth; }
    public bool GetFourthEarth() { return FourthEarth; }
    public bool GetFifthEarth() { return FifthEarth; }


    //Lightning enhancements
    public void FirstLightningEnhance(bool addDamage)
    {
        if (addDamage)
        {
            weapon.AddLightningDamage(1.0f);
            weapon.AddLightningCrit(1.0f);
            weapon.AddLightningAccuracy(0.0f);
        }
        else
            FirstLightning = true;
    }
    public void SecondLightningEnhance(bool addDamage)
    {
        if (addDamage)
        {
            weapon.AddLightningDamage(3.0f);
            weapon.AddLightningCrit(1.0f);
            weapon.AddLightningAccuracy(2.0f);
        }
        
        else
            SecondLightning = true;
    }
    public void ThirdLightningEnhance(bool addDamage)
    {
        if (addDamage)
        {
            weapon.AddLightningDamage(4.0f);
            weapon.AddLightningCrit(2.0f);
            weapon.AddLightningAccuracy(0.0f);

            weapon.AddBaseDamage(2.0f);//bonus, add base damage
            weapon.AddBaseCrit(2.0f);
            weapon.AddBaseAccuracy(0.0f);
        }
         
        else
            ThirdLightning = true;
    }
    public void FourthLightningEnhance(bool addDamage)
    {
        if (addDamage)
        {
            weapon.AddLightningDamage(6.0f);
            weapon.AddLightningCrit(1.0f);
            weapon.AddLightningAccuracy(3.0f);
        }

        else
            FourthLightning = true;
    }
    public void FifthLightningEnhance(bool addDamage)
    {
        if (addDamage)
        {
            weapon.AddLightningDamage(10.0f);
            weapon.AddLightningCrit(3.0f);
            weapon.AddLightningAccuracy(0.0f);

            weapon.AddBaseDamage(3.0f);
            weapon.AddBaseCrit(3.0f);
            weapon.AddBaseAccuracy(2.0f);
        }
          
        else
            FifthLightning = true;
    }

    //Lightning checks
    public bool GetFirstLightning() { return FirstLightning; }
    public bool GetSecondLightning() { return SecondLightning; }
    public bool GetThirdLightning() { return ThirdLightning; }
    public bool GetFourthLightning() { return FourthLightning; }
    public bool GetFifthLightning() { return FifthLightning; }
}
