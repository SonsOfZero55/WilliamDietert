using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript : MonoBehaviour
{
    public float Range;
    public Transform Target;
    bool Detected = false;
    Vector2 Direction;
    public GameObject Gun;
    public GameObject bullet;
    public float FireRate;
    float nextTimeToFire = 0;
    public Transform Shootpoint;
    public float Force;

    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        Vector2 targetPos = Target.position;


        if (Target.position.x > -14 && Target.position.x < 14)
        {
           Detected = true; 
        }
        else
        {
           Detected = false;
        }

        if (Detected)
        {
            Gun.transform.up = Direction;
            if (Time.time > nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1 / FireRate;
                shoot();
            }
        }
    }
    void shoot()
    {
        GameObject BulletIns = Instantiate(bullet, Shootpoint.position, Quaternion.identity);
        //BulletIns.GetComponent<Rigidbody2D>().AddForce(new Vector2(10, 10));// (Direction * Force);

        //Debug.Log(Target.transform.position);
        BulletIns.transform.position = Vector2.MoveTowards(Shootpoint.position, Target.transform.position, 500f * Time.deltaTime);
        //BulletIns.transform.Translate(Target.position.x, Target.position.y, Target.position.z);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, Range);
    }
}
