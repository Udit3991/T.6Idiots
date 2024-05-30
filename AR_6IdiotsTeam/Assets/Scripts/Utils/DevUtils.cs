using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;


namespace IF.Utils
{
    public class DevUtils : MonoBehaviour, InputActions.IUIActions
    {
        public LayerMask layerMask;
        public float characterVelocity = 10;
        public int targetSecond = 10;

        [SerializeField] private Button _stopButton;
        [SerializeField] private Button _resetButton;
        [SerializeField] private Button _upButton;
        [SerializeField] private Button _downButton;
        [SerializeField] private Button _leftButton;
        [SerializeField] private Button _rightButton;
        [SerializeField] private TMP_Text _countText;
        [SerializeField] private Slider _velocitySlider;
        [SerializeField] private Image _progressCircle;
        [SerializeField] private Button _progressClearButton;
        [SerializeField] private Rigidbody _rb;
        [SerializeField] private ARCameraManager _cameraManager;
        [SerializeField] private PhysicsRaycaster _physicsRaycaster;
        [SerializeField] private LineRenderer _lineRenderer;

        private Vector2 _screenPosition = new Vector2();
        private float _counts = 0;
        private InputActions _inputActions;


        private void Awake()
        {
            _inputActions = new InputActions();
            _inputActions.UI.AddCallbacks(this);
            _inputActions.Enable();

            _screenPosition = new Vector2(Screen.currentResolution.height / 2, Screen.currentResolution.width / 2);

            if (_stopButton == null) _stopButton = transform.Find("ArrowButtons/Button - Stop").GetComponent<Button>();
            if (_resetButton == null) _resetButton = transform.Find("ArrowButtons/Button - Reset").GetComponent<Button>();
            if (_upButton == null) _upButton = transform.Find("ArrowButtons/Button - Up").GetComponent<Button>();
            if (_downButton == null) _downButton = transform.Find("ArrowButtons/Button - Down").GetComponent<Button>();
            if (_leftButton == null) _leftButton = transform.Find("ArrowButtons/Button - Left").GetComponent<Button>();
            if (_rightButton == null) _rightButton = transform.Find("ArrowButtons/Button - Right").GetComponent<Button>();
            if (_countText == null) _countText = transform.Find("Text (TMP) - Counts").GetComponent<TMP_Text>();
            if (_velocitySlider == null) _velocitySlider = transform.Find("Velocity/Slider").GetComponent<Slider>();
            if (_progressCircle == null) _progressCircle = transform.Find("Circle/Progress").GetComponent<Image>();
            if (_progressClearButton == null) _progressClearButton = transform.Find("Circle/Button - Clear").GetComponent<Button>();
        }

        private void Start()
        {
            _stopButton.onClick.AddListener(() => _rb.velocity = Vector3.zero);
            Vector3 positionRigidbody = _rb.transform.position;
            _resetButton.onClick.AddListener(() =>
                {
                    _rb.transform.position = positionRigidbody;
                    _rb.velocity = Vector3.zero;
                });
            _upButton.onClick.AddListener(() => _rb.AddForce(_rb.transform.up * characterVelocity));
            _downButton.onClick.AddListener(() => _rb.AddForce(-_rb.transform.up * characterVelocity));
            _leftButton.onClick.AddListener(() => _rb.AddForce(-_rb.transform.right * characterVelocity));
            _rightButton.onClick.AddListener(() => _rb.AddForce(_rb.transform.right * characterVelocity));
            _velocitySlider.onValueChanged.AddListener((value) => characterVelocity = value);
            _progressClearButton.onClick.AddListener(() => _counts = 0);
        }

        private void Update()
        {
            PhysicalRaycast();
            _countText.text = FloatToTime(_counts);
            ProgressVisualizer(_counts);
            _lineRenderer.SetPosition(0, _cameraManager.transform.position - _cameraManager.transform.up * 0.5f);
            _lineRenderer.SetPosition(1, _cameraManager.transform.position + _cameraManager.transform.forward * 0.5f);
            _lineRenderer.SetPosition(2, _rb.position);
        }

        public void PhysicalRaycast()
        {
            if (Physics.Raycast(_cameraManager.transform.position, _cameraManager.transform.forward, float.PositiveInfinity, layerMask))
            {
                _counts += Time.deltaTime;
            }
            else
            {
                _counts -= Time.deltaTime;
            }
        }

        public string FloatToTime(float time)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"{(int)time % 60:00}:");
            sb.Append($"{time * 10000 - Mathf.Floor(time) * 10000:0000}");

            return sb.ToString();
        }

        public void ProgressVisualizer(float progressingTime)
        {
            float progress = progressingTime / targetSecond;
            if (progress <= 0) _counts = 0;
            else if (progress >= 1) _counts = targetSecond;

            _progressCircle.transform.localScale = new Vector3(progress, progress, progress);
            _progressCircle.color = new Color(1 - progress, progress, 0);
        }

        #region InputActions.IUIActions
        public void OnNavigate(InputAction.CallbackContext context)
        {
            print($"[{GetType()}({name})]: OnNavigate.");
        }

        public void OnSubmit(InputAction.CallbackContext context)
        {
            print($"[{GetType()}({name})]: OnSubmit.");
        }

        public void OnCancel(InputAction.CallbackContext context)
        {
            print($"[{GetType()}({name})]: OnCancel.");
        }

        public void OnScrollWheel(InputAction.CallbackContext context)
        {
            print($"[{GetType()}({name})]: OnScrollWheel.");
        }

        public void OnMiddleClick(InputAction.CallbackContext context)
        {
            print($"[{GetType()}({name})]: OnMiddleClick.");
        }

        public void OnRightClick(InputAction.CallbackContext context)
        {
            print($"[{GetType()}({name})]: OnRightClick.");
        }

        public void OnTrackedDevicePosition(InputAction.CallbackContext context)
        {
            print($"[{GetType()}({name})]: OnTrackedDevicePosition.");
        }

        public void OnTrackedDeviceOrientation(InputAction.CallbackContext context)
        {
            print($"[{GetType()}({name})]: OnTrackedDeviceOrientation.");
        }

        public void OnPoint(InputAction.CallbackContext context)
        {
        }
        #endregion

        private Vector2 positionStart = new Vector2();

        public void OnClick(InputAction.CallbackContext context)
        {
            // todo: 끌었을때 힘의 작용 방향 보여주기

            if (context.ReadValueAsButton())
            {
                positionStart = Mouse.current.position.ReadValue();
            }
            else
            {
                print($"[{GetType()}({name})]: start={positionStart}, end={Mouse.current.position.ReadValue()}, force={Mouse.current.position.ReadValue() - positionStart}.");
                _rb.AddForce(Mouse.current.position.ReadValue() - positionStart);
                positionStart = Vector2.zero;
            }
        }
    }
}
