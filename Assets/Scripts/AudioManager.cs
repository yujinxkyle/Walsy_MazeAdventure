using UnityEngine;

public class AudioManager : MonoBehaviour
{
[Header("---------- Audio Source ----------")]
[SerializeField] AudioSource musicSource;
[SerializeField] AudioSource SFXSoure;

[Header("---------- Audio Clip ----------")]
public AudioClip background;
public AudioClip death;
public AudioClip checkpoint;
public AudioClip wallTouch;
public AudioClip portalIn;
public AudioClip portalOut;

private void Start()
{
    musicSource.clip = background;
    musicSource.Play();
}   

public void PlaySFX(AudioClip clip)
{
    SFXSource.PlayOneShot(clip);
}    

