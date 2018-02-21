using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideMenu : MonoBehaviour {

    [SerializeField]
    Transform FireMenu;

    [SerializeField]
    Transform WaterMenu;

    [SerializeField]
    Transform EarthMenu;

    [SerializeField]
    Transform LightningMenu;

    [SerializeField]
    Transform TowerMenu;

    [SerializeField]
    Transform TowerTitle;

    [SerializeField]
    Transform TowerConfirm;

    // Use this for initialization
    void Start ()
    {
        FireMenu.gameObject.SetActive(false);
        WaterMenu.gameObject.SetActive(false);
        EarthMenu.gameObject.SetActive(false);
        LightningMenu.gameObject.SetActive(false);
        TowerMenu.gameObject.SetActive(false);
        TowerTitle.gameObject.SetActive(false);
        TowerConfirm.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OpenFireMenu()
    {
        if (FireMenu.gameObject.activeInHierarchy == false)
        {
            FireMenu.gameObject.SetActive(true);

            WaterMenu.gameObject.SetActive(false);
            EarthMenu.gameObject.SetActive(false);
            LightningMenu.gameObject.SetActive(false);
            TowerMenu.gameObject.SetActive(false);
            TowerTitle.gameObject.SetActive(false);
            TowerConfirm.gameObject.SetActive(false);
        }
        else
        {
            FireMenu.gameObject.SetActive(false);
        }
    }

    public void OpenWaterMenu()
    {
        if (WaterMenu.gameObject.activeInHierarchy == false)
        {
            WaterMenu.gameObject.SetActive(true);

            FireMenu.gameObject.SetActive(false);
            EarthMenu.gameObject.SetActive(false);
            LightningMenu.gameObject.SetActive(false);
            TowerMenu.gameObject.SetActive(false);
            TowerTitle.gameObject.SetActive(false);
            TowerConfirm.gameObject.SetActive(false);
        }
        else
        {
            WaterMenu.gameObject.SetActive(false);
        }
    }

    public void OpenEarthMenu()
    {
        if (EarthMenu.gameObject.activeInHierarchy == false)
        {
            EarthMenu.gameObject.SetActive(true);

            FireMenu.gameObject.SetActive(false);
            WaterMenu.gameObject.SetActive(false);
            LightningMenu.gameObject.SetActive(false);
            TowerMenu.gameObject.SetActive(false);
            TowerTitle.gameObject.SetActive(false);
            TowerConfirm.gameObject.SetActive(false);
        }
        else
        {
            EarthMenu.gameObject.SetActive(false);
        }
    }

    public void OpenLightningMenu()
    {
        if (LightningMenu.gameObject.activeInHierarchy == false)
        {
            LightningMenu.gameObject.SetActive(true);

            FireMenu.gameObject.SetActive(false);
            WaterMenu.gameObject.SetActive(false);
            EarthMenu.gameObject.SetActive(false);
            TowerMenu.gameObject.SetActive(false);
            TowerTitle.gameObject.SetActive(false);
            TowerConfirm.gameObject.SetActive(false);
        }
        else
        {
            LightningMenu.gameObject.SetActive(false);
        }
    }

    public void OpenTowerMenu()
    {
        if (TowerMenu.gameObject.activeInHierarchy == false)
        {
            TowerMenu.gameObject.SetActive(true);
            TowerTitle.gameObject.SetActive(true);

            FireMenu.gameObject.SetActive(false);
            WaterMenu.gameObject.SetActive(false);
            EarthMenu.gameObject.SetActive(false);
            LightningMenu.gameObject.SetActive(false);
            TowerConfirm.gameObject.SetActive(false);
        }
        else
        {
            TowerMenu.gameObject.SetActive(false);
            TowerTitle.gameObject.SetActive(false);
        }
    }

    public void OpenTowerConfirm()
    {
        if (TowerConfirm.gameObject.activeInHierarchy == false)
        {
            TowerConfirm.gameObject.SetActive(true);

            FireMenu.gameObject.SetActive(false);
            WaterMenu.gameObject.SetActive(false);
            EarthMenu.gameObject.SetActive(false);
            LightningMenu.gameObject.SetActive(false);
        }
        else
        {
            TowerConfirm.gameObject.SetActive(false);
        }
    }
}
