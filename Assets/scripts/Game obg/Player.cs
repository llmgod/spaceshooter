using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public GameObject BOLSHOI_VSRIV, VZRIV;
    public Powerup ShootPower, ShieldPower, ScorePower;
    public GameObject LaserPrefab;
    private bool canShoot = true;
    private float elepsedTime = 0;
    public float ShootDelay = 1;
    public int Health = 100;
    public float Speed = 6;
    public UnityEvent OnDead;
    public Slider HealthBar, UltaBar;
    public Vector3 Velocity;
    private Vector2 screenSize;
    private SpriteRenderer spriteRenderer;
    private float Energy = 100;
    private float MaxEnergy = 100;
    public float DodgeSpeed = 55;
    private float CurrentSpeed;
    private bool isDodging = false;
    private const float energyRecoveryDelay = 1;
    private float energyRecoveryElapsedTime = energyRecoveryDelay;
    private CamerShake CamerShaker;
    public GameObject shield;
    private int shieldCapacity, maxSieldCapacity;
    private void Start()
    {
        HealthBar.maxValue = Health;
        HealthBar.value = Health;
        UltaBar.maxValue = MaxEnergy;
        UltaBar.value = MaxEnergy;
        screenSize = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        spriteRenderer = GetComponent<SpriteRenderer>();
        CurrentSpeed = Speed;
        CamerShaker = Camera.main.GetComponent<CamerShake>();
    }


  
    private void Update ()
    {
        HandlePowerupsInput();
        HandleShooting();
        HandleShield();
        HandleScore();
        if (Input.GetKeyDown(KeyCode.LeftShift) && Energy >= MaxEnergy)
        {
            energyRecoveryElapsedTime = 0;
            Energy = 0;
            StartCoroutine(Dodge());
            
        }
        energyRecoveryElapsedTime += Time.deltaTime;
        if (energyRecoveryElapsedTime > energyRecoveryDelay)
        {
            energyRecoveryElapsedTime = energyRecoveryDelay;
        }
        
        Energy = energyRecoveryElapsedTime / energyRecoveryDelay * MaxEnergy;
        UltaBar.value = Energy;
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Velocity = (Vector3)input * CurrentSpeed * Time.deltaTime;
        transform.position += Velocity;
        var size = spriteRenderer.sprite.bounds.size * 0.0676003f;
        if (isDodging)
        {
            if (transform.position.x < -screenSize.x - size.x / 2)
            {
                Vector3 position = transform.position;
                position.x = screenSize.x + size.x / 2;
                transform.position = position;
            }
            else if (transform.position.x > screenSize.x + size.x / 2)
            {
                Vector3 position = transform.position;
                position.x = -screenSize.x - size.x / 2;
                transform.position = position;
            }
            if (transform.position.y > screenSize.y + size.y / 2)
            {
                Vector2 position = transform.position;
                position.y = -screenSize.y - size.y / 2;
                transform.position = position;
            }
            else if (transform.position.y < -screenSize.y - size.y / 2)
            {
                Vector2 position = transform.position;
                position.y = screenSize.y + size.y / 2;
                transform.position = position;
            }
        }
        else
        {
            if (transform.position.x < -screenSize.x)
            {
                Vector3 position = transform.position;
                position.x = -screenSize.x;
                transform.position = position;
            }
            else if (transform.position.x > screenSize.x)
            {
                Vector3 position = transform.position;
                position.x = screenSize.x;
                transform.position = position;
            }
            if (transform.position.y > screenSize.y)
            {
                Vector2 position = transform.position;
                position.y = screenSize.y;
                transform.position = position;
            }
            else if (transform.position.y < -screenSize.y)
            {
                Vector2 position = transform.position;
                position.y = -screenSize.y;
                transform.position = position;
            }
        } 
        
    }
    private void CreateLaser(Vector3 position, float angle)
    {
        GameObject clone = Instantiate(LaserPrefab);
        clone.transform.position = position;
        clone.transform.eulerAngles = new Vector3(0, 0, angle);
        Destroy(clone, 5);

    }
    private void HandleShooting()
    {
        
        if (canShoot && Input.GetKey(KeyCode.Space))
        {
            canShoot = false;
            if (!ShootPower.isActive)
            {
                CreateLaser(transform.position, 0);
            }
            else
            {
                if (ShootPower.level == 1)
                {
                    CreateLaser(transform.position, 4f);
                    CreateLaser(transform.position, 0);
                    CreateLaser(transform.position, -4f);
                }
                else if (ShootPower.level == 2)
                {
                    CreateLaser(transform.position, 0);
                    CreateLaser(transform.position, 4f);
                    CreateLaser(transform.position, -4f);
                    CreateLaser(transform.position, 8f);
                    CreateLaser(transform.position, -8f);
                }
                else if (ShootPower.level == 3)
                {
                    CreateLaser(transform.position, 0);
                    CreateLaser(transform.position, 4f);
                    CreateLaser(transform.position, -4f); 
                    CreateLaser(transform.position, 8f);
                    CreateLaser(transform.position, -8f);
                    CreateLaser(transform.position, 12);
                    CreateLaser(transform.position, -12);
                }
            }
        }
        elepsedTime += Time.deltaTime;
        if (elepsedTime > ShootDelay)
        {
            elepsedTime = 0;
            canShoot = true;

        }
    }
        private void HandlePowerupsInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ScorePower.Activate();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ShootPower.Activate();
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ShieldPower.Activate(false);
            if (ShieldPower.level == 1)
            {
                shieldCapacity = maxSieldCapacity= 1;
            }
            else if (ShieldPower.level == 2)
            {
                shieldCapacity = maxSieldCapacity= 4;
            }
            else if (ShieldPower.level == 3)
            {
                shieldCapacity = maxSieldCapacity = 10;
            }
        }
    }
    private void HandleScore()
    {
        if (ScorePower.isActive)
        {
            if (ScorePower.level == 1)
            {
                Score.Instance.Scale = 1.2f;
            }
            else if (ScorePower.level == 2)
            {
                Score.Instance.Scale = 1.5f;
            }
            else if (ScorePower.level == 3)
            {
                Score.Instance.Scale = 2f;
            }
            
        }
        else
        {
            Score.Instance.Scale = 1f;
        }
    }
    private void HandleShield()
    {
        var shieldActive = shieldCapacity > 0;
        shield.SetActive(shieldActive);
        if (shieldActive)
        {
            ShieldPower.SetFillAmount(shieldCapacity / (float)maxSieldCapacity);
        }
        else if (ShieldPower.level > 0)
        {
            ShieldPower.SetFillAmount(1);
        }
    }

    private IEnumerator Dodge()
    {

        CurrentSpeed = DodgeSpeed;
        isDodging = true;
        yield return new WaitForSeconds(0.1f);
        CurrentSpeed = Speed;
        isDodging = false;
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ScorePower"))
        {
            Destroy(collision.gameObject);
            ScorePower.Upgrade();
            return;
        }
        if (collision.CompareTag("ProtectPower"))
        {
            Destroy(collision.gameObject);
            ShieldPower.Upgrade();
            if (ShieldPower.isActive)
            {
                shieldCapacity = (shieldCapacity + 1);
                if (shieldCapacity > maxSieldCapacity)
                {
                    shieldCapacity = maxSieldCapacity;
                }
            }
            return;
        }
        if (collision.CompareTag("ShootPower"))
        {
            Destroy(collision.gameObject);
            ShootPower.Upgrade();
            return;
        }
        if (isDodging)
        {
            return;
        }
        if (collision.gameObject.CompareTag("PlayerLaser"))
        {
            return;
        }
        
        if (shieldCapacity > 0 || ShieldPower.isActive)
        {
            shieldCapacity -= 1;
            if (shieldCapacity <=0)
            {
                ShieldPower.Deactivate();
            }
            return;
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            ChangeHealth(-20);
            CreateExplosion(collision.transform.position);
            CamerShaker.ShakeShake(1f, 0.85f);

            if (collision.TryGetComponent<Enemy>(out Enemy enemy))
            {
                enemy.TakeDamage(1);
            }
        }

        if (collision.gameObject.CompareTag("EnemyLaser"))
        {
            CreateExplosion(collision.transform.position);
            ChangeHealth(-5);
            CamerShaker.ShakeShake(1f, 0.1f);
            Destroy(collision.gameObject);
        } 
        if (collision.gameObject.CompareTag("MeteorBig"))
        {
            ChangeHealth(-20);
            CreateExplosion(collision.transform.position);
            CamerShaker.ShakeShake(1f, 0.85f);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("MeteorMedium"))
        {
            ChangeHealth(-15);
            CreateExplosion(collision.transform.position);
            CamerShaker.ShakeShake(1f, 0.5f);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("MeteorSmall"))
        {
            ChangeHealth(-10);
            CreateExplosion(collision.transform.position);
            CamerShaker.ShakeShake(1f, 0.3f);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("MeteorTiny"))
        {
            ChangeHealth(-5);
            CreateExplosion(collision.transform.position);
            CamerShaker.ShakeShake(1f, 0.1f);
            Destroy(collision.gameObject);
        }
    }
    private void CreateExplosion(Vector3 position)
    {
        var explosion = Instantiate(VZRIV);
        explosion.transform.position = position;

    }
    private void ChangeHealth (int value)
    {
        if (Health + value <= 0)
        {
            GameObject explosion = Instantiate(BOLSHOI_VSRIV);
            explosion.transform.position = transform.position;
            Health = 0;
            OnDead?.Invoke();
            Destroy(gameObject);
            CamerShaker.ShakeShake(1.5f, 5f);
        }
        else if (Health + value > 100)
        {
            Health = 100;
        }
        else
        {
            Health += value;
        }
        HealthBar.value = Health;
    }
}
