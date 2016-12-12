using UnityEngine;

public sealed class AnimationSpeed : MonoBehaviour
{
    [SerializeField]
    private Animator animator = null;

    [SerializeField]
    private float speed = 1.0f;

    private void Start()
    {
        this.animator.speed = this.speed;
    }
}
