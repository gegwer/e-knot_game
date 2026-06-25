using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Particle effects manager for visual feedback
/// </summary>
public class ParticleEffectManager : MonoBehaviour
{
    public static ParticleEffectManager instance;

    [Header("Particle Systems")]
    public ParticleSystem scoreParticles;
    public ParticleSystem deathParticles;
    public ParticleSystem flapParticles;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    /// <summary>
    /// Play particle effect when player scores
    /// </summary>
    public void PlayScoreEffect(Vector3 position)
    {
        if (scoreParticles != null)
        {
            scoreParticles.transform.position = position;
            scoreParticles.Play();
        }
    }

    /// <summary>
    /// Play particle effect when player dies
    /// </summary>
    public void PlayDeathEffect(Vector3 position)
    {
        if (deathParticles != null)
        {
            deathParticles.transform.position = position;
            deathParticles.Play();
        }
    }

    /// <summary>
    /// Play particle effect when player flaps
    /// </summary>
    public void PlayFlapEffect(Vector3 position)
    {
        if (flapParticles != null)
        {
            flapParticles.transform.position = position;
            flapParticles.Play();
        }
    }

    /// <summary>
    /// Create a simple particle effect at position
    /// </summary>
    public void CreateSimpleEffect(Vector3 position, Color color, int particleCount = 10)
    {
        GameObject particleObj = new GameObject("TempParticle");
        particleObj.transform.position = position;

        ParticleSystem ps = particleObj.AddComponent<ParticleSystem>();
        var main = ps.main;
        main.startColor = color;
        main.startSize = 0.2f;
        main.startSpeed = 3f;
        main.maxParticles = particleCount;
        main.duration = 0.5f;

        var emission = ps.emission;
        emission.rateOverTime = 0;
        emission.SetBursts(new ParticleSystem.Burst[] { new ParticleSystem.Burst(0f, particleCount) });

        Destroy(particleObj, 2f);
    }
}
