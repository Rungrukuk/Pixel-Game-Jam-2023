using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Child_Behaviour : MonoBehaviour
{
    [SerializeField] private Transform gravePos;
    [SerializeField] private Vector2 bounds;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private float fadeDuration = 1f;
    private BoxCollider2D boxCollider2D;
    private Vector2 workspace;
    private bool hasBeenAssigned;

    private void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        hasBeenAssigned = false;
        workspace = new Vector2(gravePos.position.x + bounds.x, gravePos.position.y + bounds.y);
    }

    private void Update()
    {
        if (StaticVariables.IsHideAndSeekActivated&&!hasBeenAssigned)
        {
            hasBeenAssigned = true;
            StartCoroutine(PlayHideAndSeek());
        }
    }

    private IEnumerator PlayHideAndSeek()
    {
        // Fade out the sprite.
        boxCollider2D.enabled = false;
        float elapsedTime = 0f;
        Color startColor = spriteRenderer.color;
        Color endColor = new Color(startColor.r, startColor.g, startColor.b, 0f);

        while (elapsedTime < fadeDuration)
        {
            float t = elapsedTime / fadeDuration;
            spriteRenderer.color = Color.Lerp(startColor, endColor, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Set the sprite alpha to 0.
        spriteRenderer.color = endColor;
        transform.position = workspace;
        spriteRenderer.color = new Color(startColor.r, startColor.g, startColor.b, 1f);
        boxCollider2D.enabled = true;
    }
}

