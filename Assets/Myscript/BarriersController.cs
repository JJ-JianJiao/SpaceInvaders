using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarriersController : MonoBehaviour
{
    //public Material meshRender = null;
    //public Renderer rend;
    //public Texture texture;
    //Material second;
    // Start is called before the first frame update
    public int hitTimes;
    void Start()
    {
        hitTimes = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (hitTimes >= 5 && hitTimes < 10) { 
            this.transform.GetComponent<Renderer>().material.color = Color.green;
        }
        else if (hitTimes >= 10)
        {
            this.transform.GetComponent<Renderer>().material.color = Color.red;
        }

        if (hitTimes >= 15) {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.tag.Equals("PlayerBullet") && !collider.name.Equals("Player"))
        {
            //Debug.Log("My bullet!!!");
            Destroy(collider.gameObject);
            hitTimes++;
        }
        if (collider.tag.Equals("enemyBullet"))
        {
            //Debug.Log("My bullet!!!");
            Destroy(collider.gameObject);
            hitTimes++;
        }
    }
}
