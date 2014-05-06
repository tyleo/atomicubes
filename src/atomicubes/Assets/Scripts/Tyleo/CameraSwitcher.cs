using UnityEngine;

namespace Tyleo
{
    /// <summary>
    /// Allows linear switching between cameras in a sequence using the left and right arrows.
    /// </summary>
    public sealed class CameraSwitcher :
        MonoBehaviour
    {
        /// <summary>
        /// The cameras in the sequence.
        /// </summary>
        [SerializeField]
        private Camera[] _cameras;
        /// <summary>
        /// The index of the current camera in the sequence.
        /// </summary>
        [SerializeField]
        private int _currentCamera = 0;

        private void Start()
        {
            foreach (var camera in _cameras)
            {
                camera.gameObject.SetActive(false);
            }
            _cameras[_currentCamera].gameObject.SetActive(true);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                GoToNextCamera();
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                GoToPreviousCamera();
            }
        }

        private void GoToNextCamera()
        {
            _cameras[_currentCamera].gameObject.SetActive(false);
            ++_currentCamera;
            if (_currentCamera > _cameras.Length - 1)
            {
                _currentCamera = 0;
            }
            _cameras[_currentCamera].gameObject.SetActive(true);
        }

        private void GoToPreviousCamera()
        {
            _cameras[_currentCamera].gameObject.SetActive(false);
            --_currentCamera;
            if (_currentCamera < 0)
            {
                _currentCamera = _cameras.Length - 1;
            }
            _cameras[_currentCamera].gameObject.SetActive(true);
        }
    }
}
