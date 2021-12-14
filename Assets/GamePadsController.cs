using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePadsController : Singleton<GamePadsController>
{
    public bool isOnMobile;
    bool canMoveLeft;
    bool canMoveRight;

    public bool CanMoveLeft { get => canMoveLeft; set => canMoveLeft = value; }
    public bool CanMoveRight { get => canMoveRight; set => canMoveRight = value; }

    void PCHandle()
    {
        canMoveLeft = Input.GetAxisRaw("Horizontal") < 0;
        canMoveRight = Input.GetAxisRaw("Horizontal") > 0;
    }
    private void FixedUpdate()
    {
        if (!isOnMobile)
            PCHandle();
    }
}
