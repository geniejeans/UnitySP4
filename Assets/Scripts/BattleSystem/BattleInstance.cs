using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleInstance : MonoBehaviour {

    //Singleton
    public static BattleInstance _instance;
    public static BattleInstance Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<BattleInstance>();
                if (_instance == null)
                {
                    GameObject container = new GameObject("BattleSystem");
                    _instance = container.AddComponent<BattleInstance>();
                }
            }
            return _instance;
        }
    }
    //==================================================================
    [SerializeField]
    GameObject battlePlane;
    [SerializeField]
    Text turn;
    //Enemy that the player has enagaged
    private GameObject enemy;
    private GameObject planeClone; //Battle plane

    private bool battleFinished;
    private bool playerTurn;
    private float turnElaspedTime;
    private int enemySelected;
    private int numberOfEnemies;
    private int numberOFEnemiesAttacked;


    //Cooldown time for spells
    private int enemySelectedFire;
    private int cooldownFire;
    private int cooldownWater;
    private int cooldownEarth;
    private int cooldownLightning;
    // Use this for initialization
    void Start () {
        battleFinished = true;
        playerTurn = true;
        turnElaspedTime = 1.0f;
        numberOFEnemiesAttacked = 0;
        cooldownFire = 0;
        cooldownWater = 0;
        cooldownEarth = 0;
        cooldownLightning = 0;
    }
	
	// Update is called once per frame
	void Update () {
        if (enemy && !battleFinished)
        {
            if (!playerTurn)
            {
                turn.text = "TURN: ENEMY";
                if (turnElaspedTime >= 0.0f)
                {
                    turnElaspedTime -= Time.fixedDeltaTime;
                }
                    
                if (numberOFEnemiesAttacked == numberOfEnemies)
                {
                    //Resetting the attack
                    enemy.GetComponent<Enemy>().SetHasAttacked(false);
                    foreach (Enemy e in enemy.gameObject.GetComponent<Enemy>().GetEnemies())
                    {
                        e.SetHasAttacked(false);
                    }
                    playerTurn = true;
                    numberOFEnemiesAttacked = 0;

                    //Reducing cooldown of spells
                    if (cooldownFire > 0)
                    {
                        if (enemySelectedFire == 0)
                            enemy.GetComponent<Enemy>().Addhealth(-CharacterInstance.Instance.GetWeapon().GetFireDamage() / 1.3f);
                        else
                            enemy.GetComponent<Enemy>().GetEnemies()[enemySelectedFire - 1].Addhealth(-CharacterInstance.Instance.GetWeapon().GetFireDamage() / 1.3f);
                        cooldownFire--;
                    }
                      
                    if (cooldownWater > 0)
                        cooldownWater--;
                    if (cooldownEarth > 0)
                        cooldownEarth--;
                    if (cooldownLightning > 0)
                        cooldownLightning--;
                }
            }
            else
                turn.text = "TURN: PLAYER";
            //If all the enemies has been destoryed
            if (numberOfEnemies == 0)
            {
                foreach (Enemy e in enemy.gameObject.GetComponent<Enemy>().GetEnemies())
                {
                    Destroy(e.gameObject);

                    //rewards
                    if (Random.Range(0.0f, 1.0f) < 0.5f)
                    {
                        if (e.GetElement() == "FIRE")
                            CharacterInstance.Instance.GetInventory().addFireEssenceNumber(1);
                        else if (e.GetElement() == "WATER")
                            CharacterInstance.Instance.GetInventory().addWaterEssenceNumber(1);
                        else if (e.GetElement() == "EARTH")
                            CharacterInstance.Instance.GetInventory().addEarthEssenceNumber(1);
                        else if (e.GetElement() == "LIGHTNING")
                            CharacterInstance.Instance.GetInventory().addLightningEssenceNumber(1);
                    }
                }

                enemy.gameObject.GetComponent<Enemy>().Removepath();

                //rewards
                if (enemy.gameObject.GetComponent<Enemy>().GetElement() == "FIRE")
                    CharacterInstance.Instance.GetInventory().addFireEssenceNumber(1);
                else if (enemy.gameObject.GetComponent<Enemy>().GetElement() == "WATER")
                    CharacterInstance.Instance.GetInventory().addWaterEssenceNumber(1);
                else if (enemy.gameObject.GetComponent<Enemy>().GetElement() == "EARTH")
                    CharacterInstance.Instance.GetInventory().addEarthEssenceNumber(1);
                else if (enemy.gameObject.GetComponent<Enemy>().GetElement() == "LIGHTNING")
                    CharacterInstance.Instance.GetInventory().addLightningEssenceNumber(1);

                if (Random.Range(0.0f, 1.0f) < 0.3f)
                    CharacterInstance.Instance.GetInventory().addEctoMaterialNumber(1);
                
                Destroy(enemy);
                Destroy(planeClone);
                SetBattleFinished(true);
                turnElaspedTime = 1.0f;
                turn.text = "";
                cooldownFire = 0;
                cooldownWater = 0;
                cooldownEarth = 0;
                cooldownLightning = 0;
            }
        }
    }

    public bool GetBattleFinished()
    {
        return battleFinished;
    }

    public void SetBattleFinished(bool value)
    {
        battleFinished = value;
        Time.timeScale = 1.0f;
    }

    public void SetEnemySelected(int value)
    {
        enemySelected = value;
    }

    public void SetBattle(Collision collision, GameObject character)
    {
        //Pause game when start battle
  //      Time.timeScale = 0.0f;

        //Setting of the enemy
        enemy = collision.gameObject;
        enemy.GetComponent<Enemy>().Setinbattle(true);
        enemy.gameObject.transform.localPosition = new Vector3(character.gameObject.transform.localPosition.x + 5.0f, CharacterInstance.Instance.transform.localPosition.y + 60.5f, character.gameObject.transform.localPosition.z + 10.0f);
        enemy.gameObject.transform.localRotation = Quaternion.identity;
        enemy.gameObject.transform.localRotation *= Quaternion.Euler(0, -180f, 0);
        numberOfEnemies = enemy.GetComponent<Enemy>().GetEnemySize();
        //Spawn other eneimes
        int i = 1;
        foreach (Enemy e in enemy.gameObject.GetComponent<Enemy>().GetEnemies())
        {
            e.gameObject.transform.localPosition = new Vector3(enemy.gameObject.transform.localPosition.x - 5.0f * i, CharacterInstance.Instance.transform.localPosition.y + 60.5f, enemy.gameObject.transform.localPosition.z);
            e.gameObject.transform.localRotation = enemy.gameObject.transform.localRotation;
       //     e.GetInfoPanel().GetComponentInChildren<Text>().text = e.GetElement();
            e.SetisLeader(false);
            e.Setinbattle(true);
            i++;
        }


        //Create a new battle plane
        battleFinished = false;
        planeClone = Instantiate(battlePlane, character.gameObject.transform) as GameObject;
        planeClone.gameObject.transform.localPosition = new Vector3(planeClone.transform.localPosition.x, planeClone.transform.localPosition.y - 1.5f, planeClone.transform.localPosition.z);
    }

    public void Attack()
    {
        if (playerTurn && CheckValidEnemy())
        {
            if (enemySelected == 0)
                enemy.GetComponent<Enemy>().Addhealth(-CharacterInstance.Instance.GetWeapon().GetBaseDamage());
            else
                enemy.GetComponent<Enemy>().GetEnemies()[enemySelected - 1].Addhealth(-CharacterInstance.Instance.GetWeapon().GetBaseDamage());
            playerTurn = false;
        }
    }

    //Damage overtime
    public void FireSpell()
    {
        if (playerTurn && CheckValidEnemy())
        {
            if (cooldownFire > 0)
                return;

            if (enemySelected == 0)
                enemy.GetComponent<Enemy>().Addhealth(-CharacterInstance.Instance.GetWeapon().GetFireDamage());
            else
                enemy.GetComponent<Enemy>().GetEnemies()[enemySelected - 1].Addhealth(-CharacterInstance.Instance.GetWeapon().GetFireDamage());
            enemySelectedFire = enemySelected;
            cooldownFire = 3;
            playerTurn = false;
        }
    }

    //Lifesteal
    public void WaterSpell()
    {
        if (playerTurn && CheckValidEnemy())
        {
            if (cooldownWater > 0)
                return;

            if (enemySelected == 0)
                enemy.GetComponent<Enemy>().Addhealth(-CharacterInstance.Instance.GetWeapon().GetWaterDamage());
            else
                enemy.GetComponent<Enemy>().GetEnemies()[enemySelected - 1].Addhealth(-CharacterInstance.Instance.GetWeapon().GetWaterDamage());
            CharacterInstance.Instance.AddHealth(CharacterInstance.Instance.GetWeapon().GetWaterDamage());
            cooldownWater = 3;
            playerTurn = false;
        }
    }

    //AOE
    public void EarthSpell()
    {
        if (playerTurn)
        {
            if (cooldownEarth > 0)
                return;

            enemy.GetComponent<Enemy>().Addhealth(-CharacterInstance.Instance.GetWeapon().GetEarthDamage());
            foreach (Enemy e in enemy.gameObject.GetComponent<Enemy>().GetEnemies())
            {
                e.Addhealth(-CharacterInstance.Instance.GetWeapon().GetEarthDamage());
            }
            cooldownEarth = 3;
            playerTurn = false;
        }
    }

    //Critical
    public void LightningSpell()
    {
        if (playerTurn && CheckValidEnemy())
        {
            if (cooldownLightning > 0)
                return;

            int percentageNumber = Random.Range(0, 13);
            float newDamage = CharacterInstance.Instance.GetWeapon().GetBaseDamage();
            if (percentageNumber > 10)
                newDamage += CharacterInstance.Instance.GetWeapon().GetLightningCrit();
            else if (percentageNumber > 7)
                newDamage += CharacterInstance.Instance.GetWeapon().GetLightningCrit() / 1.3f;
            else if (percentageNumber > 4)
                newDamage += CharacterInstance.Instance.GetWeapon().GetLightningCrit() / 1.6f;
            else
                newDamage += CharacterInstance.Instance.GetWeapon().GetLightningCrit() / 2.0f;
            

            if (enemySelected == 0)
                enemy.GetComponent<Enemy>().Addhealth(-newDamage);
            else
                enemy.GetComponent<Enemy>().GetEnemies()[enemySelected - 1].Addhealth(-newDamage);

            cooldownLightning = 3;
            playerTurn = false;
        }
    }

    public void AddNumberOfEnemies(int value)
    {
        numberOfEnemies += value;
    }

    public void SetPlayerTurn(bool value)
    {
        playerTurn = value;
    }

    public bool GetPlayerTurn()
    {
        return playerTurn;
    }

    public void AddNumberOfEnmemiesAttacked(int value)
    {
        numberOFEnemiesAttacked += value;
    }

    public void SetTurnElaspedTime(float value)
    {
        turnElaspedTime = value;
    }

    public float GetTurnElaspedTime()
    {
        return turnElaspedTime;
    }

    //Checking if the enemy can be attacked
    private bool CheckValidEnemy()
    {
        //If parent enemy is selected
        if (enemySelected == 0)
        {
            if (enemy.GetComponent<Enemy>().Gethealth() > 0)
                return true;
            else
                return false;
        }

        else
        {
            if (enemy.GetComponent<Enemy>().GetEnemies()[enemySelected - 1].Gethealth() > 0)
                return true;
            else
                return false;
        }
    }
}
