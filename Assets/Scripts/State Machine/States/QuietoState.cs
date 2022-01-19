using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuietoState : State
{
    protected D_QuietoState stateData;
    protected Transform quietoPosition;
    
  
    protected bool animationFinished;
    protected bool seeTarget;
    public QuietoState(Entity entity, FiniteStateMachine stateMachine, string animName, Transform QuietoPosition, D_QuietoState stateData) : base(entity, stateMachine, animName)
    {
        this.stateData = stateData;
        this.QuietoPosition = QuietPosition;
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        entity.atsm.quietoState = this;
        animationFinished = false;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public virtual void TriggerQuieto()
    {

    }
    public virtual void FinishQuieto()
    {
        animationFinished = true;
    }
}
