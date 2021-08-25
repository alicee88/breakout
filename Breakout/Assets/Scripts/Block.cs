using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;

    ParticleSystem hitBurst;

    // Start is called before the first frame update
    void Start()
    {
        hitBurst = FindObjectOfType<ParticleSystem>();
        var main = hitBurst.main;
        main.startColor = GetComponent<SpriteRenderer>().color;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        ParticleSystem burstInstance = Instantiate(hitBurst, transform.position, transform.rotation);
        burstInstance.Play();
       // Destroy(burstInstance);
        Destroy(gameObject);
    }
}
