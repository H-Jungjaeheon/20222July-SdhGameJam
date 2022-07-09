using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    public static ParticleManager Instance { get; private set; }

    [SerializeField] private ParticleSystem enemyDeathEffect;
    [SerializeField] private ParticleSystem enemyFreezeEffect;
    [SerializeField] private ParticleSystem enemyHitEffect;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
    }

    public void playDeathEffect(Vector3 pos)
    {
        ParticleSystem effect = Instantiate(enemyDeathEffect);

        effect.transform.position = pos;

        effect.Play();
    }

    public void playFreezeEffect(Vector3 pos)
    {
        ParticleSystem effect = Instantiate(enemyFreezeEffect);

        effect.transform.position = pos;

        effect.Play();
    }

    public void playHitEffect(Vector3 pos)
    {
        ParticleSystem effect = Instantiate(enemyHitEffect);

        effect.transform.position = pos;

        effect.Play();
    }
}
