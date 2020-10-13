using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip fireSound;
    public static AudioClip enemyFireSound;
    public static AudioClip hitSound;
    public static AudioClip enemyDestroyedSound;
    public static AudioClip pickupSound;
    public static AudioClip extraLifeSound;

    static AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        fireSound = Resources.Load<AudioClip>("sfx_laser1");
        enemyFireSound = Resources.Load<AudioClip>("sfx_laser2");
        hitSound = Resources.Load<AudioClip>("sfx_shieldDown");
        enemyDestroyedSound = Resources.Load<AudioClip>("sfx_lose");
        pickupSound = Resources.Load<AudioClip>("sfx_shieldUp");
        extraLifeSound = Resources.Load<AudioClip>("spell2");

        audioSource = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip)
    {
        switch(clip)
        {
            case "sfx_laser1":
                audioSource.PlayOneShot(fireSound);
                break;
            case "sfx_laser2":
                audioSource.PlayOneShot(enemyFireSound);
                break;
            case "sfx_shieldDown":
                audioSource.PlayOneShot(hitSound);
                break;
            case "sfx_lose":
                audioSource.PlayOneShot(enemyDestroyedSound);
                break;
            case "sfx_shieldUp":
                audioSource.PlayOneShot(pickupSound);
                break;
            case "spell2":
                audioSource.PlayOneShot(extraLifeSound);
                break;
        }
    }
}
