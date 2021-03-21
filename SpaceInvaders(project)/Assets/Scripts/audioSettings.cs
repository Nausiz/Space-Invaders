using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class audioSettings : MonoBehaviour
{
    public AudioMixer masterMixer;

    public Slider musicSlider;
    public Slider effectsSlider;


    public void SliderMusic()
    {
        masterMixer.SetFloat("MusicVol", musicSlider.value);
    }

    public void SlideEffects()
    {
        masterMixer.SetFloat("EffectsVol", effectsSlider.value);
    }
}
