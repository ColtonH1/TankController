using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class VignetteFlash : MonoBehaviour
{
    //[SerializeField] PostProcessVolume volume;
    //Vignette vignette;
    public IEnumerator Flash(float duration, Vignette vignette)
    {
        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            vignette.enabled.Override(true);


            elapsed += Time.deltaTime;

            yield return null;
        }
        vignette.enabled.Override(false);
    }
}
