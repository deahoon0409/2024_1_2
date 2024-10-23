using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//PlayerState 모든 플레이어 상태의 기본이 되는 추상 클래스
public abstract class PlayerState
{
    protected PlayerStateMachine stateMachine;
    protected PlayerController playerController;
    protected PlayerAnimationManager animationManager;

    //생성자 상태 머신과 플레이어 컨트롤러 참조 초기화
    public PlayerState(PlayerStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
        this.playerController = stateMachine.PlayerController;
        this.animationManager = stateMachine.GetComponent<PlayerAnimationManager>();
    }

    public virtual void Enter() { }
    public virtual void Exit() { }
    public virtual void Update() { }
    public virtual void FixedUpdate() { }

    //상태 전환 조건을 체크하는 매서드
    protected void CheckTransitions()
    {
        if(playerController.isGrounded())
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                stateMachine.TransitionToState(new JumpingState(stateMachine));
            }
            else if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            {
                stateMachine.TransitionToState(new MovingState(stateMachine));
            }
            else
            {
                stateMachine.TransitionToState(new ldleState(stateMachine));
            }
        }
        else
        {
            if(playerController.GetVerticalVelocity() > 0)
            {
                stateMachine.TransitionToState(new JumpingState(stateMachine));
            }
            else
            {
                stateMachine.TransitionToState(new FallingState(stateMachine));
            }
        }
    }
}
public class ldleState : PlayerState
{
    public ldleState(PlayerStateMachine stateMachice) : base(stateMachice) { }

    public override void Update()
    {
        CheckTransitions();
    }
}
public class MovingState : PlayerState
{
    private bool isRunning;
    public MovingState(PlayerStateMachine stateMachice) : base(stateMachice) { }

    public override void Update()
    {
        isRunning = Input.GetKey(KeyCode.LeftShift);

        CheckTransitions();
    }
    public override void FixedUpdate()
    {
        playerController.HandleMovement();
    }
}
public class JumpingState : PlayerState
{
    public JumpingState(PlayerStateMachine stateMachice) : base(stateMachice) { }

    public override void Update()
    {
        CheckTransitions();
    }
    public override void FixedUpdate()
    {
        playerController.HandleMovement();
    }
}
public class FallingState : PlayerState
{
    public FallingState(PlayerStateMachine stateMachice) : base(stateMachice) { }

    public override void Update()
    {
        CheckTransitions();
    }
    public override void FixedUpdate()
    {
        playerController.HandleMovement();
    }
}