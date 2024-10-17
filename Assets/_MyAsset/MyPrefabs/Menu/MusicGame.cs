using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicGame : SingletonDontdestroy<MusicGame>
{
    public AudioSource music;
    private bool isMute;
    private void Start()
    {
        music.Play();
    }
    public void MuteMusic()
    {
        isMute = !isMute;
        if (!isMute)
        {
            music.Play();
        }
        else
        {
            music.Pause();
        }
    }
}
