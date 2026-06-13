using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private Animator           _animator;
    [SerializeField] private MovementController _movement;

    void Update()
    {
        _animator.SetFloat(
            "Speed",
            _movement.CurrentSpeed,
            0.1f,
            Time.deltaTime);
    }
}