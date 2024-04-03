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
        if (source == null)
        {
            source = GetComponent<AudioSource>();
        }
    }

    // Update is called once per frame
    void OnDisable()
    {
        if (Explosion != null && clip != null && source != null)
        {
            source.PlayOneShot(clip);
            GameObject explosionInstance = Instantiate(Explosion, transform.position, transform.rotation);

            Destroy(explosionInstance, 2f);
        }

    }

}
