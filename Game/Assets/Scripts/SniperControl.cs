using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SniperControl : MonoBehaviour
{
    public Image bullet;
    private float fill;
    public float moveInputHorizontal;
    public float moveInputVertical;
    public Joystick joystick;
    public float speed;
    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    public float timeShot;
    public float startTime;
    public Transform shotDir;
    public GameObject sniperAmmo;
    public Animator Shake;
    public AudioSource shotSound;
    public AudioSource emptySound;
    public AudioSource rechargeSound;
    public int ammoCount;
    public Text ammoText;
    public int allAmmo;
    [SerializeField]
    float leftLimit;
    [SerializeField]
    float rightLimit;
    [SerializeField]
    float bottomLimit;
    [SerializeField]
    float upperLimit;
    public GameObject[] sniper;
    public Image aim;
    public Sprite[] aims;
    public int[] ammos;
    public int currentSniper;
    public int destrCount;
    public int[] objCounts;
    public bool isEnd;
    public bool isFail;
    public GameObject eduPanel;
    public GameObject buttonPanel;
    public float PosXBuf;
    public float PosYBuf;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        timeShot = 3f;
        fill = 1f;
        currentSniper = PlayerPrefs.GetInt("CurrentSniper");
        for (int i = 0; i < sniper.Length; i++)
        {
            if (i == currentSniper)
            {
                sniper[i].SetActive(true);
                aim.sprite = aims[i];
                ammoCount = ammos[i];
            }
            else
            {
                sniper[i].SetActive(false);

            }
        }
        allAmmo = ammoCount;
        isEnd = false;
        isFail = false;
        
        destrCount = 0;
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
        if (ammoCount > 0)
        {
            if (fill < 1)
            {
                fill += Time.deltaTime * 0.4f;
                
            }
            
        }

        bullet.fillAmount = fill;
        ammoText.text = ammoCount + "/" + allAmmo;
        transform.position = new Vector3
           (Mathf.Clamp(transform.position.x, leftLimit, rightLimit),
           Mathf.Clamp(transform.position.y, bottomLimit, upperLimit),
           transform.position.z);
        if (ammoCount <= 0 && !isEnd)
        {
            
            if (destrCount >= objCounts[currentSniper])
            {
                isEnd = true;
                isFail = false;
            }
            else
            {
                isFail = true;
                Debug.Log("why");
            }
            //Invoke("GameEnd", 4f);
        }
        if (destrCount >= objCounts[currentSniper] && !isEnd)
        {
            //Invoke("GameEnd", 4f);
            isEnd = true;
        }
    }
    public void Shoot()
    {
        if (ammoCount > 0)
        {
            if (fill >= 1)
            {
                Instantiate(sniperAmmo, shotDir.position, shotDir.rotation);
                Shake.SetTrigger("Shake");
                shotSound.Play();
                fill = 0;
                
                ammoCount -= 1;
                if (ammoCount > 0)
                {
                    Invoke("Recharge", 0.8f);
                }
            }
            else
            {
                emptySound.Play();
            }
        }
        
    }
    public void Recharge()
    {
       
        rechargeSound.Play();
        
    }
   
    public void ButtonClick()
    {
        if (!isEnd && !isFail)
        {
            GetComponent<EducationManager>().DisplayNextSentence();
            
        }
        else if (isFail)
        {
            SceneManager.LoadScene("Sniper");
        }
        else
        {
            SceneManager.LoadScene(PlayerPrefs.GetInt("SceneIndex"));
        }
    }
    void GameEnd()
    {



        eduPanel.SetActive(true);
        buttonPanel.SetActive(false);
        SavePosition();

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
