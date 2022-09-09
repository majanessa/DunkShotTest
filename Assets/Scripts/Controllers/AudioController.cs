using UnityEngine;

namespace DunkShot.Controllers
{
    public class AudioController : MonoBehaviour
    {
        public static AudioController Instance
        {
            get;
            private set;
        }

        public AudioSource audioSource;

        public AudioClip bounseSound;
        public AudioClip ringSound;
        public AudioClip netSound;
        public AudioClip shotSound;
        public AudioClip coinSound;

        private void Awake()
        {
            Instance = this;
            SetVolume();
        }

        public void SetVolume()
        {
            audioSource.volume = PlayerPrefs.HasKey("Volume") ? PlayerPrefs.GetInt("Volume") : 1;
        }

        public void PlayAudio(AudioClip currentClip)
        {
            audioSource.PlayOneShot(currentClip);
        }
    }
}
