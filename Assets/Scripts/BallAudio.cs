using UnityEngine;

public class BallAudio : MonoBehaviour
{

    public AudioSource asSound;
    public AudioClip wallSound;
    public AudioClip paddleSound;
    
        public void PlayWallSound()
    {
        asSound.PlayOneShot(wallSound);
    }
    public void PlayPaddleSound()
    {
        asSound.PlayOneShot(paddleSound);
    }
}
