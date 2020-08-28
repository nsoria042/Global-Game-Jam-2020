using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundObjeto1 : MonoBehaviour
{

    public AudioClip soundf1;

    AudioSource fuenteAudio;

    // Start is called before the first frame update
    void Start()
    {
        fuenteAudio = GetComponent<AudioClip> ();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            fuenteAudio.clip = soundf1;
        }
    }
}
