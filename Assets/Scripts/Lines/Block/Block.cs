﻿using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour
{
    //Line line;

    public bool collides;
    BlockManager block_manager;
    static float collision_dist = 0.01f;

    void Start()
    {
        block_manager = GetComponentInParent<BlockManager>();
    }
    public void SetRandomColor()
    {
        GetComponent<SpriteRenderer>().color = SkinManager.skin_manager.GetCurrentSkin().colors
            [Random.Range(0, SkinManager.skin_manager.GetCurrentSkin().colors.Length)];
    }

    public void SetColor(Color color)
    {
        GetComponent<SpriteRenderer>().color = color;
    }
    void Update()
    {
        collides = CheckIfCollides();
    }

    public Color GetColor()
    {
        return GetComponent<SpriteRenderer>().color;
    }

    public bool CheckIfCollides()
    {
        //float dist;
        //dist = Mathf.Abs(Mathf.Abs(transform.position.x) - block_manager.block_size / 2.0f);
        //Debug.DrawLine(new Vector3((transform.position.x) - block_manager.block_size/2.0f, transform.position.y, 0.0f),
        //    new Vector3((transform.position.x) - block_manager.block_size/2.0f, transform.position.y-1.0f,0.0f));
        if ((transform.position.x + block_manager.block_size / 2.0f+collision_dist>=0.0f) &&
                (transform.position.x - block_manager.block_size / 2.0f - collision_dist <= 0.0f))
            return true;
        else
            return false;
        
    }
}
