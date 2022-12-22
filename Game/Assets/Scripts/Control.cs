using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Control : MonoBehaviour
{
    public Vector3 savePos;
    public float speed;
    public float ladderSpeed;
    public float jumpforce;
    public bool isRight;
    public Rigidbody2D physic;
    public bool isDead;
    public GameObject javelin;
    public int health;
    public bool isGrounded;
    private float groundRadius = 0.3f;
    public Transform groundCheck;
    public LayerMask GroundMask;
    Collider2D hit;
    public Image heroHeathBar;
    public Sprite fulllive;
    public GameObject death;
    private Animator anim;
    public GameObject torso;
    public Material matBlink;
    public Material matDef;
    private SpriteRenderer spriteRend;
    public GameObject EnemyPatr;
    private EnemyPatrool st;
    public AudioSource HealthSound;
    private AK47 ak;
    public Sprite defSprite;
    public Sprite[] tankSprite;
    public int currentTank;
    public int currentTank1;
    public GameObject animoTank;
    public bool collectingTank;
    public bool inTank;
    public bool javIsActivated;
    public float tankSpeed;
    public float defSpeed;
    public float btrSpeed;
    public Image fuelCount;
    public GameObject fuelCheck;
    public GameObject body;
   
    public GameObject AK47;
    public Image tankActivate;
    public int damage = 5;
    public float timerStart;
    public bool collecting;
    public GameObject doorOpenButton;
    public GameObject doorOpenButtonTigr;
    public GameObject TankShootButton;
    public Transform deadLine;
    public Transform PlayerDefPos;
    public GameObject m4Panel;
    public GameObject gajetPanel;
    public GameObject howitzerPanel;
    public GameObject tankPanel;
    public Sprite[] weaponSprite;
    public int currentWeapon;
    public bool inLadder;
    public GameObject houseInside;
    private bool InHouse;
    public int currentWeapon1;
    public bool inPalace;
    public bool inCar;
   
   public TigrVehicleDiagonal tigr;
    public GameObject shootButtonTigr;
    public bool inSafePos;
    public AudioSource runSound;
    public int currentLevel;
    public bool alreadyInCar;
    public GameObject[] bodyParts;
    














    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        //PlayerPrefs.SetFloat("PlayerPosX", 0);
        //PlayerPrefs.SetFloat("PlayerPosY", 0);
        if (inSafePos)
        {
            transform.position = new Vector3(PlayerPrefs.GetFloat("PlayerPosX" + currentLevel.ToString()), PlayerPrefs.GetFloat("PlayerPosY" + currentLevel.ToString()), 0);
        }
        Time.timeScale = 1;
        //PlayerPrefs.SetInt("CurrentWeapon", 7);
        //PlayerPrefs.SetInt("CurrentWeapon1", 7);
        //PlayerPrefs.SetInt("CurrentTank", 2);
        //PlayerPrefs.SetInt("CurrentTank1", 5);
        //DefPosition();
        ak = GetComponent<AK47>();
        currentWeapon = PlayerPrefs.GetInt("CurrentWeapon");
        currentTank = PlayerPrefs.GetInt("CurrentTank");
        WeaponActivateSprite();
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
        isRight = true;
        matBlink = Resources.Load("EnemyBlink", typeof(Material)) as Material;
        matDef = torso.GetComponent<SpriteRenderer>().material;
        //EnemyPatr = GameObject.Find("enemy rus");
        //st = EnemyPatr.GetComponent<EnemyPatrool>();
        //spriteRend.sprite = defSprite;
        inTank = false;
        physic = GetComponent<Rigidbody2D>();
        collecting = false;
        collectingTank = false;
        speed = 0f;
        javIsActivated = false;
        inLadder = false;
        InHouse = false;
        
        TankShootButton.SetActive(false);
        inPalace = false;
        tankActivate.enabled = false;
        isDead = false;
        runSound = GameObject.Find("RunSound").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        /*Collider2D hit= Physics2D.OverlapCircle(groundCheck.position, 1f);
        movGround = null;
        if (hit != null)
        {
            movGround = hit.GetComponent<MovGround>();

        }
        if (movGround != null)
        {
            transform.parent = movGround.transform;
        }
        else
        {
            transform.parent = null;
        }*/
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, GroundMask);
        transform.position += new Vector3(speed * Time.deltaTime, 0, 0);

        currentWeapon = PlayerPrefs.GetInt("CurrentWeapon");
        currentWeapon1 = PlayerPrefs.GetInt("CurrentWeapon1");
        currentTank = PlayerPrefs.GetInt("CurrentTank");
        currentTank1 = PlayerPrefs.GetInt("CurrentTank1");
        fuelCount.fillAmount = timerStart * 0.1f;
        tankActivate.sprite = tankSprite[currentTank];

        if (!inCar)
        {
            heroHeathBar.fillAmount = health * 0.1f;
        }


        if (deadLine != null && transform.position.y < deadLine.position.y)
        {
            death.SetActive(true);
            gameObject.SetActive(false);
        }
       

        if (timerStart <= 0 && inTank == true)
        {

            OutOfTank();

        }
        if (timerStart > 0 && !inTank)
        {
            tankActivate.enabled = true;
        }
        if (inTank == true)
        {
            timerStart -= Time.deltaTime;
        }
        

        

    }

    public void OnJumpDown()
    {

        
        if (isGrounded == true && inLadder == false)
        {
            physic.velocity = Vector2.up * jumpforce;
            anim.SetTrigger("Jumping");
           
            
        }
        else if (inLadder)
        {
            
            physic.velocity = new Vector2(0, ladderSpeed);
            
            anim.SetTrigger("Climbing");
            foreach(GameObject g in bodyParts)
            {
                g.GetComponent<PolygonCollider2D>().isTrigger = true;
            }
            
        }
    }
    public void TankPlus()
    {
        if (currentTank1 <= 4)
        {
            collectingTank = true;

            speed = 0;
            PlayerPrefs.SetInt("CurrentTank1", currentTank1 + 1);

            Invoke("TankPanelActivate", 0.5f);
        }
    }

    public void TankReset()
    {
        PlayerPrefs.SetInt("CurrentTank1", 0);
    }
    public void OnJumpUp()
    {
        physic.gravityScale = 1;
        foreach (GameObject g in bodyParts)
        {
            g.GetComponent<PolygonCollider2D>().isTrigger = false;
        }
        if (inLadder == true)
        {
           
            //anim.SetTrigger("Idle");
           
        }
    }
    public void TransformRight()
    {

        if (ak.currentWeapon == 1)
        {
            speed = tankSpeed;
        }
        
        else
        {
            speed = defSpeed;
        }
        anim.SetBool("Run", true);
        if (isGrounded && !inTank)
        {
            runSound.Play();
        }

        //AK47.GetComponent<SpriteRenderer>().flipX = false;
        if (isRight == false)
        {
            Flip();
        }
    }
    public void TransformLeft()
    {
        
        if (ak.currentWeapon == 1)
        {
            speed = -tankSpeed;
        }
        else
        {
            speed = -defSpeed;
        }
        anim.SetBool("Run", true);
        if (isGrounded && !inTank)
        {
            runSound.Play();
        }

        if (isRight == true)
        {
            Flip();
        }
    }
    void Flip()
    {
        isRight = !isRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    public void OnButtonUp()
    {
        speed = 0f;
        anim.SetBool("Run", false);
        runSound.Stop();
    }

    public void TakeUron(int uron)

    { if (!inTank)
        {
            health -= uron;
            //torso.GetComponent<SpriteRenderer>().material = matBlink;
            

            if (health <= 0)
            {
                Die();
               
            }
            else
            {
                anim.SetTrigger("Damage");
            }
        }
    }

    void ResetMaterial()
    {
        torso.GetComponent<SpriteRenderer>().material = matDef;
    }
    public void TankPanelActivate()
    {
            tankPanel.SetActive(true);
            tankActivate.enabled = true;
        PlayerPrefs.SetInt("CurrentTank", currentTank1);

    }
    public void InCarEnter()
    {
        GetComponent<BoxCollider2D>().isTrigger = false;
        inCar = true;
        anim.enabled = false;
        body.SetActive(false);
        AK47.SetActive(false);
        javelin.SetActive(false);
        Camera camera = Camera.main;
        camera.GetComponent<CameraTransform>().car = tigr.gameObject.transform;
        GetComponent<DeathManager>().ButtonOff();
        shootButtonTigr.SetActive(true);
        doorOpenButtonTigr.SetActive(false);
        tigr.TimerOn();
        tigr.isDoing = true;
        tigr.GetComponent<BoxCollider2D>().enabled = false;
        tigr.GetComponent<PolygonCollider2D>().enabled = true;
        
        Camera.main.GetComponent<CameraTransform>().offset.y = 3.5f;
        alreadyInCar = true;



    }
    public void OutOfCar(bool die)
    {
        inCar = false;
        anim.enabled = true;
        body.SetActive(true);
        AK47.SetActive(true);
        tigr.engineSound.Stop();
        tigr.stopSound.Play();
        Camera camera = Camera.main;
        camera.GetComponent<CameraTransform>().car = null;
        GetComponent<DeathManager>().ButtonOn();
        transform.position = tigr.gameObject.transform.position + new Vector3(0, 2, 0);
        doorOpenButtonTigr.SetActive(false);
        shootButtonTigr.SetActive(false);
        if (!die)
        {
            GetComponent<MargaretInsByHero>().MargaretIns();
        }
        
    }
    public void InTankDelay()
    {
        
        anim.SetTrigger("Tank");
    }

    public void InTankEnter()
    { 
       
        
        inTank = true;
        
        ak.currentWeapon = 1;
        anim.SetBool("InTank", true);

        timerStart = 10;
        tankActivate.enabled = false;
        javIsActivated = false;
        TankShootButton.SetActive(true);
        fuelCheck.SetActive(true);
        Camera camera = Camera.main;
        camera.GetComponent<CameraTransform>().offset = new Vector2(6, 1);



    }


    

    public void OutOfTank()
    {

        
        body.SetActive(true);
        inTank = false;
        
        ak.currentWeapon = 0;
        anim.enabled = true;
        AK47.SetActive(true);
        TankShootButton.SetActive(false);
        fuelCheck.SetActive(false);
        anim.SetBool("InTank", false);
        animoTank.SetActive(false);
        Camera camera = Camera.main;
        camera.GetComponent<CameraTransform>().offset = new Vector2(4, 1);
    }


     public void Die()
    {
        DeathManager deathManager = GetComponent<DeathManager>();
        deathManager.ButtonOff();
        death.SetActive(true);
        anim.SetBool("die", true);
        speed = 0;
        //st.chill();
        
        isDead = true;
        ResetMaterial();
        
    }
    
    

    public void WeaponActivateSprite()
    {
        if (collecting == false)
        {
            if (currentWeapon <= weaponSprite.Length - 1)
            {
                AK47.GetComponentInChildren<SpriteRenderer>().sprite = weaponSprite[currentWeapon];
            }
            else
            {
                AK47.GetComponentInChildren<SpriteRenderer>().sprite = weaponSprite[0];
                PlayerPrefs.SetInt("CurrentWeapon", 0);

            }
        }
        else
        {
            PlayerPrefs.SetInt("CurrentWeapon", currentWeapon1);
            AK47.GetComponent<SpriteRenderer>().sprite = weaponSprite[currentWeapon1];
            
            m4Panel.SetActive(true);
            Time.timeScale = 0f;
            collecting = false;
        }

        


        
    }

    public void ContinueInGame()
    {
        Time.timeScale = 1f;
        m4Panel.SetActive(false);
        tankPanel.SetActive(false);
        
        
    }
    
    public void GajetPanel()
    {
        gajetPanel.SetActive(true);
        //Time.timeScale = 0f;

    }
    public void HowitzerLoad()
    {
        howitzerPanel.SetActive(false);
        SceneManager.LoadScene(6);
        Time.timeScale = 1f;
    }
    public void HowitzerPanel()
    {
        howitzerPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void SavePosition()
    {
        PlayerPrefs.SetFloat("PlayerPosX" + currentLevel.ToString(), transform.position.x + 3f);
        PlayerPrefs.SetFloat("PlayerPosY" + currentLevel.ToString(), transform.position.y);

    }
    public void DefPosition()
    {
        PlayerPrefs.SetFloat("PlayerPosX" + currentLevel.ToString(), 0);
        PlayerPrefs.SetFloat("PlayerPosY" + currentLevel.ToString(), 0);


    }
    
    public void InDoorEnter()
    {
        
       
        
            if (InHouse == false)
            {
                houseInside.SetActive(true);
                InHouse = true;
            }
            else
            {
                houseInside.SetActive(false);
                InHouse = false;
            }
        

    }
    public int IndexOfWeaponBox(GameObject[] array, string name)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i].name == name)
            {
                return i;
            }
            
        }
        return -1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        
        EnemyHealth enemyhealth = collision.GetComponent<EnemyHealth>();
        if (enemyhealth != null )
        {
            if (inTank)
            {
                enemyhealth.TakeDamage(10);
            }
            else
            {
                health -= 1;
            }
        }
        
        Life life = collision.GetComponent<Life>();
        if (life != null)
        {
            if (health < 10)
            {
                health += 1;
                Destroy(collision.gameObject);
                HealthSound.Play();
            }
            else
            {
                Destroy(collision.gameObject);
                //add sound!!!
            }
        }
        


        NextLevel nextLevel = collision.GetComponent<NextLevel>();
        if (nextLevel != null)
        {
            speed = 0;
            PlayerPrefs.SetFloat("PlayerPosX" + currentLevel.ToString(), 0);
            PlayerPrefs.SetFloat("PlayerPosY" + currentLevel.ToString(), 0);
        }
        
        
       

        
        if (collision.GetComponent<Headquaters>())

        {
            SavePosition();
        }

        
        if (collision.gameObject.tag.Equals("Tigr"))
        {
            if (!inCar && !alreadyInCar)
            {
                doorOpenButtonTigr.SetActive(true);
            }
            
        }

        
        if (collision.name == "Fuel")
        {
            timerStart += 500;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.name == "House")
        {
            doorOpenButton.SetActive(true);

        }



    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        
        

        }
    private void OnTriggerExit2D(Collider2D collision)
    {
        
        if (collision.gameObject.name == "House")
        {
            doorOpenButton.SetActive(false);
           
        }
        if (collision.gameObject.tag.Equals("Tigr"))
        {
            if (!inCar)
            {
                doorOpenButtonTigr.SetActive(false);
            }
           
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Life life = collision.gameObject.GetComponent<Life>();
        if (life != null)
        {
            if (health < 10)
            {
                health += 1;
                
                Destroy(collision.gameObject);
                HealthSound.Play();
            }
            else
            {
                Destroy(collision.gameObject);
                //add sound!!!
            }
        }
        
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        MovGround mov = collision.gameObject.GetComponent<MovGround>();
        if (mov != null)
        {
            this.transform.parent = mov.transform;
        }
        MovGroundVertical movVert = collision.gameObject.GetComponent<MovGroundVertical>();
        if (movVert != null)
        {
            this.transform.parent = movVert.transform;
            
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        MovGround mov = collision.gameObject.GetComponent<MovGround>();
        if (mov != null)
        {
            this.transform.parent = null;
        }
        MovGroundVertical movVert = collision.gameObject.GetComponent<MovGroundVertical>();
        if (movVert != null)
        {
            this.transform.parent = null;
        }
    }
}
