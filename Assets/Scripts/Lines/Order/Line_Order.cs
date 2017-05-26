﻿using UnityEngine;
using System.Collections;

public class Line_Order : Line
{
    BlockManager_Order block_manager;
    bool crossed = false;
    public int line_spawn_number;
    public float prev_edge;

    public override void InitLine()
    {
        block_manager = GetComponent<BlockManager_Order>();
        line_spawn_number = SpawnWaves.spawn.GetLineSpawnedNumber();
        crossed = false;
        prev_edge = SpawnWaves.spawn.prev_edge;
        base.InitLine();
    }

    protected override void CheckIfPassed()
    {
        //если линия активна, то она в любом случае не проходит
        //событие LinePassed вызывается в BlockManager
        Ball.ball.LinePassed(Color.black);
        
    }

    protected override void CheckIfCrossed()
    {
        base.CheckIfCrossed();

        float deceleration = 0.0f;
        PoolType pool_type = GetComponent<PoolRef>().GetPool().pool_type;
        switch (pool_type)
        {
            case (PoolType.Combo_3_parts):
                deceleration = GameController.game_controller.GetLvlData().combo_prop_3_parts.slowing;
                break;
            case (PoolType.Combo_4_parts):
                deceleration = GameController.game_controller.GetLvlData().combo_prop_4_parts.slowing;
                break;
            case (PoolType.Combo_5_parts):
                deceleration = GameController.game_controller.GetLvlData().combo_prop_5_parts.slowing;
                break;
        }
        //if ((active) && (GameController.game_controller.GetLinesPassedNumber() == line_spawn_number - 1) && (!crossed))
        //{
        //    BallMove.ball_move.SlowDown(deceleration);
        //    crossed = true;
        //}
        if ((active) && (Ball.ball.tran.position.y > prev_edge) && (!crossed))
        {
            BallMove.ball_move.SlowDown(deceleration);
            EventManager.TriggerEvent("BallColorChanged");
            crossed = true;
        }
    }

    public override void ChangeColor()
    {
        //StartCoroutine(block_manager.SetRandomColors());
        block_manager.InitBlocks();
    }
}
