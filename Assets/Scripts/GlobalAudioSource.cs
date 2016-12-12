using UnityEngine;

public class GlobalAudioSource : MonoBehaviour
{
    [SerializeField]
    private AudioSource source = null;

    public static AudioSource Instance { get; set; }

    private void Awake()
    {
        GlobalAudioSource.Instance = this.source;
    }
}
