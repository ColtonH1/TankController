using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Rendering.PostProcessing;

public class PlayerHealth : HealthBase
{
    [Header("PlayerHealth")]
    public CameraShake cameraShake;
    public VignetteFlash vignetteFlash;
    [SerializeField] PostProcessVolume volume;
    Vignette vignette;
    [SerializeField] float duration;

    private void Awake()
    {
        volume.profile.TryGetSettings(out vignette);
    }

    private void Update()
    {
        isInvuln = Invincibility.isActive;
    }

    public override void TakeDamage(int amount)
    {
        //vignette.enabled.Override(true);
        StartCoroutine(cameraShake.Shake(.15f, .4f));
        StartCoroutine(vignetteFlash.Flash(duration, vignette));
        base.TakeDamage(amount);
        //vignette.enabled.Override(false);
    }

    public override void Kill()
    {
        StartCoroutine(ResetLevel());
        base.Kill();
    }

    IEnumerator ResetLevel()
    {
        yield return new WaitForSeconds(1);
        PlayerManager.instance.KillPlayer();
    }
}
