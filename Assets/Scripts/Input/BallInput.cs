using UnityEngine;
using System.Collections.Generic;

public class BallInput : MonoBehaviour
{
    [SerializeField]
    private RangeCurve _powerCurve;

    [SerializeField]
    private float _maxPowerInches = 1.0f;

    private Vector3? _clickStartPos;

    private Rigidbody rigidBody;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        if (RenderCallbacks.Instance != null)
        {
            RenderCallbacks.Instance.OnPostRenderCallbacks += OnPostRender; 
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _clickStartPos = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0) && _clickStartPos.HasValue)
        {
            Vector3 screenDelta = Input.mousePosition - _clickStartPos.Value;
            Vector3 hitDir = GetHitDirection(screenDelta);
            float powerFactor = GetPowerFactor(screenDelta);

            rigidBody.AddForce(hitDir * _powerCurve.Evaluate(powerFactor));

            _clickStartPos = null;
        }
    }

    private void OnPostRender()
    {
        if (_clickStartPos.HasValue)
        {
            Vector3 screenDelta = Input.mousePosition - _clickStartPos.Value;
            float powerFactor = GetPowerFactor(screenDelta);

            GUIExtensions.DrawLine(_clickStartPos.Value, _clickStartPos.Value - screenDelta, Color.Lerp(Color.green, Color.red, powerFactor));
        }
    }

    Vector3 GetHitDirection(Vector3 screenDelta)
    {
        Transform cameraTransform = Camera.main.transform;

        Vector3 worldDir = new Vector3(screenDelta.x, 0, screenDelta.y);
        worldDir = cameraTransform.rotation * worldDir;
        worldDir.y = 0;

        worldDir.Normalize();

        return -worldDir;
    }

    float GetPowerFactor(Vector3 screenDelta)
    {
        float dragDistanceInches = ScreenExtensions.PixelsToInches(screenDelta.magnitude);
        return Mathf.Clamp01(dragDistanceInches / _maxPowerInches);
    }
}
