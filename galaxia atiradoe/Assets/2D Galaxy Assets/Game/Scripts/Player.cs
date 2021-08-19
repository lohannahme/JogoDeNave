using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private GameObject laserPrefab;
    [SerializeField] private GameObject explosionPrefab;
    [SerializeField] private float fireRate = 0.35f;
    private float canFire = 0.0f;
    [SerializeField] private float speed = 5.0f;
    [SerializeField]
    private float cdTime = 5f;
    [SerializeField]
    private byte lifes = 3;
    [SerializeField] private GameObject shields;

    public bool shieldOn = false;
    public bool speedPU = false;
    public bool tripleshoot = false;

    private UIManager _uimanager;
    private GameManager _gameManager;
    private AudioSource _laser;
    private sbyte hitCount;
    private int random;
   

    [SerializeField] private AudioClip dead;
    [SerializeField] private GameObject[] engines;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        _uimanager = GameObject.Find("Canvas").GetComponent<UIManager>();
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        if (_uimanager != null)
        {
            _uimanager.UpdateLives(lifes);
        }

        _laser = GetComponent<AudioSource>();

        hitCount = 0;

        random = Random.Range(0, 2);

    }

    // Update is called once per frame
    void Update()
    {
        Move();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }


    private void Shoot()
    {
        

        if (Time.time > canFire)
        {   
            _laser.Play();
            if (tripleshoot == true)
            {
                Instantiate(laserPrefab, transform.position + new Vector3(0, 1.18f, 0), Quaternion.identity);
                Instantiate(laserPrefab, transform.position + new Vector3(0.55f, 0.26f, 0), Quaternion.identity);
                Instantiate(laserPrefab, transform.position + new Vector3(-0.54f, 0.26f, 0), Quaternion.identity);
                canFire = Time.time + fireRate;
            }
            else
            {
                Instantiate(laserPrefab, transform.position + new Vector3(0, 1.18f, 0), Quaternion.identity);
                canFire = Time.time + fireRate;
            }
        }

    }

    private void Move()
    {
        if (speedPU == true)
        {
            speed = 6.5f;
        }
        else if (speedPU == false)
        {
            speed = 5;
        }
        float horizI = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * speed * horizI * Time.deltaTime);

        float vertI = Input.GetAxis("Vertical");
        transform.Translate(Vector3.up * speed * vertI * Time.deltaTime);

        if (transform.position.y > 0)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);
        }
        else if (transform.position.y < -4.17f)
        {
            transform.position = new Vector3(transform.position.x, -4.17f, 0);
        }

        if (transform.position.x < -8.25f)
        {
            transform.position = new Vector3(-8.25f, transform.position.y, 0);
        }
        else if (transform.position.x > 8.25f)
        {
            transform.position = new Vector3(8.25f, transform.position.y, 0);
        }
    }

    public void TripleShootOn()
    {
        tripleshoot = true;
        StartCoroutine(TripleShootCooldown());
    }

    public void SpeedBoostOn()
    {
        speedPU = true;
        StartCoroutine(SpeedBoostCooldown());
    }

    public void Damage()
    {
        if (shieldOn)
        {
            shieldOn = false;
            shields.gameObject.SetActive(false);
            return;
        }

        hitCount++;

        if(hitCount == 1)
        {
            engines[random].SetActive(true);
        }
        if(hitCount == 2)
        {
            if (engines[0])
            {
                engines[1].SetActive(true);
            }
            else
            {
                engines[0].SetActive(true);
            }
        }

        lifes--;
        _uimanager.UpdateLives(lifes);

        if (lifes < 1)
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            _gameManager.gameOver = true;
            _uimanager.ShowImage();
            AudioSource.PlayClipAtPoint(dead, Camera.main.transform.position);
            Destroy(gameObject);

        }
    }

    public void ShieldOn()
    {
        shieldOn = true;
        shields.gameObject.SetActive(true);
    }

    public IEnumerator TripleShootCooldown()
    {
        yield return new WaitForSeconds(cdTime);
        tripleshoot = false;

    }

    public IEnumerator SpeedBoostCooldown()
    {
        yield return new WaitForSeconds(3);
        speedPU = false;
    }
}
