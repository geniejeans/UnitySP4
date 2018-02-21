using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

    enum EnemyState
    {
        PATROL,
        CHASE,
        ATTACK,
        TOTAL_STATES,
    }

    enum EnemyTypes
    {
        NORMAL,
        FAST,
        TANK,
        TOTAL_TYPE,
    }

    enum EnemyElements
    {
        FIRE,
        WATER,
        EARTH,
        LIGHTNING,
        TOTAL_ELEMENTS,
    }

    public struct RandomSelection
    {
        private int minValue;
        private int maxValue;
        public float probability;

        public RandomSelection(int minValue, int maxValue, float probability)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
            this.probability = probability;
        }

        public int GetValue() { return Random.Range(minValue, maxValue + 1); }

        
    }

    public int GetRandomValue(params RandomSelection[] selections)
    {
        float rand = Random.value;
        float currentProb = 0;
        foreach (var selection in selections)
        {
            currentProb += selection.probability;
            if (rand <= currentProb)
                return selection.GetValue();
        }

        return -1;
    }

    List<Enemy> enemies = new List<Enemy>();

    EnemyState currstate;
    EnemyElements element;

    [Header("Game")]
    [SerializeField]
    float maxhealth = 10.0f;

    float health;

    [SerializeField]
    int enemysize = 0;

    [SerializeField]
    GameObject battlePanel;

    [SerializeField]
    Waypoints path;
    private int pathnodeid = 0;
    private Transform target;

    [SerializeField]
    int damage;

    [Header("Setup Fields")]
    [SerializeField]
    float turnspeed = 5.0f;

    [SerializeField]
    float range = 10.0f;

    [SerializeField]
    float movespeed = 1.0f;

    [SerializeField]
    GameObject Normal;

    [SerializeField]
    GameObject Fast;

    [SerializeField]
    GameObject Tank;

    [SerializeField]
    Text sizedisplay;

    [SerializeField]
    Text elementdisplay;

    [SerializeField]
    bool isLeader;

    GameObject player;
    GameObject infoPanel;
    bool inbattle;
    float cooldown = 6.0f;
    bool back = false;
    private bool hasAttacked;

    Animator animate;

    // Use this for initialization
    void Start () {
        //Don't initialise if this is a child
        if (isLeader)
        {
            currstate = EnemyState.PATROL;
            if (path)
                target = path.points[0];
            inbattle = false;
        }
        else
            enemysize = 1;

        health = maxhealth;
        player = GameObject.FindGameObjectWithTag("Player");
        sizedisplay.text =  "";
        element = (EnemyElements)Random.Range(0, 3);
        hasAttacked = false;
        animate = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {

        //Set text displays
        if (!inbattle)
        {
            sizedisplay.text = "Size: " + enemysize;
            elementdisplay.text = element.ToString();
        }
        else
        {
            sizedisplay.text = "";
            elementdisplay.text = element.ToString();
            infoPanel.GetComponentInChildren<Text>().text = element.ToString();
        }
           
        switch (currstate)
        {
            case EnemyState.PATROL:
                if (!CharacterInstance.Instance.GetInBattle())
                {
                    Patrol();
                    animate.SetTrigger("Run");
                }
                break;
            case EnemyState.CHASE:
                if (!CharacterInstance.Instance.GetInBattle())
                {
                    Chase();
                    animate.SetTrigger("Run");
                }
                break;
            case EnemyState.ATTACK:
                Attack();
                animate.SetBool("isRunning", false);
                break;
        }
    }

    //Health
    public void Addhealth(float amount)
    {
        //Only add health if enemy is alive
        if (health > 0)
        {
            health += amount;
            //EnemyInfo -> HealthEnemyBG -> HealthEnemybar
            infoPanel.transform.GetChild(1).transform.GetChild(0).GetComponent<Image>().fillAmount = health / maxhealth;
            //Check if the enmey is dead
            if (health <= 0)
            {
                gameObject.SetActive(false);
                BattleInstance.Instance.AddNumberOfEnemies(-1);
            }
      
        }

    }

    public void Sethealth(float _health)
    {
        health = _health;
    }

    public float Gethealth()
    {
        return health;
    }

    //States
    void Patrol()
    {
        //Rotate to target
        LockOnTarget(target);
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * turnspeed * Time.deltaTime, Space.World);
        //transform.LookAt(target);
        //gameObject.transform.position += (target.transform.position - gameObject.transform.position).normalized * Time.deltaTime * movespeed;

        //Distance check to waypoint
        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }

        //Visibility check

        //Distance check with player
        //float Dist = Vector3.Distance(transform.position, player.transform.position);

        //if (Dist <= range)
        //{
        //    currstate = EnemyState.CHASE;
        //}

        //Ray ray = new Ray(transform.position, (player.transform.position - transform.position).normalized * 10);
        //RaycastHit hit;
        //if (Physics.Raycast(ray, out hit, range))
        //{
        //    if (hit.collider.gameObject == target)
        //    {
        //        float angle = Vector3.Angle((player.transform.position - transform.position), transform.forward);
        //        if (angle < 5f)
        //        {
        //            currstate = EnemyState.CHASE;
        //        }
        //    }
        //}

        Vector3 dirFromAtoB = (player.transform.position - transform.position).normalized;
        //float dotProd = Vector3.Dot(dirFromAtoB, transform.forward);
        float angle = Vector3.Angle(dirFromAtoB, transform.forward);
        float dist = Vector3.Distance(transform.position, player.transform.position);
        if (angle <= 120.0f && dist <= range)
        {
            // ObjA is looking mostly towards ObjB(dotProd > 0.95)
            currstate = EnemyState.CHASE;
            Debug.Log("Chasing");
        }
    }

    void Chase()
    {
        //Rotate to target
        LockOnTarget(player.transform);
        //Go to player
        gameObject.transform.position += (player.transform.position - gameObject.transform.position).normalized * Time.deltaTime * movespeed;

        float Dist = Vector3.Distance(transform.position, player.transform.position);
        float WaypointDist = Vector3.Distance(transform.position, target.position);

        if (Dist > range)
        {
            cooldown -= Time.deltaTime;
        }
        else
            cooldown = 6.0f;

        //distance to player check
        if (WaypointDist >= range * 2f)
        {
            if (cooldown <= 0f)
            {
                currstate = EnemyState.PATROL;
                Debug.Log("Patrol");
            }
        }

        if (inbattle)
        {
            currstate = EnemyState.ATTACK;
        }
    }

    void Attack()
    {
        inbattle = true;
        if (!BattleInstance.Instance.GetPlayerTurn() && BattleInstance.Instance.GetTurnElaspedTime() <= 0.0f
            && health > 0 && !hasAttacked)
        {
            Debug.Log("ATTACKED");
            hasAttacked = true;
            CharacterInstance.Instance.AddHealth(-damage);
            BattleInstance.Instance.AddNumberOfEnmemiesAttacked(1);
            BattleInstance.Instance.SetTurnElaspedTime(1.0f);
        }
    }

    //In World
    public bool GetisLeader()
    {
        return isLeader;
    }

    public void SetisLeader(bool _tf)
    {
        isLeader = _tf;
    }

    public void SetEnemySize(int _size)
    {
        enemysize = _size;
    }

    public int GetEnemySize()
    {
        return enemysize;
    }

    public List<Enemy> GetEnemies()
    {
        return enemies;
    }

    void LockOnTarget(Transform t)
    {
        Vector3 dir = t.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * turnspeed).eulerAngles;
        transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    void GetNextWaypoint()
    {
        //Reset path if reached end
        if (!back)
        {
            if (pathnodeid >= path.points.Length - 1)
            {
                if (path.GetRepeat())
                {
                    back = true;
                    return;
                }

                pathnodeid = 0;
                target = path.points[pathnodeid];
                return;
            }
        }

        if (!back)
            pathnodeid++;
        else
            pathnodeid--;

        if (back && pathnodeid == 0)
        {
            pathnodeid = 0;
            back = false;
        }

        target = path.points[pathnodeid];
    }

    public void SetText(string s)
    {
        sizedisplay.text = s;
    }

    //In battle
    public bool Getinbattle()
    {
        return inbattle;
    }

    public void Setinbattle(bool _tf)
    {
        inbattle = _tf;

        if(inbattle)
        {
            //Set Attack State
            currstate = EnemyState.ATTACK;
            if (infoPanel == null)
            {
                infoPanel = Instantiate(battlePanel);
                infoPanel.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
                infoPanel.GetComponentInChildren<Text>().text = element.ToString();
                infoPanel.GetComponent<EnemyID>().SetID(0);
                infoPanel.SetActive(true);
            }

            //Init other enemies
            float percentage = GameObject.FindGameObjectWithTag("EnemyManager").GetComponent<EnemyManager>().GetDifficulty()/100.0f;
            for (int i = 0; i < enemysize - 1; ++i)
            {
                int random = GetRandomValue(
        new RandomSelection(1, 1, 1.0f - percentage),
        new RandomSelection(2, 2, percentage * .5f),
        new RandomSelection(3, 3, percentage * .5f));

                GameObject model;
                if(random < 2)
                    model = Instantiate(Normal, gameObject.transform.position, Quaternion.identity);
                else if (random < 3)
                    model = Instantiate(Tank, gameObject.transform.position, Quaternion.identity);
                else
                    model = Instantiate(Fast, gameObject.transform.position, Quaternion.identity);

                Enemy enemy = model.GetComponent<Enemy>();
                //Setting the infopanel
                enemy.infoPanel = Instantiate(battlePanel);
                enemy.infoPanel.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
                enemy.infoPanel.transform.position = new Vector3(enemy.infoPanel.transform.position.x, enemy.infoPanel.transform.position.y - 60 * (i + 1), enemy.infoPanel.transform.position.z);
                enemy.infoPanel.SetActive(true);
                enemy.infoPanel.GetComponent<EnemyID>().SetID(i + 1);
                enemy.currstate = EnemyState.ATTACK;
                enemy.SetisLeader(false);
                enemy.SetEnemySize(1);
                enemies.Add(enemy);
                Debug.Log( "Type: " + enemy.maxhealth);
            }
        }
    }

    public string GetElement()
    {
        return element.ToString();
    }

    public GameObject GetInfoPanel()
    {
        return infoPanel;
    }
    public void SetHasAttacked(bool value)
    {
        hasAttacked = value;
    }

    //Paths/Waypoints
    public Waypoints GetPath()
    {
        return path;
    }

    public void Assignpath(Waypoints _path)
    {
        path = _path;
        path.AddPatrols(1);

        target = path.points[0];
    }

    public void Removepath()
    {
        path.AddPatrols(-1);
        path = null;
        target = null;
    }

    //Debug, range display
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);

        if (target)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(transform.position, target.position);
        }
    }

    void OnDestroy()
    {
        Destroy(infoPanel);
    }
}