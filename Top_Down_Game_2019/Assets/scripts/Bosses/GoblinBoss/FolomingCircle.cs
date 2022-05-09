using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FolomingCircle : StateMachineBehaviour
{
    [SerializeField] private bool _isCircleMove;
    [SerializeField] private Vector3 _playerPosition;

    [HideInInspector] private float _radius;
    [HideInInspector] private float _angle;
    [HideInInspector] private Vector3 _offset;
    [HideInInspector] private Vector2 _circleMove;
    [HideInInspector] private Vector2 _playerPositionWithOffset;
    [HideInInspector] private PlayerMovement _player;
    [HideInInspector] private NavMeshAgent _agent;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _agent = animator.GetComponent<NavMeshAgent>();
        _player = animator.GetComponent<GoblinBoss>().Player;
        _radius = animator.GetComponent<GoblinBoss>().Radius;
        _offset = animator.GetComponent<GoblinBoss>().Offset;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _playerPosition = _player.transform.position;
        if(_isCircleMove == false)
        {
            _playerPositionWithOffset = new Vector2 (_playerPosition.x + _offset.x, _playerPosition.y + _offset.y);
            _agent.SetDestination(_playerPositionWithOffset);
        }else
        {
            _angle += Time.deltaTime;
            var x = _playerPosition.x + Mathf.Cos (_angle) * _radius;
            var y = _playerPosition.y + Mathf.Sin (_angle) * _radius;
            _circleMove = new Vector2(x, y);
            _agent.SetDestination(_circleMove);            
        }
        Debug.Log(_playerPosition);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}
