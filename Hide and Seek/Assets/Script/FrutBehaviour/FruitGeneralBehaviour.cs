using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitGeneralBehaviour : MonoBehaviour
{
    public AudioSource audioData;
   // private gameObject audioDestroy;
    public ParticleSystem destroyParticles;

    void Start() {
        //audioDestroy = GameObject.Find("AudioDestroy");
    }

    void OnCollisionEnter(Collision collision)
    {
        
        if(collision.collider.CompareTag("Player")) {
            Debug.Log(this.name);
            Destroy();
        }
           
    }

    public void Destroy() {
        //Debug.Log("aaa");
        audioData = GetComponent<AudioSource>();
        audioData.Play();
        Instantiate(destroyParticles, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
        Destroy(this.destroyParticles, 2);
    }

}
