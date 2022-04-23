using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTwoBossContrroller : MonoBehaviour
{
    public float xSpeed;
    public float xDirection;
    public float ySpeed;
    public float yDirection;
    public GameObject enemyBullet;
    public GameObject enemyBullet2;
    public GameObject Explosion;
    private bool startAttack = false;
    private float attckModelTimer =100;
    private float attackModelOneTimer = 0;
    private float attackModelOneCount = 0.05f;
    private bool modelOneActive = true;
    private int numHit = 0;
    public bool allowMovement = true;


    //private int attackModel = 0;
    // Start is called before the first frame update
    void Start()
    {
        xSpeed = 1.0f;
        xDirection = 1;
        ySpeed = 1.0f;
        yDirection = -1.0f;
        allowMovement = true;
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (allowMovement) { 
            if (transform.position.y > 1.77)
            {
                transform.Translate(xSpeed * 0 * Time.deltaTime, ySpeed * yDirection * Time.deltaTime, 0, Space.World);
            }
            else {
                startAttack = true;
                transform.Translate(xSpeed * xDirection * Time.deltaTime, 0 * yDirection * Time.deltaTime, 0, Space.World);

            }
        }

        if (startAttack) {
            attckModelTimer -= Time.deltaTime;
            attackModelOneTimer += Time.deltaTime;

            if (attckModelTimer > 95 && attckModelTimer <100)
            {
                //modelOne
                if (attackModelOneTimer > attackModelOneCount)
                {
                    if (modelOneActive)
                    {
                        GameObject bullet = Instantiate(enemyBullet);
                        GameObject bullet2 = Instantiate(enemyBullet);
                        //bullet.transform.position = new Vector3(transform.position.x -2.5f, transform.position.y - 0.3f, 90);
                        bullet.transform.position = new Vector3(transform.position.x - 2.5f, transform.position.y, 90);
                        bullet2.transform.position = new Vector3(transform.position.x + 2.5f, transform.position.y, 90);
                        attackModelOneTimer = 0;
                        modelOneActive = false;
                    }
                    else
                    {
                        attackModelOneTimer = 0;
                        modelOneActive = true;
                    }
                }
                //GameObject bullet = Instantiate(enemyBullet);
                //bullet.transform.position = new Vector3(transform.position.x, transform.position.y - 0.3f, 90);



            }
            else if (attckModelTimer > 88 && attckModelTimer <=92)
            {
                //modelTwo
                if (attackModelOneTimer > attackModelOneCount)
                {
                    if (modelOneActive)
                    {
                        GameObject bullet = Instantiate(enemyBullet2);
                        GameObject bullet2 = Instantiate(enemyBullet2);
                        bullet.GetComponent<FloorchildbulletController>().xDirection = this.xDirection;
                        bullet.GetComponent<FloorchildbulletController>().xSpeed = this.xSpeed;
                        bullet2.GetComponent<FloorchildbulletController>().xDirection = this.xDirection;
                        bullet2.GetComponent<FloorchildbulletController>().xSpeed = this.xSpeed;
                        bullet.transform.position = new Vector3(transform.position.x - 0.1f, transform.position.y - 2f, 90);
                        bullet2.transform.position = new Vector3(transform.position.x + 0.1f, transform.position.y - 2f, 90);

                        attackModelOneTimer = 0;
                        modelOneActive = false;
                    }
                    else
                    {
                        attackModelOneTimer = 0;
                        modelOneActive = true;
                    }
                }
                //attackModel = 2;
            }
            //else if (attckModelTimer > 40)
            //{
            //    attackModel = 3;
            //}
            //else if (attckModelTimer > 20)
            //{
            //    attackModel = 4;
            //}
            //else if (attckModelTimer > 0)
            //{
            //    attackModel = 5;
            //}
            //else if (attckModelTimer > -20)
            //{
            //    attackModel = 6;
            //}
            else if(attckModelTimer <= 88)
            {
                attckModelTimer = 102;
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.Equals("RightWall"))
        {
            xDirection *= -1;
        }
        else if (collision.name.Equals("LeftWall"))
        {
            xDirection *= -1;
        }
        if (collision.tag.Equals("PlayerBullet"))
        {
            if (startAttack) { 
                numHit++;
            }
            Destroy(collision.gameObject);

             if (numHit > 500)
            {
                allowMovement = false;
                startAttack = false;
                if (GameObject.Find("GameStateHUD")) { 
                    GameObject.Find("GameStateHUD").GetComponent<GameState>().Playerscore += 50;
                }
                Destroy(this.gameObject,3f);
                GameObject explosion = Instantiate(Explosion);
                GameObject explosion2 = Instantiate(Explosion);
                GameObject explosion3 = Instantiate(Explosion);
                GameObject explosion4 = Instantiate(Explosion);
                GameObject explosion5 = Instantiate(Explosion);
                GameObject explosion6 = Instantiate(Explosion);
                GameObject explosion7 = Instantiate(Explosion);
                GameObject explosion8 = Instantiate(Explosion);
                GameObject explosion9 = Instantiate(Explosion);
                explosion.transform.position = this.transform.position;
                explosion2.transform.position = new Vector3(transform.position.x - 2.5f, transform.position.y, 90);
                explosion3.transform.position = new Vector3(transform.position.x + 2.5f, transform.position.y, 90);
                explosion4.transform.position = new Vector3(transform.position.x - 1.5f, transform.position.y - 2f, 90);
                explosion5.transform.position = new Vector3(transform.position.x + 1.5f, transform.position.y + 2f, 90);
                explosion6.transform.position = new Vector3(transform.position.x - 1.5f, transform.position.y - 2f, 90);
                explosion7.transform.position = new Vector3(transform.position.x + 1.5f, transform.position.y + 2f, 90);
                explosion8.transform.position = new Vector3(transform.position.x, transform.position.y + 2f, 90);
                explosion9.transform.position = new Vector3(transform.position.x, transform.position.y - 2f, 90);
                Destroy(explosion, 4f);
                Destroy(explosion2, 4f);
                Destroy(explosion3, 4f);
                Destroy(explosion4, 4f);
                Destroy(explosion5, 4f);
                Destroy(explosion6, 4f);
                Destroy(explosion7, 4f);
                Destroy(explosion8, 4f);
                Destroy(explosion9, 4f);
            }
        }
    }
}
