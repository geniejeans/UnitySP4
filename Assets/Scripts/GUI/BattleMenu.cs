using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleMenu : MonoBehaviour
{
    [SerializeField]
    Transform battleSpellMenu;

    [SerializeField]
    Transform battleItemMenu;

    [SerializeField]
    Transform battleSpellBackButton;

    [SerializeField]
    Transform battleItemBackButton;

// Use this for initialization
void Start () {
        battleSpellMenu.gameObject.SetActive(false);
        battleItemMenu.gameObject.SetActive(false);
        battleSpellBackButton.gameObject.SetActive(false);
        battleItemBackButton.gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SpellMenu()
    {
        if (battleSpellMenu.gameObject.activeInHierarchy == false)
        {
            battleSpellMenu.gameObject.SetActive(true);
            battleSpellMenu.gameObject.transform.GetChild(0).GetComponent<UsableSpells>().enabled = true;
            battleSpellBackButton.gameObject.SetActive(true);

            battleItemMenu.gameObject.SetActive(false);
        }
        else
        {
            battleSpellMenu.gameObject.SetActive(false);
            battleSpellMenu.gameObject.transform.GetChild(0).GetComponent<UsableSpells>().enabled = false;
            battleSpellBackButton.gameObject.SetActive(false);
        }
    }

    public void ItemMenu()
    {
        if (battleItemMenu.gameObject.activeInHierarchy == false)
        {
            battleItemMenu.gameObject.SetActive(true);
            battleItemBackButton.gameObject.SetActive(true);

            battleSpellMenu.gameObject.SetActive(false);
        }
        else
        {
            battleItemMenu.gameObject.SetActive(false);
            battleItemBackButton.gameObject.SetActive(false);
        }
    }

    public void Run()
    {
        CharacterInstance.Instance.SetInBattle(true);
    }
}
