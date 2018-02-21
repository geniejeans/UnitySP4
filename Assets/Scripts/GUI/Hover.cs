using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Hover : MonoBehaviour,  IPointerEnterHandler, IPointerExitHandler{

    Image find1_FIRE;
    Image find2_FIRE;
    Image find3_FIRE;
    Image find4_FIRE;

    Image find1_WATER;
    Image find2_WATER;
    Image find3_WATER;
    Image find4_WATER;

    Image find1_EARTH;
    Image find2_EARTH;
    Image find3_EARTH;
    Image find4_EARTH;

    Image find1_LIGHTNING;
    Image find2_LIGHTNING;
    Image find3_LIGHTNING;
    Image find4_LIGHTNING;

    Image find1_TOWER;
    Image find2_TOWER;
    Image find3_TOWER;
    Image find4_TOWER;

    // Use this for initialization
    void Start ()
    {
        // Fire Menu
        if (transform.parent.parent.name == "FireMenu")
        {
            if (gameObject.name == "SLOT_1_1")
            {
                find1_FIRE = GameObject.Find("FireHover1").GetComponent<Image>();
                find1_FIRE.gameObject.SetActive(false);
            }
            else if (gameObject.name == "SLOT_1_2")
            {
                find2_FIRE = GameObject.Find("FireHover2").GetComponent<Image>();
                find2_FIRE.gameObject.SetActive(false);
            }
            else if (gameObject.name == "SLOT_1_3")
            {
                find3_FIRE = GameObject.Find("FireHover3").GetComponent<Image>();
                find3_FIRE.gameObject.SetActive(false);
            }
            else if (gameObject.name == "SLOT_1_4")
            {
                find4_FIRE = GameObject.Find("FireHover4").GetComponent<Image>();
                find4_FIRE.gameObject.SetActive(false);
            }
        }

        // Water Menu
        else if (transform.parent.parent.name == "WaterMenu")
        {
            if (gameObject.name == "SLOT_1_1")
            {
                find1_WATER = GameObject.Find("WaterHover1").GetComponent<Image>();
                find1_WATER.gameObject.SetActive(false);
            }
            else if (gameObject.name == "SLOT_1_2")
            {
                find2_WATER = GameObject.Find("WaterHover2").GetComponent<Image>();
                find2_WATER.gameObject.SetActive(false);
            }
            else if (gameObject.name == "SLOT_1_3")
            {
                find3_WATER = GameObject.Find("WaterHover3").GetComponent<Image>();
                find3_WATER.gameObject.SetActive(false);
            }
            else if (gameObject.name == "SLOT_1_4")
            {
                find4_WATER = GameObject.Find("WaterHover4").GetComponent<Image>();
                find4_WATER.gameObject.SetActive(false);
            }
        }

        // Earth Menu
        else if (transform.parent.parent.name == "EarthMenu")
        {
            if (gameObject.name == "SLOT_1_1")
            {
                find1_EARTH = GameObject.Find("EarthHover1").GetComponent<Image>();
                find1_EARTH.gameObject.SetActive(false);
            }
            else if (gameObject.name == "SLOT_1_2")
            {
                find2_EARTH = GameObject.Find("EarthHover2").GetComponent<Image>();
                find2_EARTH.gameObject.SetActive(false);
            }
            else if (gameObject.name == "SLOT_1_3")
            {
                find3_EARTH = GameObject.Find("EarthHover3").GetComponent<Image>();
                find3_EARTH.gameObject.SetActive(false);
            }
            else if (gameObject.name == "SLOT_1_4")
            {
                find4_EARTH = GameObject.Find("EarthHover4").GetComponent<Image>();
                find4_EARTH.gameObject.SetActive(false);
            }
        }

        // Lightning Menu
        else if (transform.parent.parent.name == "LightningMenu")
        {
            if (gameObject.name == "SLOT_1_1")
            {
                find1_LIGHTNING = GameObject.Find("LightningHover1").GetComponent<Image>();
                find1_LIGHTNING.gameObject.SetActive(false);
            }
            else if (gameObject.name == "SLOT_1_2")
            {
                find2_LIGHTNING = GameObject.Find("LightningHover2").GetComponent<Image>();
                find2_LIGHTNING.gameObject.SetActive(false);
            }
            else if (gameObject.name == "SLOT_1_3")
            {
                find3_LIGHTNING = GameObject.Find("LightningHover3").GetComponent<Image>();
                find3_LIGHTNING.gameObject.SetActive(false);
            }
            else if (gameObject.name == "SLOT_1_4")
            {
                find4_LIGHTNING = GameObject.Find("LightningHover4").GetComponent<Image>();
                find4_LIGHTNING.gameObject.SetActive(false);
            }
        }

        // Tower Menu
        else if (transform.parent.parent.name == "TowerMenu")
        {
            if (gameObject.name == "SLOT_1_1")
            {
                find1_TOWER = GameObject.Find("TowerHover1").GetComponent<Image>();
                find1_TOWER.gameObject.SetActive(false);
            }
            else if (gameObject.name == "SLOT_1_2")
            {
                find2_TOWER = GameObject.Find("TowerHover2").GetComponent<Image>();
                find2_TOWER.gameObject.SetActive(false);
            }
            else if (gameObject.name == "SLOT_1_3")
            {
                find3_TOWER = GameObject.Find("TowerHover3").GetComponent<Image>();
                find3_TOWER.gameObject.SetActive(false);
            }
            else if (gameObject.name == "SLOT_1_4")
            {
                find4_TOWER = GameObject.Find("TowerHover4").GetComponent<Image>();
                find4_TOWER.gameObject.SetActive(false);
            }
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
	}

    #region IPointerEnterHandler implementation
    public void OnPointerEnter(PointerEventData eventData)
    {
        // Fire Menu
        if (transform.parent.parent.name == "FireMenu")
        {
            if (gameObject.name == "SLOT_1_1" &&
                (gameObject.transform.GetChild(0).GetComponent<Image>().enabled || gameObject.transform.GetChild(1).GetComponent<Image>().enabled))
            {
                find1_FIRE.gameObject.SetActive(true);
                find1_FIRE.GetComponent<RectTransform>().anchoredPosition = gameObject.GetComponent<RectTransform>().anchoredPosition + new Vector2(60, 21);
            }
            else if (gameObject.name == "SLOT_1_2" &&
                gameObject.transform.GetChild(0).GetComponent<Image>().enabled)
            {
                find2_FIRE.gameObject.SetActive(true);
                find2_FIRE.GetComponent<RectTransform>().anchoredPosition = gameObject.GetComponent<RectTransform>().anchoredPosition + new Vector2(60, 20);
            }
            else if (gameObject.name == "SLOT_1_3" &&
                gameObject.transform.GetChild(0).GetComponent<Image>().enabled)
            {
                find3_FIRE.gameObject.SetActive(true);
                find3_FIRE.GetComponent<RectTransform>().anchoredPosition = gameObject.GetComponent<RectTransform>().anchoredPosition + new Vector2(60, 18);
            }
            else if (gameObject.name == "SLOT_1_4" &&
                gameObject.transform.GetChild(0).GetComponent<Image>().enabled)
            {
                find4_FIRE.gameObject.SetActive(true);
                find4_FIRE.GetComponent<RectTransform>().anchoredPosition = gameObject.GetComponent<RectTransform>().anchoredPosition + new Vector2(60, 18);
            }
        }

        // Water Menu
        else if (transform.parent.parent.name == "WaterMenu")
        {
            if (gameObject.name == "SLOT_1_1" &&
                (gameObject.transform.GetChild(0).GetComponent<Image>().enabled || gameObject.transform.GetChild(1).GetComponent<Image>().enabled))
            {
                find1_WATER.gameObject.SetActive(true);
                find1_WATER.GetComponent<RectTransform>().anchoredPosition = gameObject.GetComponent<RectTransform>().anchoredPosition + new Vector2(100, -5);
            }
            else if (gameObject.name == "SLOT_1_2" &&
                gameObject.transform.GetChild(0).GetComponent<Image>().enabled)
            {
                find2_WATER.gameObject.SetActive(true);
                find2_WATER.GetComponent<RectTransform>().anchoredPosition = gameObject.GetComponent<RectTransform>().anchoredPosition + new Vector2(100, -20);
            }
            else if (gameObject.name == "SLOT_1_3" &&
                gameObject.transform.GetChild(0).GetComponent<Image>().enabled)
            {
                find3_WATER.gameObject.SetActive(true);
                find3_WATER.GetComponent<RectTransform>().anchoredPosition = gameObject.GetComponent<RectTransform>().anchoredPosition + new Vector2(100, -35);
            }
            else if (gameObject.name == "SLOT_1_4" &&
                gameObject.transform.GetChild(0).GetComponent<Image>().enabled)
            {
                find4_WATER.gameObject.SetActive(true);
                find4_WATER.GetComponent<RectTransform>().anchoredPosition = gameObject.GetComponent<RectTransform>().anchoredPosition + new Vector2(100, -50);
            }
        }

        // Earth Menu
        else if (transform.parent.parent.name == "EarthMenu")
        {
            if (gameObject.name == "SLOT_1_1" &&
                (gameObject.transform.GetChild(0).GetComponent<Image>().enabled || gameObject.transform.GetChild(1).GetComponent<Image>().enabled))
            {
                find1_EARTH.gameObject.SetActive(true);
                find1_EARTH.GetComponent<RectTransform>().anchoredPosition = gameObject.GetComponent<RectTransform>().anchoredPosition + new Vector2(100, 15);
            }
            else if (gameObject.name == "SLOT_1_2" &&
                gameObject.transform.GetChild(0).GetComponent<Image>().enabled)
            {
                find2_EARTH.gameObject.SetActive(true);
                find2_EARTH.GetComponent<RectTransform>().anchoredPosition = gameObject.GetComponent<RectTransform>().anchoredPosition + new Vector2(100, 0);
            }
            else if (gameObject.name == "SLOT_1_3" &&
                gameObject.transform.GetChild(0).GetComponent<Image>().enabled)
            {
                find3_EARTH.gameObject.SetActive(true);
                find3_EARTH.GetComponent<RectTransform>().anchoredPosition = gameObject.GetComponent<RectTransform>().anchoredPosition + new Vector2(100, -15);
            }
            else if (gameObject.name == "SLOT_1_4" &&
                gameObject.transform.GetChild(0).GetComponent<Image>().enabled)
            {
                find4_EARTH.gameObject.SetActive(true);
                find4_EARTH.GetComponent<RectTransform>().anchoredPosition = gameObject.GetComponent<RectTransform>().anchoredPosition + new Vector2(100, -30);
            }
        }

        // Lightning Menu
        else if (transform.parent.parent.name == "LightningMenu")
        {
            if (gameObject.name == "SLOT_1_1" &&
                (gameObject.transform.GetChild(0).GetComponent<Image>().enabled || gameObject.transform.GetChild(1).GetComponent<Image>().enabled))
            {
                find1_LIGHTNING.gameObject.SetActive(true);
                find1_LIGHTNING.GetComponent<RectTransform>().anchoredPosition = gameObject.GetComponent<RectTransform>().anchoredPosition + new Vector2(100, 15);
            }
            else if (gameObject.name == "SLOT_1_2" &&
                gameObject.transform.GetChild(0).GetComponent<Image>().enabled)
            {
                find2_LIGHTNING.gameObject.SetActive(true);
                find2_LIGHTNING.GetComponent<RectTransform>().anchoredPosition = gameObject.GetComponent<RectTransform>().anchoredPosition + new Vector2(100, 0);
            }
            else if (gameObject.name == "SLOT_1_3" &&
                gameObject.transform.GetChild(0).GetComponent<Image>().enabled)
            {
                find3_LIGHTNING.gameObject.SetActive(true);
                find3_LIGHTNING.GetComponent<RectTransform>().anchoredPosition = gameObject.GetComponent<RectTransform>().anchoredPosition + new Vector2(100, -15);
            }
            else if (gameObject.name == "SLOT_1_4" &&
                gameObject.transform.GetChild(0).GetComponent<Image>().enabled)
            {
                find4_LIGHTNING.gameObject.SetActive(true);
                find4_LIGHTNING.GetComponent<RectTransform>().anchoredPosition = gameObject.GetComponent<RectTransform>().anchoredPosition + new Vector2(100, -30);
            }
        }

        // Tower Menu
        else if (transform.parent.parent.name == "TowerMenu")
        {
            if (gameObject.name == "SLOT_1_1" &&
                (gameObject.transform.GetChild(0).GetComponent<Image>().enabled || gameObject.transform.GetChild(1).GetComponent<Image>().enabled))
            {
                find1_TOWER.gameObject.SetActive(true);
                find1_TOWER.GetComponent<RectTransform>().anchoredPosition = gameObject.GetComponent<RectTransform>().anchoredPosition + new Vector2(100, 15);
            }
            else if (gameObject.name == "SLOT_1_2" &&
                gameObject.transform.GetChild(0).GetComponent<Image>().enabled)
            {
                find2_TOWER.gameObject.SetActive(true);
                find2_TOWER.GetComponent<RectTransform>().anchoredPosition = gameObject.GetComponent<RectTransform>().anchoredPosition + new Vector2(100, 0);
            }
            else if (gameObject.name == "SLOT_1_3" &&
                gameObject.transform.GetChild(0).GetComponent<Image>().enabled)
            {
                find3_TOWER.gameObject.SetActive(true);
                find3_TOWER.GetComponent<RectTransform>().anchoredPosition = gameObject.GetComponent<RectTransform>().anchoredPosition + new Vector2(100, -15);
            }
            else if (gameObject.name == "SLOT_1_4" &&
                gameObject.transform.GetChild(0).GetComponent<Image>().enabled)
            {
                find4_TOWER.gameObject.SetActive(true);
                find4_TOWER.GetComponent<RectTransform>().anchoredPosition = gameObject.GetComponent<RectTransform>().anchoredPosition + new Vector2(100, -30);
            }
        }
    }
    #endregion

    #region IPointerExitHandler implementation
    public void OnPointerExit(PointerEventData eventData)
    {
        // Fire Menu
        if (transform.parent.parent.name == "FireMenu")
        {
            if (gameObject.name == "SLOT_1_1" && find1_FIRE.gameObject.activeInHierarchy == true)
                find1_FIRE.gameObject.SetActive(false);
            else if (gameObject.name == "SLOT_1_2" && find2_FIRE.gameObject.activeInHierarchy == true)
                find2_FIRE.gameObject.SetActive(false);
            else if (gameObject.name == "SLOT_1_3" && find3_FIRE.gameObject.activeInHierarchy == true)
                find3_FIRE.gameObject.SetActive(false);
            else if (gameObject.name == "SLOT_1_4" && find4_FIRE.gameObject.activeInHierarchy == true)
                find4_FIRE.gameObject.SetActive(false);
        }

        // Water Menu
        else if (transform.parent.parent.name == "WaterMenu")
        {
            if (gameObject.name == "SLOT_1_1" && find1_WATER.gameObject.activeInHierarchy == true)
                find1_WATER.gameObject.SetActive(false);
            else if (gameObject.name == "SLOT_1_2" && find2_WATER.gameObject.activeInHierarchy == true)
                find2_WATER.gameObject.SetActive(false);
            else if (gameObject.name == "SLOT_1_3" && find3_WATER.gameObject.activeInHierarchy == true)
                find3_WATER.gameObject.SetActive(false);
            else if (gameObject.name == "SLOT_1_4" && find4_WATER.gameObject.activeInHierarchy == true)
                find4_WATER.gameObject.SetActive(false);
        }

        // Earth Menu
        else if (transform.parent.parent.name == "EarthMenu")
        {
            if (gameObject.name == "SLOT_1_1" && find1_EARTH.gameObject.activeInHierarchy == true)
                find1_EARTH.gameObject.SetActive(false);
            else if (gameObject.name == "SLOT_1_2" && find2_EARTH.gameObject.activeInHierarchy == true)
                find2_EARTH.gameObject.SetActive(false);
            else if (gameObject.name == "SLOT_1_3" && find3_EARTH.gameObject.activeInHierarchy == true)
                find3_EARTH.gameObject.SetActive(false);
            else if (gameObject.name == "SLOT_1_4" && find4_EARTH.gameObject.activeInHierarchy == true)
                find4_EARTH.gameObject.SetActive(false);
        }

        // Lightning Menu
        else if (transform.parent.parent.name == "LightningMenu")
        {
            if (gameObject.name == "SLOT_1_1" && find1_LIGHTNING.gameObject.activeInHierarchy == true)
                find1_LIGHTNING.gameObject.SetActive(false);
            else if (gameObject.name == "SLOT_1_2" && find2_LIGHTNING.gameObject.activeInHierarchy == true)
                find2_LIGHTNING.gameObject.SetActive(false);
            else if (gameObject.name == "SLOT_1_3" && find3_LIGHTNING.gameObject.activeInHierarchy == true)
                find3_LIGHTNING.gameObject.SetActive(false);
            else if (gameObject.name == "SLOT_1_4" && find4_LIGHTNING.gameObject.activeInHierarchy == true)
                find4_LIGHTNING.gameObject.SetActive(false);
        }

        // Tower Menu
        else if (transform.parent.parent.name == "TowerMenu")
        {
            if (gameObject.name == "SLOT_1_1" && find1_TOWER.gameObject.activeInHierarchy == true)
                find1_TOWER.gameObject.SetActive(false);
            else if (gameObject.name == "SLOT_1_2" && find2_TOWER.gameObject.activeInHierarchy == true)
                find2_TOWER.gameObject.SetActive(false);
            else if (gameObject.name == "SLOT_1_3" && find3_TOWER.gameObject.activeInHierarchy == true)
                find3_TOWER.gameObject.SetActive(false);
            else if (gameObject.name == "SLOT_1_4" && find4_TOWER.gameObject.activeInHierarchy == true)
                find4_TOWER.gameObject.SetActive(false);
        }
    }
    #endregion
}
