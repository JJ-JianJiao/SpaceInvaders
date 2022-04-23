using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorchildbulletController : MonoBehaviour
{

    public float xSpeed;
    public float ySpeed;
    public float xDirection;
    public float yDirection;
    public Vector3 bulletMovemet;
    // Start is called before the first frame update
    void Start()
    {
        xSpeed = 0f;
        ySpeed = 5f;
        yDirection = -1f;
        xDirection = -1f;
        bulletMovemet = new Vector3();
    }

    // Update is called once per frame
    void Update()
    {
        bulletMovemet = new Vector3(xSpeed * xDirection * Time.deltaTime, ySpeed * yDirection * Time.deltaTime,0);
        transform.Translate(bulletMovemet, Space.World);
    }

    //private void OnTriggerEnter2D(Collider2D collider)
    //{
    //    if (collider.name.Equals("BottomWall"))
    //    {
    //        Destroy(this.gameObject, 0.2f);
    //    }
    //}

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
