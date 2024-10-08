using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//플레이어의 상태를 관리
public class PlayerStateMachine : MonoBehaviour
{
    public PlayerState currentState;
    public PlayerController PlayerController;

    private void Awake()
    {
        PlayerController = GetComponent<PlayerController>();
    }
    void Start()
    {
        TransitionToState(new ldleState(this));
    }
    void Update()
    {
        if(currentState != null)
        {
            currentState.Update();
        }
    }
    private void FixedUpdate()
    {
        if (currentState != null)
        {
            currentState.FixedUpdate();
        }
    }

    public void TransitionToState(PlayerState newstate)
    {
        currentState?.Exit();

        currentState = newstate;

        currentState.Enter();

        Debug.Log($"상태 전환 되는 스테이트 : {newstate.GetType().Name}");
    }
}
