using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject hitBurst;

    GameStatus gameStatus;

    // Start is called before the first frame update
    void Start()
    {
        ParticleSystem ps = hitBurst.GetComponent<ParticleSystem>();
        var main = ps.main;
        main.startColor = GetComponent<SpriteRenderer>().color;

        gameStatus = FindObjectOfType<GameStatus>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        DestroyBlock();
    }

    void DestroyBlock()
    {
        GameObject burstInstance = Instantiate(hitBurst, transform.position, transform.rotation);
        Destroy(burstInstance, 1.5f);
        Destroy(gameObject);
    }
}
