﻿﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MobileInput : MonoBehaviour
{
    public JoyStick joyStick;
    public FixedTouchField TouchField;

    void Update()
    {
        var fps = GetComponent<CharacterControl>();
        fps.RunAxis = joyStick.InputDirection;
        fps.LookAxis = TouchField.TouchDist;
    }
}