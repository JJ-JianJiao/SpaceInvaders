using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildrenShipController : MonoBehaviour
{
    public GameObject enemyBullet;
    public GameObject Explosion;
    public int upperRandomRange;
    private int numHit = 0;
    Color floolThree = new Color(4.0f / 255.0f, 56.0f / 255.0f, 253.0f / 255.0f, 1);
    Color floolTwo = new Color(139.0f / 255.0f, 90.0f / 255.0f, 189.0f / 255.0f, 1);
    Color floolOne = new Color(255.0f / 255.0f, 0f / 255.0f, 0f / 255.0f, 1);


    // Start is called before the first frame update
    void Start()
    {
        //this.GetComponent<Renderer>().material.color = Color.clear;
        //this.GetComponent<Renderer>().material.color = floolOne;
        print(floolOne);
        print(floolTwo);
        print(floolThree);
        upperRandomRange = 1000;
        this.enabled = false;
        //floolTwo = GameObject.Find("FloorOne").GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        //GameObject.Find("FloorOne").GetComponent<Renderer>().material.color = floolThree;

        Debug.Log(numHit);
        int random = Random.Range(1, upperRandomRange);

        if (random == 1)
        {
            GameObject redBullet = Instantiate(enemyBullet);
            redBullet.transform.position = new Vector3(transform.position.x, transform.position.y - 0.3f,90);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.name.Equals("RightWall"))
        {
            gameObject.transform.parent.GetComponent<MotherShip1Controller>().yMovement = true;
            gameObject.transform.parent.GetComponent<MotherShip1Controller>().xDirection = -1;
        }
        else if (collider2D.name.Equals("LeftWall"))
        {
            gameObject.transform.parent.GetComponent<MotherShip1Controller>().yMovement = true;
            gameObject.transform.parent.GetComponent<MotherShip1Controller>().xDirection = 1;
        }

        if (collider2D.tag.Equals("Player"))
        {
            //Debug.Log("You hit me!!!");
            Destroy(this.gameObject);
            //Destroy(collider.gameObject);
            GameObject explosion = Instantiate(Explosion);
            explosion.transform.position = transform.position;
            Destroy(explosion, 1f);
        }
        if (collider2D.tag.Equals("PlayerBullet"))
        {
            if (this.name.Equals("FloorOne")) {
                if (GameObject.Find("GameStateHUD") != null) {
                    GameObject.Find("GameStateHUD").GetComponent<GameState>().Playerscore += 10;
                }
                Destroy(this.gameObject);
                Destroy(collider2D.gameObject);
                GameObject explosion = Instantiate(Explosion);
                explosion.transform.position = transform.position;
                Destroy(explosion, 1f);
            }
            else if (this.name.Equals("FloorTwo"))
            {
                numHit++;
                Destroy(collider2D.gameObject);
                 if (numHit == 1) {
                    this.GetComponent<Renderer>().material.color = floolOne;
                }
                else if (numHit == 2) {
                    if (GameObject.Find("GameStateHUD") != null)
                        GameObject.Find("GameStateHUD").GetComponent<GameState>().Playerscore += 15;
                    Destroy(this.gameObject);
                    GameObject explosion = Instantiate(Explosion);
                    explosion.transform.position = transform.position;
                    Destroy(explosion, 1f);
                }
            }
            else if (this.name.Equals("FloorThree"))
            {
                numHit ++;
                Destroy(collider2D.gameObject);

                if (numHit == 1)
                {
                    this.GetComponent<Renderer>().material.color = Color.green;
                }
                else if (numHit == 2)
                {
                    this.GetComponent<Renderer>().material.color = Color.gray;
                }
                else if (numHit == 3)
                {
                    if (GameObject.Find("GameStateHUD") != null)
                        GameObject.Find("GameStateHUD").GetComponent<GameState>().Playerscore += 20;
                    Destroy(this.gameObject);
                    GameObject explosion = Instantiate(Explosion);
                    explosion.transform.position = transform.position;
                    Destroy(explosion, 1f);
                }
            }
            else if (this.name.Equals("FloorFour"))
            {
                numHit ++;
                Destroy(collider2D.gameObject);
                if (numHit == 1)
                {
                    //this.GetComponent<Renderer>().material.
                    this.GetComponent<Renderer>().material.color = floolThree;
                }
                else if (numHit == 2)
                {
                    this.GetComponent<Renderer>().material.color = floolTwo;
                }
                else if (numHit == 3)
                {
                    this.GetComponent<Renderer>().material.color = floolOne;
                }
                else if (numHit == 4)
                {
                    if (GameObject.Find("GameStateHUD") != null)
                        GameObject.Find("GameStateHUD").GetComponent<GameState>().Playerscore += 25;
                    Destroy(this.gameObject);
                    GameObject explosion = Instantiate(Explosion);
                    explosion.transform.position = transform.position;
                    Destroy(explosion, 1f);
                }
            }
            //Destroy(this.gameObject);
            //Destroy(collider2D.gameObject);
            //GameObject explosion = Instantiate(Explosion);
            //explosion.transform.position = transform.position;
            //Destroy(explosion, 1f);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
