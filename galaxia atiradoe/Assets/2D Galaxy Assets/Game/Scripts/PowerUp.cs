using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3 ;
    [SerializeField]
    private byte powerupID;
    public AudioClip audioPup;
    
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
        if(transform.position.y < -7f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("colidiu com" + other.name);
        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();

            if (player != null)
            {
                if (powerupID == 0)
                {
                    player.TripleShootOn();
                }
                else if(powerupID == 1)
                {
                    player.SpeedBoostOn();
                }
                else if(powerupID == 2)
                {
                    player.ShieldOn();
                }

            }

            AudioSource.PlayClipAtPoint(audioPup, Camera.main.transform.position);
            Destroy(this.gameObject);
        }
    }

    
}
