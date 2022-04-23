using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherShip2Controller : MonoBehaviour
{

    public GameObject enemyShips1;
    public GameObject enemyShips2;
    public GameObject enemyShips3;
    public GameObject enemyShips4;
    public GameObject enemyShips5;
    public GameObject enemyShips6;
    public float xSpeed;
    public int xDirection;
    Vector3 motherNestMovement;
    public int upperRandomRange;
    // Start is called before the first frame update
    void Start()
    {
        upperRandomRange = 200;
        xSpeed = 15.0f;
        this.enabled = false;
        xDirection = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //if (transform.position.x <= -8 || transform.position.x >= 8)
        //{
        //    xDirection *= -1;
        //}
        motherNestMovement = new Vector3(xSpeed * xDirection * Time.deltaTime, 0);
        transform.Translate(motherNestMovement, Space.World);

        int random = Random.Range(1, upperRandomRange);

        if (random == 1)
        {
            GameObject enermies = Instantiate(enemyShips1);
            enermies.transform.position = transform.position;
        }
        else if (random == 2) {
            GameObject enermies = Instantiate(enemyShips2);
            enermies.transform.position = transform.position;
        }
        else if (random == 3)
        {
            GameObject enermies = Instantiate(enemyShips3);
            enermies.transform.position = transform.position;
        }
        else if (random == 4)
        {
            GameObject enermies = Instantiate(enemyShips4);
            enermies.transform.position = transform.position;
        }
        else if (random == 5)
        {
            GameObject enermies = Instantiate(enemyShips5);
            enermies.transform.position = transform.position;
        }
        else if (random == 6)
        {
            GameObject enermies = Instantiate(enemyShips6);
            enermies.transform.position = transform.position;
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
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, 0.2f);
    }
}

