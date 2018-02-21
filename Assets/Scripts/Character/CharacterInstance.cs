using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterInstance : MonoBehaviour {

    public static CharacterInstance _instance;

    public static CharacterInstance Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<CharacterInstance>();
                if (_instance == null)
                {
                    GameObject container = new GameObject("Player");
                    _instance = container.AddComponent<CharacterInstance>();
                }
            }
            return _instance;
        }
    }


    public Image healthBar;
    public Text lifeFragmentsText;
    public Text extraLivesText;
    public static float startHealth;
    public static float positionOfInBattle;

    //Character's info
    CharacterInventory inventory;
    CharacterWeapon weapon;
    WeaponEnhancements enhance;
    private static bool inBattle;
    private static float health;
    private static int lifeFragments;
    private static int extraLives;

    //public static bool firstFire;

    // Use this for initialization
    void Start ()
    {
        inventory = gameObject.GetComponent<CharacterInventory>();
        weapon = gameObject.GetComponent<CharacterWeapon>();
        enhance = gameObject.GetComponent<WeaponEnhancements>();

        inBattle = false;
        startHealth = 20.0f;
        health = startHealth;
        lifeFragments = 0;
        extraLives = 0;
        positionOfInBattle = 30.0f;

        //firstFire = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        // if firstFire = true, battle what effect remember put
        //Debug.Log(firstFire);
        //Debug.Log(health);

        // For testing
        if (Input.GetKeyDown(KeyCode.H))
        {
            AddHealth(-10);
        }

        // Auto crafting of life fragments
        if (lifeFragments == 10)
        {
            lifeFragments = 0;
            extraLives += 1;
        }

        // If health <= 0, use up one life
        if (health <= 0)
        {
            health = startHealth;
            healthBar.fillAmount = health / startHealth;
            extraLives -= 1;
        }

        // Display text
        lifeFragmentsText.text = lifeFragments.ToString();
        extraLivesText.text = extraLives.ToString();
    }

    //public void CheckFireUpgrade()
    //{
    //    if (inventory.getFireEssenceNumber() >= 1)
    //    {
    //        inventory.addFireEssenceNumber(-1);
    //        firstFire = true;
    //        //add fire enhance to weapon menu
    //    }
    //    else
    //    {
    //        //text to show not enough materials?
    //    }
    //}

    public void AddHealth(float amount)
    {
        Debug.Log("HEalth is :" + health);
        if (health + amount < startHealth)
            health += amount;
        else if (health + amount >= startHealth) //To cap the health
            health = startHealth;

        healthBar.fillAmount = health / startHealth;
        // Die
        //if (health <= 0)
        //{

        //}
    }

    public void AddLifeFragments(int amount)
    {
        lifeFragments += amount;
    }

    public void AddLives(int amount)
    {
        extraLives += amount;
    }

    //Getters
    public CharacterInventory GetInventory()
    {
        return inventory;
    }

    public CharacterWeapon GetWeapon()
    {
        return weapon;
    }

    public WeaponEnhancements GetEnhancements()
    {
        return enhance;
    }

    public bool GetInBattle()
    {
        return inBattle;
    }
    
    public float GetHealth()
    {
        return health;
    }

    public int GetLifeFragments()
    {
        return lifeFragments;
    }

    //Setters
    public void SetInBattle(bool value)
    {
        inBattle = value;
    }

    public void SetHealth(float value)
    {
        health = value;
    }

    public void SetLifeFragments(int value)
    {
        lifeFragments = value;
    }

    public void SetLives(int value)
    {
        extraLives = value;
    }
}