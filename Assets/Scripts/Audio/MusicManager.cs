using UnityEngine;

[System.Serializable]
public class MusicTrack
{
    public string name;
    public AudioClip clip;
    [Range(0f, 1f)] public float volume = 1f;
    public int musicTypeId;
}

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;

    public MusicTrack[] musicTracks;
    public int currentMusicTypeId;

    private AudioSource musicSource;

    private MusicTrack currentTrack;
    private int currentTrackIndex = -1;

    private bool isPlaying = false;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        musicSource = GetComponent<AudioSource>();
        PlayRandomTrack();
    }

    void Update()
    {
        if (!isPlaying && !musicSource.isPlaying)
        {
            PlayRandomTrack();
        }
    }

    private void PlayRandomTrack()
    {
        int randomTrackIndex = Random.Range(0, musicTracks.Length);
        while (randomTrackIndex == currentTrackIndex || musicTracks[randomTrackIndex].musicTypeId != currentMusicTypeId)
        {
            randomTrackIndex = Random.Range(0, musicTracks.Length);
        }
        currentTrackIndex = randomTrackIndex;
        currentTrack = musicTracks[currentTrackIndex];

        musicSource.clip = currentTrack.clip;
        musicSource.volume = currentTrack.volume;
        musicSource.Play();

        isPlaying = true;

        Debug.Log("Playing: " + currentTrack.name);
    }
}