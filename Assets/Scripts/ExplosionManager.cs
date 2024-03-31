using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionManager : MonoBehaviour
{
    public GameObject Explosion;
    public AudioClip clip;
    public AudioSource source;
  

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnDisable()
    {
        if (Explosion != null)
        {
            source.PlayOneShot(clip);
            GameObject explosionInstance = Instantiate(Explosion, transform.position, transform.rotation);

            Destroy(explosionInstance, 2f);
        }

    }

}
