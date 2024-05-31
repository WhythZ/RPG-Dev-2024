using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeStunnedState : EnemyState
{
    private Slime slime;

    public SlimeStunnedState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, Slime _slime) : base(_enemyBase, _stateMachine, _animBoolName)
    {
        this.slime = _slime;
    }

    public override void Enter()
    {
        base.Enter();

        //赋予计时器眩晕时间
        stateTimer = slime.stunnedDuration;

        //调用一次这个函数即可让RedBlink函数一直被Invoke调用；第二个参数代表延迟（delay）多久后第一次执行这个函数，第三个是函数释放间隔
        slime.fx.InvokeRepeating("RedBlink", 0, 0.1f);
    }

    public override void Exit()
    {
        base.Exit();

        //离开时取消红色闪光；第二个参数是零延迟调用此函数的意思
        slime.fx.Invoke("CancelRedBlink", 0);
    }

    public override void Update()
    {
        base.Update();

        //被弹反的时候实际上被玩家攻击到了，会触发knockback，其此时的位移十分诡异，这样设置的话就变成正常的抛物线轨迹了，哈哈，不懂
        slime.SetVelocity(0, 0);

        //眩晕结束后进入idle
        if (stateTimer < 0)
            slime.stateMachine.ChangeState(slime.idleState);
    }
}
