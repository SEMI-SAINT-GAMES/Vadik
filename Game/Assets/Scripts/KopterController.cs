using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class KopterController : MonoBehaviour
{
    public float moveInputHorizontal;
    public float moveInputVertical;
    public Joystick joystick;
    public float speed;
    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    public Transform shotDir;
    public GameObject kopterAmmo;
    [SerializeField]
    float leftLimit;
    [SerializeField]
    float rightLimit;
    [SerializeField]
    float bottomLimit;
    [SerializeField]
    float upperLimit;
    public Vector3 difference;
    public Button shoot;
    public float timerStart;
    private bool inTarget;
    public int shootCount;
    private int currentCopter;
    public int destrCount;
    public GameObject[] currentBackground;
    public int objectCounter;
    public KopterObjects kopterObjects;
    public int allObjects;
    EduManagerCopter eduManagerCopter;
    public GameObject eduPanel;
    public GameObject eduButton;
    public GameObject buttonPanel;
    public bool isEnd;
    private Vector3 aimPos;
    public string[] sceneNames;
    float PosXBuf;
    float PosYBuf;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        shoot.interactable = false;
        currentCopter = PlayerPrefs.GetInt("CurrentCopter");
       for (int i = 0; i < currentBackground.Length; i++)
        {
            if (i == currentCopter)
            {
                currentBackground[i].SetActive(true);
            }
            else
            {
                currentBackground[i].SetActive(false);
            }
        }
        destrCount = 0;
        eduPanel.SetActive(true);
        eduManagerCopter = GetComponent<EduManagerCopter>();
        isEnd = false;
        PosXBuf = PlayerPrefs.GetFloat("PlayerPosXBuf");
        PosYBuf = PlayerPrefs.GetFloat("PlayerPosYBuf");
    }
    void FixedUpdate()
    {

        moveInputHorizontal = joystick.Horizontal;
        moveInputVertical = joystick.Vertical;
        Vector2 moveInput = new Vector3(joystick.Horizontal, joystick.Vertical, 0);
        moveVelocity = moveInput * speed;
        rb.MovePosition(rb.position + moveVelocity * Time.deltaTime);
        
        



    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3
           (Mathf.Clamp(transform.position.x, leftLimit, rightLimit),
           Mathf.Clamp(transform.position.y, bottomLimit, upperLimit),
           transform.position.z);
        difference = new Vector3(Random.Range(-2, 2), Random.Range(-2, 2), 0);
        if (shootCount > 0)
        {
            inTarget = true;
        }
        else
        {
            inTarget = false;
        }
        if (inTarget)
        { 
            OnShootDelay();
        }

        if (destrCount == allObjects && !isEnd)
        {
           Invoke("GameEnd", 10f) ;
            
        }

        
    }
    public void ButtonClick()
    {
        if (!isEnd)
        {
            eduManagerCopter.DisplayNextSentence();
        }
        else
        {
            GameObject.FindGameObjectWithTag("LoadingScreen").GetComponent<LoadingScreen>().Load(sceneNames[currentCopter]);
        }
    }
    void GameEnd()
    {
       
            isEnd = true;
        
        eduPanel.SetActive(true);
        eduButton.SetActive(true);
        SavePosition();



    }
    public void SavePosition()
    {
        PlayerPrefs.SetFloat("PlayerPosX1", PosXBuf);
        PlayerPrefs.SetFloat("PlayerPosY1", PosYBuf);

    }
    public void OnShootDown()
    {
        Invoke("OnShotDelay2", 3f);
        
        
    }
    public void OnShootDelay()
    {
        if (timerStart <= 0)
        {
            
            Instantiate(kopterAmmo, aimPos + difference, transform.rotation);
            timerStart += Random.Range(0.3f, 1.2f);
            shootCount--;
        }
        else
        {
            timerStart -= Time.deltaTime;
        }
        if (shootCount == 4)
        {
            kopterObjects.AnimoActive();
        }
        

    }
    public void OnShotDelay2()
    {
        shootCount += 6;
        destrCount += 1;
        aimPos = shotDir.position;
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
       
         shoot.interactable = true;
        
        
        kopterObjects = collision.GetComponent<KopterObjects>();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        shoot.interactable = false;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector2(leftLimit, upperLimit), new Vector2(rightLimit, upperLimit));
        Gizmos.DrawLine(new Vector2(leftLimit, bottomLimit), new Vector2(rightLimit, bottomLimit));
        Gizmos.DrawLine(new Vector2(leftLimit, upperLimit), new Vector2(leftLimit, bottomLimit));
        Gizmos.DrawLine(new Vector2(rightLimit, upperLimit), new Vector2(rightLimit, bottomLimit));
    }
}