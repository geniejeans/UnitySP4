using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    Transform canvas;

    [SerializeField]
    Transform fireEnhancements;

    [SerializeField]
    Transform waterEnhancements;

    [SerializeField]
    Transform earthEnhancements;

    [SerializeField]
    Transform lightningEnhancements;

    [SerializeField]
    Transform fireSlot1;
    [SerializeField]
    Transform fireSlot2;
    [SerializeField]
    Transform fireSlot3;
    [SerializeField]
    Transform fireSlot4;
    [SerializeField]
    Transform fireSlot5;

    [SerializeField]
    Transform waterSlot1;
    [SerializeField]
    Transform waterSlot2;
    [SerializeField]
    Transform waterSlot3;
    [SerializeField]
    Transform waterSlot4;
    [SerializeField]
    Transform waterSlot5;

    [SerializeField]
    Transform earthSlot1;
    [SerializeField]
    Transform earthSlot2;
    [SerializeField]
    Transform earthSlot3;
    [SerializeField]
    Transform earthSlot4;
    [SerializeField]
    Transform earthSlot5;

    [SerializeField]
    Transform lightningSlot1;
    [SerializeField]
    Transform lightningSlot2;
    [SerializeField]
    Transform lightningSlot3;
    [SerializeField]
    Transform lightningSlot4;
    [SerializeField]
    Transform lightningSlot5;

    WeaponEnhancements enhance;

    // Use this for initialization
    void Start ()
    {
        enhance = CharacterInstance.Instance.GetEnhancements();

        canvas.gameObject.SetActive(false);
        fireEnhancements.gameObject.SetActive(false);
        waterEnhancements.gameObject.SetActive(false);
        earthEnhancements.gameObject.SetActive(false);
        lightningEnhancements.gameObject.SetActive(false);

        fireSlot1.gameObject.SetActive(false);
        fireSlot2.gameObject.SetActive(false);
        fireSlot3.gameObject.SetActive(false);
        fireSlot4.gameObject.SetActive(false);
        fireSlot5.gameObject.SetActive(false);

        waterSlot1.gameObject.SetActive(false);
        waterSlot2.gameObject.SetActive(false);
        waterSlot3.gameObject.SetActive(false);
        waterSlot4.gameObject.SetActive(false);
        waterSlot5.gameObject.SetActive(false);

        earthSlot1.gameObject.SetActive(false);
        earthSlot2.gameObject.SetActive(false);
        earthSlot3.gameObject.SetActive(false);
        earthSlot4.gameObject.SetActive(false);
        earthSlot5.gameObject.SetActive(false);

        lightningSlot1.gameObject.SetActive(false);
        lightningSlot2.gameObject.SetActive(false);
        lightningSlot3.gameObject.SetActive(false);
        lightningSlot4.gameObject.SetActive(false);
        lightningSlot5.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }
	
	public void WeaponMenu()
    {
        if (canvas.gameObject.activeInHierarchy == false)
        {
            canvas.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            canvas.gameObject.SetActive(false);
            Time.timeScale = 1;

            fireEnhancements.gameObject.SetActive(false);
            waterEnhancements.gameObject.SetActive(false);
            earthEnhancements.gameObject.SetActive(false);
            lightningEnhancements.gameObject.SetActive(false);

            fireSlot1.gameObject.SetActive(false);
            fireSlot2.gameObject.SetActive(false);
            fireSlot3.gameObject.SetActive(false);
            fireSlot4.gameObject.SetActive(false);
            fireSlot5.gameObject.SetActive(false);

            waterSlot1.gameObject.SetActive(false);
            waterSlot2.gameObject.SetActive(false);
            waterSlot3.gameObject.SetActive(false);
            waterSlot4.gameObject.SetActive(false);
            waterSlot5.gameObject.SetActive(false);

            earthSlot1.gameObject.SetActive(false);
            earthSlot2.gameObject.SetActive(false);
            earthSlot3.gameObject.SetActive(false);
            earthSlot4.gameObject.SetActive(false);
            earthSlot5.gameObject.SetActive(false);

            lightningSlot1.gameObject.SetActive(false);
            lightningSlot2.gameObject.SetActive(false);
            lightningSlot3.gameObject.SetActive(false);
            lightningSlot4.gameObject.SetActive(false);
            lightningSlot5.gameObject.SetActive(false);
        }
    }

    public void FireEnhancements()
    {
        if (fireEnhancements.gameObject.activeInHierarchy == false)
        {
            fireEnhancements.gameObject.SetActive(true);

            // Cross
            if (enhance.GetFirstFire() == true)
                fireSlot1.gameObject.SetActive(false);
            else
                fireSlot1.gameObject.SetActive(true);
            
            if (enhance.GetSecondFire() == true)
                fireSlot2.gameObject.SetActive(false);
            else
                fireSlot2.gameObject.SetActive(true);

            if (enhance.GetThirdFire() == true)
                fireSlot3.gameObject.SetActive(false);
            else
                fireSlot3.gameObject.SetActive(true);

            if (enhance.GetFourthFire() == true)
                fireSlot4.gameObject.SetActive(false);
            else
                fireSlot4.gameObject.SetActive(true);

            if (enhance.GetFifthFire() == true)
                fireSlot5.gameObject.SetActive(false);
            else
                fireSlot5.gameObject.SetActive(true);
        }
        else
        {
            fireEnhancements.gameObject.SetActive(false);
            fireSlot1.gameObject.SetActive(false);
            fireSlot2.gameObject.SetActive(false);
            fireSlot3.gameObject.SetActive(false);
            fireSlot4.gameObject.SetActive(false);
            fireSlot5.gameObject.SetActive(false);
        }
    }

    public void WaterEnhancements()
    {
        if (waterEnhancements.gameObject.activeInHierarchy == false)
        {
            waterEnhancements.gameObject.SetActive(true);

            // Cross
            if (enhance.GetFirstWater() == true)
                waterSlot1.gameObject.SetActive(false);
            else
                waterSlot1.gameObject.SetActive(true);

            if (enhance.GetSecondWater() == true)
                waterSlot2.gameObject.SetActive(false);
            else
                waterSlot2.gameObject.SetActive(true);

            if (enhance.GetThirdWater() == true)
                waterSlot3.gameObject.SetActive(false);
            else
                waterSlot3.gameObject.SetActive(true);

            if (enhance.GetFourthWater() == true)
                waterSlot4.gameObject.SetActive(false);
            else
                waterSlot4.gameObject.SetActive(true);

            if (enhance.GetFifthWater() == true)
                waterSlot5.gameObject.SetActive(false);
            else
                waterSlot5.gameObject.SetActive(true);
        }
        else
        {
            waterEnhancements.gameObject.SetActive(false);
            waterSlot1.gameObject.SetActive(false);
            waterSlot2.gameObject.SetActive(false);
            waterSlot3.gameObject.SetActive(false);
            waterSlot4.gameObject.SetActive(false);
            waterSlot5.gameObject.SetActive(false);
        }
    }

    public void EarthEnhancements()
    {
        if (earthEnhancements.gameObject.activeInHierarchy == false)
        {
            earthEnhancements.gameObject.SetActive(true);

            // Cross
            if (enhance.GetFirstEarth() == true)
                earthSlot1.gameObject.SetActive(false);
            else
                earthSlot1.gameObject.SetActive(true);

            if (enhance.GetSecondEarth() == true)
                earthSlot2.gameObject.SetActive(false);
            else
                earthSlot2.gameObject.SetActive(true);

            if (enhance.GetThirdEarth() == true)
                earthSlot3.gameObject.SetActive(false);
            else
                earthSlot3.gameObject.SetActive(true);

            if (enhance.GetFourthEarth() == true)
                earthSlot4.gameObject.SetActive(false);
            else
                earthSlot4.gameObject.SetActive(true);

            if (enhance.GetFifthEarth() == true)
                earthSlot5.gameObject.SetActive(false);
            else
                earthSlot5.gameObject.SetActive(true);
        }
        else
        {
            earthEnhancements.gameObject.SetActive(false);
            earthSlot1.gameObject.SetActive(false);
            earthSlot2.gameObject.SetActive(false);
            earthSlot3.gameObject.SetActive(false);
            earthSlot4.gameObject.SetActive(false);
            earthSlot5.gameObject.SetActive(false);
        }
    }

    public void LightningEnhancements()
    {
        if (lightningEnhancements.gameObject.activeInHierarchy == false)
        {
            lightningEnhancements.gameObject.SetActive(true);

            // Cross
            if (enhance.GetFirstLightning() == true)
                lightningSlot1.gameObject.SetActive(false);
            else
                lightningSlot1.gameObject.SetActive(true);

            if (enhance.GetSecondLightning() == true)
                lightningSlot2.gameObject.SetActive(false);
            else
                lightningSlot2.gameObject.SetActive(true);

            if (enhance.GetThirdLightning() == true)
                lightningSlot3.gameObject.SetActive(false);
            else
                lightningSlot3.gameObject.SetActive(true);

            if (enhance.GetFourthLightning() == true)
                lightningSlot4.gameObject.SetActive(false);
            else
                lightningSlot4.gameObject.SetActive(true);

            if (enhance.GetFifthLightning() == true)
                lightningSlot5.gameObject.SetActive(false);
            else
                lightningSlot5.gameObject.SetActive(true);
        }
        else
        {
            lightningEnhancements.gameObject.SetActive(false);
            lightningSlot1.gameObject.SetActive(false);
            lightningSlot2.gameObject.SetActive(false);
            lightningSlot3.gameObject.SetActive(false);
            lightningSlot4.gameObject.SetActive(false);
            lightningSlot5.gameObject.SetActive(false);
        }
    }
}
