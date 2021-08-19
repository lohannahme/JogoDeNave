using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField]private float _speedSide;
    [SerializeField]private float _speedUp;
    [SerializeField] private GameObject animationPrefab;

    private UIManager _uimanager;
    public AudioClip audio;

    void Start()
    {
        _uimanager = GameObject.Find("Canvas").GetComponent<UIManager>();

    }

    // Update is called once per frame
    void Update()
    {   
        transform.Translate(Vector3.right * _speedSide * Time.deltaTime);
        Move();
    }

    private void Move()
    {
        transform.Translate(Vector3.down * _speedUp * Time.deltaTime);
        if(transform.position.x > 7.73f)
        {
            _speedSide = -_speedSide;
        }else if(transform.position.x < -7.51f)
        {
            _speedSide = -_speedSide;
        }

        if(transform.position.y< -6.16f)
        {
            transform.position = new Vector3(Random.Range(-7.51f, 7.73f), 6.12f, transform.position.z);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Laser")
        {
            Destroy(collision.gameObject);
            Instantiate(animationPrefab, transform.position, Quaternion.identity);
            if(_uimanager != null)
            {
                _uimanager.UpdateScore();
            }
            AudioSource.PlayClipAtPoint(audio, Camera.main.transform.position);
            Destroy(gameObject);
        }
        else if(collision.tag == "Player")
        {
            Player player = collision.GetComponent<Player>();

            if(player != null)
            {
                player.Damage();
            }
            Instantiate(animationPrefab, transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(audio, Camera.main.transform.position);
            Destroy(this.gameObject);
        }
    }
}
