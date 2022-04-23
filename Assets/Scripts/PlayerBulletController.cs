using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletController : MonoBehaviour
{
    public float ySpeed;
    public float yDirection;
    public Vector3 bulletMovement;
    // Start is called before the first frame update
    void Start()
    {
        ySpeed = 8;
        yDirection = 1;
    }

    // Update is called once per frame
    void Update()
    {
        bulletMovement = new Vector3(0, ySpeed * yDirection * Time.deltaTime);
        transform.Translate(bulletMovement, Space.World);
    }

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
