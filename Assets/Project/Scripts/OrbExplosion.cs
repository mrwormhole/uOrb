using System.Collections;
using UnityEngine;

public class OrbExplosion : MonoBehaviour {

    OrbExplosion instance;
    public float explosion_delay = 15f; //delay slows the time until it blows up
    public float explosion_rate = 4f; //rate expands the circle collider which is triggered
    public float explosion_max_size = 20f; //the limited size where circle collider can reach at the end
    public float explosion_min_size = 0f; //the size in the beginning
    //public float upforce = 0.1f; //silly and not realistic but cool

    bool exploaded;

    CircleCollider2D explosion_circle;
    ParticleSystem particleEffect;
    SpriteRenderer spriteRenderer;

    //[SerializeField]
    //AudioSource auSource; //Find new audio source for orbs

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

        explosion_circle = GetComponent<CircleCollider2D>();
        particleEffect = GetComponentInChildren<ParticleSystem>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }







    void Update() {
        if(spriteRenderer.sprite != null) {
            explosion_delay -= Time.deltaTime;
        }
        if (explosion_delay <= 0) {
            exploaded = true;
        }
    }

    void FixedUpdate() {
        if (exploaded) {
            if (explosion_min_size < explosion_max_size) {
                explosion_min_size += explosion_rate;
            }
            else { 
                StartCoroutine("Chill");
            }
            explosion_circle.radius = explosion_min_size;
        }
    }

    IEnumerator Chill() {
        if (spriteRenderer.sprite != null) {
            exploaded = false;
            spriteRenderer.sprite = null;
            //sound
            particleEffect.Play();
            yield return new WaitForSeconds(1f);
            Destroy(gameObject);
        }
    }





    void OnTriggerEnter2D(Collider2D collision)
    {
        if (exploaded)
        {
            //auSource.Play(); definitely not here

            if (collision.attachedRigidbody != null)
            {
                Vector2 target = collision.transform.position;
                Vector2 bomb = gameObject.transform.position;
                Vector2 direction = (target - bomb);
                var distance = Vector2.Distance(target, bomb);
                float powerForShort = 8f / (distance);
                float powerForLong = 2f / (distance);

                if (distance > 1.4 && 2.2 > distance)
                {
                    //this is for mid range
                    collision.attachedRigidbody.AddForce(powerForLong * new Vector2(direction.x, direction.y / 4f).normalized, ForceMode2D.Impulse); //normalized 
                }
                else if (distance >= 2.2)
                {
                    //this is for long range
                    return;
                }
                else
                {
                    //this is for close range
                    collision.attachedRigidbody.AddForce(powerForShort * new Vector2(direction.x, direction.y).normalized, ForceMode2D.Impulse); //normalized
                }

            }
        }
    }

}
