using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShotSystem : MonoBehaviour
{
    float timeBeforeDestroying;
    void Start()
    {
        var sound = this.GetComponent<AudioSource>();
        timeBeforeDestroying = sound.clip.length;
    }

    // Update is called once per frame
    void Update()
    {
        timeBeforeDestroying -= Time.deltaTime;
        if(timeBeforeDestroying <= 0f)
        {
            Destroy(this.gameObject);
        }
    }
}
 