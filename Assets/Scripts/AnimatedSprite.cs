using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class AnimatedSprite : MonoBehaviour
{
    public Sprite[] sprites;
    public float framerate = 1f / 6f;

    private SpriteRenderer spriteRenderer;
    private int frame;

    //kad krene da se krece pokreni skriptu sprite
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    //ponavlja se animacija sprite tokom kretanja
    private void OnEnable()
    {
        InvokeRepeating(nameof(Animate), framerate, framerate);
    }
    //kad stane sa kretanjem prekini animaciju za sprajt
    private void OnDisable()
    {
        CancelInvoke();
    }
    //animacija za sprajt
    private void Animate()
    {
        frame++;

        if (frame >= sprites.Length)
        {
            frame = 0;
        }

        if (frame >= 0 && frame < sprites.Length)
        {
            spriteRenderer.sprite = sprites[frame];
        }
    }

}
