using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipsNest : MonoBehaviour
{
    public float enemyShipSpeed;
    public float xSpeed;
    public float xDirection;
    public float xSpeedRange;
    public GameObject enemyBullet;
    public GameObject Explosion;
    public int upperRandomRange;
    private GameObject gameState;
    private int numHit = 0;
    // Start is called before the first frame update
    void Start()
    {
        enemyShipSpeed = 3.0f;
        upperRandomRange = 100;
        xSpeedRange = 3f;
        xDirection = Random.Range(-1, 2);
        xSpeed = Random.Range(0.1f, xSpeedRange);
        gameState = GameObject.Find("GameStateHUD");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(name);
        transform.Translate(xSpeed * xDirection * Time.deltaTime, enemyShipSpeed * -1 * Time.deltaTime, 0, Space.World);
        int random = Random.Range(1, upperRandomRange);

        if (random == 1)
        {
            GameObject bullet = Instantiate(enemyBullet);
            if (this.name.Equals("EnemyShipOne(Clone)")) {
                bullet.transform.position = new Vector3(transform.position.x, transform.position.y - 0.3f, 90);
            }
            else if (this.name.Equals("EnemyShipTwo(Clone)"))
            {
                bullet.transform.position = new Vector3(transform.position.x, transform.position.y - 0.3f, 90);
            }
            else if (this.name.Equals("EnemyShipThree(Clone)"))
            {
                bullet.transform.position = new Vector3(transform.position.x, transform.position.y - 0.3f, 90);
            }
            else if (this.name.Equals("EnemyShipFour(Clone)"))
            {
                GameObject bullet2 = Instantiate(enemyBullet);
                bullet.transform.position = new Vector3(transform.position.x - 0.3f, transform.position.y, 90);
                bullet2.transform.position = new Vector3(transform.position.x + 0.3f, transform.position.y, 90);
            }
            else if (this.name.Equals("EnemyShipFive(Clone)"))
            {
                bullet.transform.position = new Vector3(transform.position.x, transform.position.y - 0.3f, 90);
            }
            else if (this.name.Equals("EnemyShipSix(Clone)"))
            {
                GameObject bullet2 = Instantiate(enemyBullet);
                bullet.transform.position = new Vector3(transform.position.x - 0.3f, transform.position.y, 90);
                bullet2.transform.position = new Vector3(transform.position.x + 0.3f, transform.position.y, 90);
            }

        }
        
        

               
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag.Equals("Player"))
        {
            //Debug.Log("You hit me!!!");
            Destroy(this.gameObject);
            //Destroy(collider.gameObject);
            GameObject explosion = Instantiate(Explosion);
            explosion.transform.position = transform.position;
            Destroy(explosion, 1);
        }
        if (collider.tag.Equals("PlayerBullet"))
        {
            if (gameState)
            {
                if (this.name.Equals("EnemyShipOne(Clone)"))
                {
                    gameState.GetComponent<GameState>().Playerscore += 10;
                    Destroy(this.gameObject);
                    Destroy(collider.gameObject);
                    GameObject explosion = Instantiate(Explosion);
                    explosion.transform.position = transform.position;
                    Destroy(explosion, 1f);
                }
                else if (this.name.Equals("EnemyShipTwo(Clone)"))
                {
                    numHit++;
                    Destroy(collider.gameObject);

                    if (numHit == 2)
                    {
                        gameState.GetComponent<GameState>().Playerscore += 15;
                        Destroy(this.gameObject);
                        GameObject explosion = Instantiate(Explosion);
                        explosion.transform.position = transform.position;
                        Destroy(explosion, 1f);
                    }
                }
                else if (this.name.Equals("EnemyShipThree(Clone)"))
                {
                    numHit++;
                    Destroy(collider.gameObject);

                    if (numHit == 3)
                    {
                        gameState.GetComponent<GameState>().Playerscore += 20;
                        Destroy(this.gameObject);
                        GameObject explosion = Instantiate(Explosion);
                        explosion.transform.position = transform.position;
                        Destroy(explosion, 1f);
                    }
                }
                else if (this.name.Equals("EnemyShipFour(Clone)"))
                {
                    numHit++;
                    Destroy(collider.gameObject);

                    if (numHit == 4)
                    {
                        gameState.GetComponent<GameState>().Playerscore += 15;
                        Destroy(this.gameObject);
                        GameObject explosion = Instantiate(Explosion);
                        explosion.transform.position = transform.position;
                        Destroy(explosion, 1f);
                    }
                }
                else if (this.name.Equals("EnemyShipFive(Clone)"))
                {
                    numHit++;
                    Destroy(collider.gameObject);

                    if (numHit == 5)
                    {
                        gameState.GetComponent<GameState>().Playerscore += 20;
                        Destroy(this.gameObject);
                        GameObject explosion = Instantiate(Explosion);
                        explosion.transform.position = transform.position;
                        Destroy(explosion, 1f);
                    }
                }
                else if (this.name.Equals("EnemyShipSix(Clone)"))
                {
                    numHit++;
                    Destroy(collider.gameObject);

                    if (numHit == 6)
                    {
                        gameState.GetComponent<GameState>().Playerscore += 25;
                        Destroy(this.gameObject);
                        GameObject explosion = Instantiate(Explosion);
                        explosion.transform.position = transform.position;
                        Destroy(explosion, 1f);
                    }
                }
            }
            else {
                Destroy(this.gameObject);
                Destroy(collider.gameObject);
                GameObject explosion = Instantiate(Explosion);
                explosion.transform.position = transform.position;
                Destroy(explosion, 1f);
            }
        }

        if (collider.name.Equals("LeftWall") || collider.name.Equals("RightWall"))
        {
            xDirection *= -1;
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
