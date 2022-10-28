using Infrastructure;
using Services.Input;
using UnityEngine;

namespace Player
{
    public class PlayerMove : MonoBehaviour
    {
        private IInputService _inputService;   //
        private const string Jump = nameof(Jump);

        [SerializeField] private Transform _capsuleTransform;
        [SerializeField] private Transform _jumpGun;
        [SerializeField] private Transform _scope;
        [SerializeField] private Rigidbody _playerRigibody;

        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _maxSpeed;
        [SerializeField] private float _jumpSpeed;
        [SerializeField] private float _squatingSpeed;
        [SerializeField] private float _friction;
        [SerializeField] private float _rotationSpeed;

        public bool IsGround { get; private set; }
        private bool _isPaused => ProjectContext.Instance.PauseManager.IsPaused;

        private void Awake()
        {
            _inputService = Game.InputService;   //
        }

        private void Update()
        {
            if (_isPaused) return;
            Jumping();
            Squating();

            //if (_inputService.AttackIsActive)
            //{
            //}
        }

        private void FixedUpdate()
        {
            if (_isPaused) return;
            Move();
            PlayerRotate();
        }

        private void PlayerRotate()
        {
            float scopeXOffser = _scope.position.x - transform.position.x;
            float xEulerAngle = scopeXOffser > 0 ? -45f : 45f;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, xEulerAngle, 0), Time.deltaTime * _rotationSpeed);
        }

        private void Move()
        {
            Vector3 movementVector = Vector3.zero;
            float speedMultiplay = IsGround == true ? 1 : 0.1f;
            movementVector = _inputService.Axis;
            if (_playerRigibody.velocity.x > _maxSpeed && movementVector.x > Mathf.Epsilon || _playerRigibody.velocity.x < -_maxSpeed && movementVector.x < Mathf.Epsilon)
            {
                if (!IsGround)
                {
                    speedMultiplay = 0;
                }
            }

            //Vector3 relativeVelosity =

            if (IsGround)
            {
                _playerRigibody.AddForce(new Vector3(-_playerRigibody.velocity.x * _friction * speedMultiplay, 0, 0), ForceMode.VelocityChange);
            }
            _playerRigibody.AddForce(movementVector * _moveSpeed * speedMultiplay, ForceMode.VelocityChange);
        }

        public void Jumping()
        {
            if (Input.GetKeyDown(KeyCode.Space) & IsGround)
            {
                _playerRigibody.AddForce(new Vector3(0, _jumpSpeed, 0), ForceMode.VelocityChange);
            }
        }

        private void Squating()
        {
            if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.S) || !IsGround)
            {
                _capsuleTransform.localScale = Vector3.Lerp(_capsuleTransform.localScale, new Vector3(1f, 0.5f, 1f), Time.deltaTime * _squatingSpeed);
            }
            else
            {
                _capsuleTransform.localScale = Vector3.Lerp(_capsuleTransform.localScale, Vector3.one, Time.deltaTime * _squatingSpeed);
            }
        }

        private void OnCollisionStay(Collision collision)
        {
            float angle = Vector3.Angle(collision.contacts[0].normal, Vector3.up);

            if (angle < 30)
            {
                IsGround = true;
            }
        }

        private void OnCollisionExit(Collision collision)
        {
            IsGround = false;
        }
    }
}