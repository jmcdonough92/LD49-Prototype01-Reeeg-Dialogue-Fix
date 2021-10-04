using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 5.0f;
    [SerializeField] private float _shotRate = 1;
    [SerializeField] private float _shotsPerSecond = 3;
    [SerializeField] private float _shotsPerSecondAnchor = 3;
    [SerializeField] private GameObject _shotPrefab;
    [SerializeField] private Wave spsWave;
    [SerializeField] private Wave numShotWave;
    [SerializeField] private PlayerStats stats;
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private SoundEffects soundEffects;
    [SerializeField] private int numShots = 1;
    [SerializeField] private float numShotsAnchor = 1;
    [SerializeField] private int coins = 0;
    public TMP_Text SPSText;
    public TMP_Text numShotsText;
    public TMP_Text coinsText;
    [SerializeField] private float shotDamage = 10;

    private float health = 100;
    private float maxHealth = 100;
    private Rigidbody2D rb;

    private bool canShoot = true;
    private bool canSpend = true;

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine("ShotCoolDown");
        rb = GetComponent<Rigidbody2D>();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("ShipHit");
        if (collision.collider.gameObject.CompareTag("Enemy"))
        {
            DamageShip(10f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Coin"))
        {
            coins++;
            coinsText.SetText(coins.ToString());
            soundEffects.PlayCoin();
            Destroy(collision.gameObject);
        }
        else DamageShip(shotDamage);
    }

    private void DamageShip(float damage)
    {
        health -= damage;
        healthBar.SetSize(Mathf.Max(health / maxHealth, 0));
        if (health <= 0) Lose();
        soundEffects.PlayShipHit();
    }

    private void Lose()
    {
        Debug.Log("YOU LOSE");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * _speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * _speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            Shoot();
        }
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
        {
            TrySpendCoin(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
        {
            TrySpendCoin(2);
        }
        UpdateStats();
    }

    private void TrySpendCoin(int skill)
    {
        if (coins > 0)
        {
            canSpend = false;
            switch (skill)
            {
                case 1:
                    if ((_shotsPerSecondAnchor + spsWave.GetValue()) > 2.5f)
                    {
                        _shotsPerSecondAnchor += spsWave.GetValue();
                    }
                    else
                    {
                        _shotsPerSecondAnchor = 2.5f;
                    }
                    coins--;
                    coinsText.SetText(coins.ToString());
                    soundEffects.PlayButton();
                    break;
                case 2:
                    numShotsAnchor += numShotWave.GetValue();
                    coins--;
                    coinsText.SetText(coins.ToString());
                    soundEffects.PlayButton();
                    break;
            }
        }
    }

    IEnumerator SpendCoolDown()
    {
        yield return new WaitForSeconds(0.1f);
    }

    private void UpdateStats()
    {
        _shotsPerSecond = spsWave.GetValue() * 1.5f + _shotsPerSecondAnchor;
        _shotRate = 1 / _shotsPerSecond;
        numShots = Mathf.RoundToInt(numShotWave.GetValue() + numShotsAnchor);

        SPSText.SetText(_shotsPerSecond.ToString("F1"));
        numShotsText.SetText(numShots.ToString("F0"));
    }

    private void Shoot()
    {

        if (canShoot)
        {
            ShootXShots();
            StopCoroutine("ShotCoolDown");
            StartCoroutine("ShotCoolDown");
            soundEffects.PlayFire();
            Debug.Log(_shotsPerSecond + " Shots per second");
        }
        canShoot = false;

    }

    private void ShootXShots()
    {
        switch (numShots)
        {
            case 1:
                Instantiate(_shotPrefab, transform.position, Quaternion.identity);
                break;
            case 2:
                Instantiate(_shotPrefab, transform.position, Quaternion.AngleAxis(-7.5f, transform.forward));
                Instantiate(_shotPrefab, transform.position, Quaternion.AngleAxis(7.5f, transform.forward));
                break;
            case 3:
                Instantiate(_shotPrefab, transform.position, Quaternion.identity);
                Instantiate(_shotPrefab, transform.position, Quaternion.AngleAxis(15, transform.forward));
                Instantiate(_shotPrefab, transform.position, Quaternion.AngleAxis(-15, transform.forward));
                break;
            case 4:
                Instantiate(_shotPrefab, transform.position, Quaternion.AngleAxis(-7.5f, transform.forward));
                Instantiate(_shotPrefab, transform.position, Quaternion.AngleAxis(7.5f, transform.forward));
                Instantiate(_shotPrefab, transform.position, Quaternion.AngleAxis(-22.5f, transform.forward));
                Instantiate(_shotPrefab, transform.position, Quaternion.AngleAxis(22.5f, transform.forward));
                break;
            case 5:
                Instantiate(_shotPrefab, transform.position, Quaternion.identity);
                Instantiate(_shotPrefab, transform.position, Quaternion.AngleAxis(15, transform.forward));
                Instantiate(_shotPrefab, transform.position, Quaternion.AngleAxis(-15, transform.forward));
                Instantiate(_shotPrefab, transform.position, Quaternion.AngleAxis(30, transform.forward));
                Instantiate(_shotPrefab, transform.position, Quaternion.AngleAxis(-30, transform.forward));
                break;
            default:
                if (numShots < 1)
                {

                    Instantiate(_shotPrefab, transform.position, Quaternion.identity);
                }
                else
                {

                    Instantiate(_shotPrefab, transform.position, Quaternion.identity);
                    Instantiate(_shotPrefab, transform.position, Quaternion.AngleAxis(15, transform.forward));
                    Instantiate(_shotPrefab, transform.position, Quaternion.AngleAxis(-15, transform.forward));
                    Instantiate(_shotPrefab, transform.position, Quaternion.AngleAxis(30, transform.forward));
                    Instantiate(_shotPrefab, transform.position, Quaternion.AngleAxis(-30, transform.forward));
                }
                break;
        }
    }

    IEnumerator ShotCoolDown()
    {

        yield return new WaitForSeconds(_shotRate);
        Debug.Log("Shot Ready");
        canShoot = true;
    }
}