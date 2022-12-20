using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StugnaAimControl : MonoBehaviour
{
    public float moveInputHorizontal;
    public float moveInputVertical;
    public Joystick joystick;
    public float speed;
    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    public GameObject StugnaAmmo;
    public Transform shotDir;
    public float howFar;
    [SerializeField]
    public Text dozvil;
    public Text downText;
    public Image aimAmmo;
    public float fill;
    public Transform tank;
    public float timeShot;
    public float startTime;
    private bool isShoot;
    public float distance;
    public bool isEnd;
    public AudioSource shootSound;
    public Animator anim;
    [SerializeField]
    float leftLimit;
    [SerializeField]
    float rightLimit;
    [SerializeField]
    float bottomLimit;
    [SerializeField]
    float upperLimit;
    public GameObject eduPanel;
    public GameObject buttonPanel;
    public GameObject [] stugnaCurrent;
    public int destrCount;
    public int[] objCounts;
    public float[] timers;
    
    public int currentStugna;
    public bool isFail;
    public float PosXBuf;
    public float PosYBuf;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dozvil.text = "ЧЕКАЙ ДОЗВОЛУ НА ПУСК";
        timeShot = 10f;
        fill = 0;
        isShoot = false;
        currentStugna = PlayerPrefs.GetInt("CurrentStugna");
        for (int i = 0; i < stugnaCurrent.Length; i++ )
        {
            if(i == currentStugna)
            {
                stugnaCurrent[i].SetActive(true);
            }
            else
            {
                stugnaCurrent[i].SetActive(false);
            }
        }
        isEnd = false;
        isFail = false;
       
        destrCount = 0;
        PosXBuf = PlayerPrefs.GetFloat("PlayerPosXBuf");
        PosYBuf = PlayerPrefs.GetFloat("PlayerPosYBuf");
        //Time.timeScale = 0f;

    }
    void Update()
    {
       
        
        fill += Time.deltaTime * 0.1f;
       
        
        if (fill >= 1f)
        {
            dozvil.text = "ПУСК ДОЗВОЛЕНО";
            
            isShoot = false;

        }
        


        aimAmmo.fillAmount = fill;
        transform.position = new Vector3
            (Mathf.Clamp(transform.position.x, leftLimit, rightLimit),
            Mathf.Clamp(transform.position.y, bottomLimit, upperLimit),
            transform.position.z);
        if (destrCount >= objCounts[currentStugna] && !isEnd)
        {
            //Invoke("GameEnd", 4f);
            isEnd = true;
        }
        if (timers[currentStugna] > 0 )
        {
            timers[currentStugna] -= Time.deltaTime;
        }
        else if (timers[currentStugna] <= 0 && !isEnd)
        {
           
            isFail = true;

        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {

        moveInputHorizontal = joystick.Horizontal;
        moveInputVertical = joystick.Vertical;
        Vector2 moveInput = new Vector3(joystick.Horizontal, joystick.Vertical, 0);
        moveVelocity = moveInput * speed;
        rb.MovePosition(rb.position + moveVelocity * Time.deltaTime);
        
        
       
        //transform.position += new Vector2(transform.position.x * Time.deltaTime, transform.position.y );
    }
    public void Shoot()
    {
        if (fill >= 1f  )
        {
            Invoke ("Shot", 1f);
            isShoot = true;
            fill = 0f;
            dozvil.text = "ПУСК";
            shootSound.Play();
            anim.SetTrigger("Shoot");
            

        }
       
    }
    public void Shot()
    {
        Instantiate(StugnaAmmo, shotDir.position, shotDir.rotation);
        dozvil.text = "ВИПРОМІНЮВАННЯ";
    }
   
    public void ButtonClick()
    {
        if (!isEnd && !isFail)
        {

            GetComponent<EducationManager>().DisplayNextSentence();
        }
        else if (isFail)
        {
            SceneManager.LoadScene("Stugna");
        }
        else
        {
            SceneManager.LoadScene(PlayerPrefs.GetInt("SceneIndex"));
        }
    }
    void GameEnd()
    {


        SavePosition();
        Debug.Log(PosYBuf);
        eduPanel.SetActive(true);
        buttonPanel.SetActive(false);
       

    }
    public void SavePosition()
    {
        PlayerPrefs.SetFloat("PlayerPosX2", PosXBuf);
        PlayerPrefs.SetFloat("PlayerPosY2", PosYBuf);

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
