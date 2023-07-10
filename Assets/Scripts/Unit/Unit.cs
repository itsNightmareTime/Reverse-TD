using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public static Action<Unit> OnEndReached;
    
    [SerializeField] private float moveSpeed = 3f;

    /// <summary>
    /// Move speed of unit
    /// </summary>
    public float MoveSpeed { get; set; }
    
    /// <summary>
    /// The waypoint reference
    /// </summary>
    public Waypoint Waypoint { get; set; }
    
    /// <summary>
    /// Returns the current Point Position where this unit needs to go
    /// </summary>
    public Vector3 CurrentPointPosition => Waypoint.GetWaypointPosition(_currentWaypointIndex);
    
    private int _currentWaypointIndex;
    private Vector3 _lastPointPosition;
    
    private UnitHealth _unitHealth;
    private SpriteRenderer _spriteRenderer;
    
    private void Start()
    {
        _unitHealth = GetComponent<UnitHealth>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        
        _currentWaypointIndex = 0;
        MoveSpeed = moveSpeed;
        _lastPointPosition = transform.position;
    }

    private void Update()
    {
        Move();
        Rotate();
        
        if (CurrentPointPositionReached())
        {
            UpdateCurrentPointIndex();
        }
    }
    
    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, 
            CurrentPointPosition, MoveSpeed * Time.deltaTime);
    }

    public void StopMovement()
    {
        MoveSpeed = 0f;
    }

    public void ResumeMovement()
    {
        MoveSpeed = moveSpeed;
    }

    private void Rotate()
    {
        if (CurrentPointPosition.x > _lastPointPosition.x)
        {
            _spriteRenderer.flipX = false;
        }
        else
        {
            _spriteRenderer.flipX = true;
        }
    }
    
    private bool CurrentPointPositionReached()
    {
        float distanceToNextPointPosition = (transform.position - CurrentPointPosition).magnitude;
        if (distanceToNextPointPosition < 0.1f)
        {
            _lastPointPosition = transform.position;
            return true;
        }

        return false;
    }

    private void UpdateCurrentPointIndex()
    {
        int lastWaypointIndex = Waypoint.Points.Length - 1;
        if (_currentWaypointIndex < lastWaypointIndex)
        {
            _currentWaypointIndex++;
        }
        else
        {
            EndPointReached();
        }
    }

    private void EndPointReached()
    {
        OnEndReached?.Invoke(this);
        _unitHealth.ResetHealth();
        ObjectPooler.ReturnToPool(gameObject);
    }

    public void ResetUnit()
    {
        _currentWaypointIndex = 0;
    }
}
