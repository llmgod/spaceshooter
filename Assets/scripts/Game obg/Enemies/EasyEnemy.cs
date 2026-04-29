using System.Collections;
using UnityEngine;

public class EasyEnemy : Enemy
{
    public GameObject Laser;
    public float ShootDelay = 3;

    public int LasersAmount = 1;
    public int Angle = 15;

    void Start()
    {
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        while (true)
        {
            for (int i = 0; i < LasersAmount; i+=1) 
            {
                GameObject clone = Instantiate(Laser);
                clone.transform.position = transform.position;
                float angleShift = LasersAmount * Angle / 2;
                clone.transform.eulerAngles = new Vector3(0, 0, i * Angle + clone.transform.eulerAngles.z - angleShift);
            }
            yield return new WaitForSeconds(ShootDelay);
        }
    }
}
