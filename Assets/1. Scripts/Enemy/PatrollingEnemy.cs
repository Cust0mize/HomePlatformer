using UnityEngine;
using UnityEngine.Events;

public enum Direction
{
    Left,
    Right
}

public class PatrollingEnemy : Enemy
{
    [SerializeField] private Direction _currentDirection;
    [SerializeField] private UnityEvent _left;
    [SerializeField] private UnityEvent _right;
    [SerializeField] private Transform _rayStart;

    protected virtual Vector3 MoveToPoints(Vector3 transformPosition, Transform leftPoint, Transform right, float speedMove)
    {
        CheckPosition(transformPosition, leftPoint, right);

        if (_currentDirection == Direction.Left)
        {
            transformPosition -= new Vector3(Time.deltaTime * speedMove, 0);
        }
        else
        {
            transformPosition += new Vector3(Time.deltaTime * speedMove, 0);
        }
        return transformPosition;
    }

    protected Vector3 ProjectoryToGround(Vector3 transformPosition)
    {
        RaycastHit hit;
        if (Physics.Raycast(_rayStart.position, Vector3.down, out hit))
        {
            transformPosition = hit.point;
        }
        return transformPosition;
    }

    protected Quaternion RotateToTargetPoint(Quaternion transfromRotation, Vector3 targetEuler, float rightEuler, float leftEuler, float speedRotate)
    {
        if (_currentDirection == Direction.Left)
        {
            targetEuler.y = rightEuler;
            _left?.Invoke();
        }
        else
        {
            targetEuler.y = leftEuler;
            _right?.Invoke();
        }
        return Quaternion.Lerp(transform.rotation, Quaternion.Euler(targetEuler), speedRotate * Time.deltaTime);
    }

    private void CheckPosition(Vector3 transformPosition, Transform leftPoint, Transform right)
    {
        if (transformPosition.x <= leftPoint.position.x)
        {
            _currentDirection = Direction.Right;
        }
        else if (transformPosition.x >= right.position.x)
        {
            _currentDirection = Direction.Left;
        }
    }

    public void DisableParent(ref Transform pointA, ref Transform pointB)
    {
        pointA.SetParent(null);
        pointB.SetParent(null);
    }
}
