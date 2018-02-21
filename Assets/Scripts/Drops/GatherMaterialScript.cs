using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GatherMaterialScript : MonoBehaviour
{
    [SerializeField]
    private float gatherTime = 10.0f;

    [SerializeField]
    private float gatherTimer = 0.0f;

    GameObject player;
    CharacterInventory inventory;
    ParticleSystem particles;

    [SerializeField]
    Text HelpText;

    // Use this for initialization
    void Start()
    {
        //inventory = CharacterInstance.Instance.GetInventory();
        player = CharacterInstance.Instance.gameObject;
        inventory = player.GetComponent<CharacterInventory>();

        particles = GetComponent<ParticleSystem>();
        HelpText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        var emissions = particles.emission;

        if (gatherTimer < gatherTime)
            gatherTimer += Time.deltaTime * Time.timeScale;

        float Dist = Vector3.Distance(gameObject.transform.position, player.transform.position);
        if (gatherTimer >= gatherTime)
        {
            emissions.enabled = true;
            if (Dist <= 4)
            {
                HelpText.enabled = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (gameObject.tag.Contains("Scrap"))
                        inventory.addScrapsMaterialNumber(2);
                    else if (gameObject.tag.Contains("Wood"))
                        inventory.addWoodMaterialNumber(2);
                    else if (gameObject.tag.Contains("Ecto"))
                        inventory.addEctoMaterialNumber(1);

                    gatherTimer = 0;
                    emissions.enabled = false;
                    HelpText.enabled = false;
                }
            }
            else
            {
                HelpText.enabled = false;
            }
        }
        
    }
}