using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {

    [SerializeField]
    public Camera[] cameras;
    [SerializeField]
    public GameObject sideMenuSystem;
    [SerializeField]
    public GameObject fireMenuSystem;
    [SerializeField]
    public GameObject waterMenuSystem;
    [SerializeField]
    public GameObject earthMenuSystem;
    [SerializeField]
    public GameObject lightningMenuSystem;
    [SerializeField]
    public GameObject towerMenuSystem;
    [SerializeField]
    public GameObject towerMenuTitle;
    [SerializeField]
    public GameObject bagMenuSystem;
    [SerializeField]
    public GameObject battleMenuSystem;
    [SerializeField]
    public GameObject playerController;
    private int cameraIndex;
    bool previousBattle = false;
	// Use this for initialization
	void Start ()
    {
        cameraIndex = 0;
        //     sideMenuSystem = GetComponent<GameObject>();
        //     playerController = GetComponent<GameObject>();
        battleMenuSystem.gameObject.SetActive(false);

        //Setting all cameras active to false
        for (int i = 0; i < cameras.Length; i++)
        {
            cameras[i].gameObject.SetActive(false);
        }
        //Setting first camera active to true
        cameras[0].gameObject.SetActive(true);
    }
	
	// Update is called once per frame
	void Update ()
    {
		//if (Input.GetKeyDown(KeyCode.C))
  //      {
  //          int newIndex = cameraIndex;
  //          if (cameraIndex < cameras.Length - 1)
  //              newIndex++;
  //          else
  //              newIndex = 0;
  //          cameras[cameraIndex].gameObject.SetActive(false);
  //          cameras[newIndex].gameObject.SetActive(true);
  //          cameraIndex = newIndex;
  //          if (cameras[newIndex].gameObject.name == "BattleCamera")
  //          {
  //              sideMenuSystem.gameObject.SetActive(false);
  //       //       playerController.GetComponent<CharacterControl>().enabled = false;
  //              CharacterInstance.inBattle = true;
  //          }
  //          else
  //          {
  //              sideMenuSystem.gameObject.SetActive(true);
  //       //       playerController.GetComponent<CharacterControl>().enabled = true;
  //              CharacterInstance.inBattle = false;
  //          }
  //      }

        if (previousBattle != CharacterInstance.Instance.GetInBattle())
        {
            previousBattle = CharacterInstance.Instance.GetInBattle();
            int newIndex = cameraIndex;
            if (cameraIndex < cameras.Length - 1)
                newIndex++;
            else
                newIndex = 0;
            cameras[cameraIndex].gameObject.SetActive(false);
            cameras[newIndex].gameObject.SetActive(true);
            cameraIndex = newIndex;

            if (cameras[newIndex].gameObject.name == "BattleCamera")
            {
                sideMenuSystem.gameObject.SetActive(false);
                bagMenuSystem.gameObject.SetActive(false);
                fireMenuSystem.gameObject.SetActive(false);
                waterMenuSystem.gameObject.SetActive(false);
                earthMenuSystem.gameObject.SetActive(false);
                lightningMenuSystem.gameObject.SetActive(false);
                towerMenuSystem.gameObject.SetActive(false);
                towerMenuTitle.gameObject.SetActive(false);

                battleMenuSystem.gameObject.SetActive(true);
                CharacterInstance.Instance.SetInBattle(true);
            }
            else
            {
                sideMenuSystem.gameObject.SetActive(true);
                bagMenuSystem.gameObject.SetActive(true);

                battleMenuSystem.gameObject.SetActive(false);
                CharacterInstance.Instance.SetInBattle(false);
            }
        }
	}
}
