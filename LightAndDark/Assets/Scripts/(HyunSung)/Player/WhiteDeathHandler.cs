using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteDeathHandler : MonoBehaviour
{
    [SerializeField] private GameObject deathEffectPrefab;
    [SerializeField] private Material dissolveMaterial;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    public void TriggerDeath()
    {
        if (deathEffectPrefab != null)
        {
            Instantiate(deathEffectPrefab, transform.position, Quaternion.identity);
        }

        if (dissolveMaterial != null)
        {
            spriteRenderer.material = new Material(dissolveMaterial);
            StartCoroutine(DissolveRoutine());
        }
    }

    private IEnumerator DissolveRoutine()
    {
        float time = 0f;
        while (time < 0.5f)
        {
            time += Time.deltaTime;
            spriteRenderer.material.SetFloat("_DissolveProgress", time / 0.5f);
            yield return null;
        }
        Destroy(gameObject);
    }
}
