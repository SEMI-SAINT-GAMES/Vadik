using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [Tooltip("Animator for the Short Character")]
    [SerializeField]
    private Animator shortCharacterAnimator;

    [Tooltip("Animator for the Medium Character")]
    [SerializeField]
    private Animator mediumCharacterAnimator;

    [Tooltip("Animator for the Tall Character")]
    [SerializeField]
    private Animator tallCharacterAnimator;

    public void ChangeAnimation(int animation)
    {
        var animationType = (Animation)animation;
        shortCharacterAnimator.SetTrigger(animationType.ToString());
        mediumCharacterAnimator.SetTrigger(animationType.ToString());
        tallCharacterAnimator.SetTrigger(animationType.ToString());
    }

    private enum Animation
    {
        Idle,
        Walking,
        Running,
        Jumping,
        Climbing,
        Swimming
    }
}