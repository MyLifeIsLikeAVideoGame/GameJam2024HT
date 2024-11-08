using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public Camera mainCamera; // Camera to shake
    public float shakeDuration = 0f; // How long the shake lasts
    public float shakeMagnitude = 0.1f; // How intense the shake is
    public float shakeFrequency = 0.1f; // Frequency of the shake

    private Vector3 originalPosition; // To store the camera's original position

    private void Start()
    {
        if (mainCamera == null)
            mainCamera = Camera.main; // Default to main camera if not set
    }

    // Call this method to start the shake
    public void TriggerShake(float duration, float magnitude)
    {
        shakeDuration = duration;
        shakeMagnitude = magnitude;
        StartCoroutine(Shake());
    }

    private IEnumerator Shake()
    {
        originalPosition = mainCamera.transform.position; // Store initial position

        while (shakeDuration > 0)
        {
            Vector3 shakeOffset = Random.insideUnitSphere * shakeMagnitude; // Generate random offset
            mainCamera.transform.position = originalPosition + shakeOffset; // Apply shake to camera

            shakeDuration -= Time.deltaTime; // Decrease shake duration

            // Add a slight delay between shakes (adjust as necessary)
            yield return new WaitForSeconds(shakeFrequency);
        }

        mainCamera.transform.position = originalPosition; // Reset camera position after shake
    }
}
