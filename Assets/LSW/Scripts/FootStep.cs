using UnityEngine;

public class FootStep : MonoBehaviour
{
    public AudioClip[] footstepClips;
    private AudioSource audioSource;
    private Rigidbody _rigidbody;
    public float footstepThreshold;
    public float footstepRate;
    private float footStepTime;
    public int lastClipIndex;


    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Mathf.Abs(_rigidbody.velocity.y) < 0.1f)
        {
            if (_rigidbody.velocity.magnitude > footstepThreshold)
            {
                if (Time.time - footStepTime > footstepRate)
                {
                    footStepTime = Time.time;
                    lastClipIndex = (lastClipIndex + 1) % footstepClips.Length;
                    audioSource.PlayOneShot(footstepClips[lastClipIndex]);
                }
            }
        }
    }

    public void SetFootstepRateMultiplier(float multiplier)
    {
        footstepRate /= multiplier;
    }

    public void ResetFootstepRate(float originalRate)
    {
        footstepRate = originalRate;
    }
}