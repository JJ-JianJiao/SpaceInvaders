using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerShipController : MonoBehaviour
{
    public float speed;
    public float xDirection;
    public float yDirection;
    private bool hitLeftWall;
    private bool hitRightWall;
    private bool hitTopWall;
    private bool hitBottomWall;
    public bool isShield;
    public bool allowYMovement = false;
    public bool allowXMovement = true;
    private Vector3 initialPosition;

    public GameObject PlayerBullet;
    public GameObject Explosion;
    public GameObject Shield;
    public GameObject PlayerShip;

    GameObject shield;

    //timer
    private float reBornShipLifeTimer = 0;
    private float reBornShipLifeCount = 1.0f;
    private float shieldTimer = 0;
    public float isWinTimer = 0;
    private float shieldFlashTimer = 0;
    private float shieldFlashCount = 0.2f;
    private bool shieldIsDisplay = true;
    public bool reBorn = false;
    private bool isWin = false;

    Vector3 shipMovement;
    // Start is called before the first frame update
    void Start()
    {
        initialPosition = new Vector3(0,-4,90);
        speed = 5.0f;
        xDirection = 0;
        yDirection = 0;
        hitLeftWall = false;
        hitTopWall = false;
        hitBottomWall = false;
        hitRightWall = false;
        isShield = false;
        this.enabled = false;
        //this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        reBornShipLifeTimer += Time.deltaTime;
        shieldFlashTimer += Time.deltaTime;
        shieldTimer += Time.deltaTime;
        isWinTimer += Time.deltaTime;

        if (isWin) {
            if(isWinTimer > 1) { 
                shipMovement = new Vector3(0, speed * 1 * Time.deltaTime);
                transform.Translate(shipMovement, Space.Self);
                if (this.transform.position.y > 10) {
                    this.enabled = true;
                    SceneManager.LoadScene(2);
                }
            }
        }


        if (reBorn && reBornShipLifeTimer >= reBornShipLifeCount)
        {
            this.ResetPlayer();
            reBorn = false;
        }


        if (allowYMovement)
        {
            yDirection = Input.GetAxis("Vertical");
        }
        else {
            yDirection = 0;
        }
        if (allowXMovement)
        {
            xDirection = Input.GetAxis("Horizontal");
        }
        else {
            xDirection = 0;
        }
        shipMovement = new Vector3(speed * xDirection * Time.deltaTime, speed * yDirection * Time.deltaTime);

        if (shield) {
            shield.transform.position = this.transform.position;
            if (shieldTimer > 6)
            {
                Destroy(shield);
                this.isShield = false;
            }
            else if (shieldTimer > 3)
            {
                if (shieldFlashTimer > shieldFlashCount)
                {
                    if (shieldIsDisplay)
                    {
                        shield.gameObject.SetActive(false);
                        shieldFlashTimer = 0;
                        shieldIsDisplay = false;
                    }
                    else
                    {
                        shield.gameObject.SetActive(true);
                        shieldFlashTimer = 0;
                        shieldIsDisplay = true;
                    }
                }
            }
        }




        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject playerBullet = Instantiate(PlayerBullet);
            playerBullet.transform.position = new Vector3(transform.position.x, transform.position.y + 0.3f,90);
        }
        if (!hitLeftWall && !hitRightWall && !hitTopWall && !hitBottomWall)
        {
            transform.Translate(shipMovement, Space.Self);
        }
        else if (hitLeftWall && xDirection >= 0 && !hitBottomWall && !hitTopWall)
        {
            transform.Translate(shipMovement, Space.Self);
        }
        else if (hitRightWall && xDirection <= 0 && !hitBottomWall && !hitTopWall)
        {
            transform.Translate(shipMovement, Space.Self);
        }
        else if (hitTopWall && yDirection <= 0 && !hitLeftWall && !hitRightWall)
        {
            transform.Translate(shipMovement, Space.Self);
        }
        else if (hitBottomWall && yDirection >= 0 && !hitLeftWall && !hitRightWall)
        {
            transform.Translate(shipMovement, Space.Self);
        }
        else if (hitTopWall && hitRightWall && (xDirection < 0 || yDirection < 0))
        {
            transform.Translate(shipMovement, Space.Self);
        }
        else if (hitTopWall && hitLeftWall && (xDirection > 0 || yDirection < 0))
        {
            transform.Translate(shipMovement, Space.Self);
        }
        else if (hitBottomWall && hitLeftWall && (xDirection > 0 || yDirection > 0))
        {
            transform.Translate(shipMovement, Space.Self);
        }
        else if (hitBottomWall && hitRightWall && (xDirection < 0 || yDirection > 0))
        {
            transform.Translate(shipMovement, Space.Self);
        }
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.name.Equals("LeftWall"))
        {
            hitLeftWall = true;
        }
        if (collider.name.Equals("RightWall"))
        {
            hitRightWall = true;
        }
        if (collider.name.Equals("TopWall"))
        {
            hitTopWall = true;
        }
        if (collider.name.Equals("BottomWall"))
        {
            hitBottomWall = true;
        }

        if (collider.tag.Equals("enemies") || collider.tag.Equals("enemyBullet"))
        {
            Destroy(collider.gameObject);
            if (!isShield)
            {
                GameObject explosion = Instantiate(Explosion);
                explosion.transform.position = transform.position;
                Destroy(explosion, 1f);
                this.transform.position = new Vector3(-10, -10, 10);
                int lifes = GameObject.Find("PlayerLife").GetComponent<PlayerLife>().PlayerLifes;
                if (lifes == 1) {
                    Debug.Log("GameOver");
                    GameObject.Find("PlayerLife").GetComponent<PlayerLife>().DestroyLife();
                    this.LossThisLevel();
                } 
                else
                {
                    GameObject.Find("PlayerLife").GetComponent<PlayerLife>().DestroyLife();
                    this.reBorn = true;
                    this.reBornShipLifeTimer = 0;
                }
            }

        }

        //if (collider.tag.Equals("buff"))
        //{
        //    //Debug.Log("I got a Buff!!");
        //    shield = Instantiate(Shield, new Vector3(transform.position.x, transform.position.y), Quaternion.identity);
        //    Destroy(collider.gameObject);
        //    //isShield = true;
        //}

    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.name.Equals("LeftWall"))
        {
            hitLeftWall = false;
            Debug.Log("Left");
        }
        if (collider.name.Equals("RightWall"))
        {
            hitRightWall = false;
            Debug.Log("Right");
        }
        if (collider.name.Equals("TopWall"))
        {
            hitTopWall = false;
            Debug.Log("Top");
        }
        if (collider.name.Equals("BottomWall"))
        {
            hitBottomWall = false;
            Debug.Log("Buttom");
        }
    }

    public void ResetPlayer() {
        this.gameObject.transform.position = initialPosition;
        shield = Instantiate(Shield, new Vector3(transform.position.x, transform.position.y,90), Quaternion.identity);
        isShield = true;
        shieldTimer = 0;
    }

    public void WinThisLevel() {
        GameObject.Find("OpenLeft").GetComponent<OpeningController>().EndingEvent();
        GameObject.Find("OpenRight").GetComponent<OpeningController>().EndingEvent();
        this.allowXMovement = false;
        this.allowYMovement = false;
        this.isWin = true;
        this.isWinTimer = 0;
    }

    private void LossThisLevel() {
        GameObject.Find("OpenLeft").GetComponent<OpeningController>().EndingEvent();
        GameObject.Find("OpenRight").GetComponent<OpeningController>().EndingEvent();
        this.allowXMovement = false;
        this.allowYMovement = false;
        this.isWin = false;
    }
}
