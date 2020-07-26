using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTakeDamage : TakeDamage
{
    float TimeOfinvulnerability = 2f;
    float blinkInterval = 0.1f;
    bool _invulnerable = false;

    [SerializeField] private SpriteRenderer spriteRenderer;

    public override void takeDamage(float damage)
    {
        if (!Enabled) return;
        base.takeDamage(damage);
        StartCoroutine(Invulnerable());
    }

    IEnumerator Invulnerable()
    {
        Enabled = false;
        var currentTimeInvulnerable = 0f;
        while (currentTimeInvulnerable <= TimeOfinvulnerability)
        {
            var color = spriteRenderer.color;
            color.a = 0f;
            spriteRenderer.color = color;
            yield return new WaitForSeconds(blinkInterval);
            color.a = 255f;
            spriteRenderer.color = color;
            yield return new WaitForSeconds(blinkInterval);
            currentTimeInvulnerable += 2 * blinkInterval;

        }
        Enabled = true;
    }
}
