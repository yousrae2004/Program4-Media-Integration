using UnityEngine;

public class KeepAudio : MonoBehaviour
{
    // This variable helps us check if a music player already exists
    public static KeepAudio instance;

    void Awake()
    {
        // 1. If we don't have a music player yet...
        if (instance == null)
        {
            // ...then THIS object is the music player.
            instance = this;
            // Tell Unity: "Don't destroy me when scenes change!"
            DontDestroyOnLoad(this.gameObject);
        }
        // 2. If we ALREADY have a music player (from a previous scene)...
        else
        {
            // ...then destroy this NEW one, because the old one is still playing.
            Destroy(this.gameObject);
        }

    }
    public void ChangeMusic(AudioClip newClip)
    {
        AudioSource source = GetComponent<AudioSource>();
        if (source.clip != newClip)
        {
            source.clip = newClip;
            source.Play();
        }
    }
}