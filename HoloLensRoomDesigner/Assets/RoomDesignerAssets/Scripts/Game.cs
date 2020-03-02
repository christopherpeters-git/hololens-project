using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.Experimental.Utilities;
using UnityEngine;

[Serializable]
public class Game
{
   private PlayerBehaviour _player;
   private WorldAnchorManager _manager;
   
   public Game(PlayerBehaviour player, WorldAnchorManager manager)
   {
      _player = player;
      _manager = manager;
   }
}
