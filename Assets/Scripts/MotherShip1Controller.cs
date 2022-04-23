using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherShip1Controller : MonoBehaviour
{
    public float xSpeed;
    public int xDirection;
    public bool yMovement;
    public Vector3 xheadOfShipsMovement;
    public Vector3 yheadOfShipsMovement;
    public bool isPause;
    // Start is called before the first frame update
    void Start()
    {
        xSpeed = 2.0f;
        xDirection = 1;
        yMovement = false;
        xheadOfShipsMovement = new Vector3(1, 0, 0);
        yheadOfShipsMovement = new Vector3(0, -0.2f, 0);
        isPause = true;
        this.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (yMovement)
        {
            transform.Translate(yheadOfShipsMovement);
            yMovement = false;
        }
        else
        {
            transform.Translate(xDirection * xheadOfShipsMovement * xSpeed * Time.deltaTime);
        }

        if (transform.childCount == 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, 0.2f);
    }

}
