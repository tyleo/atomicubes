using System.Linq;
using UnityEngine;

namespace Tyleo
{
    public sealed class CameraSwitcher :
        MonoBehaviour
    {
        [SerializeField]
        private Camera[] _cameras;
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
                _cameras[_currentCamera].gameObject.SetActive(false);
                ++_currentCamera;
                if (_currentCamera > _cameras.Length - 1)
                {
                    _currentCamera = 0;
                }
                _cameras[_currentCamera].gameObject.SetActive(true);
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
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
}
