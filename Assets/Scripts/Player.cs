using UnityEngine;
using System.Collections;

public class Player {
    #region Attributs privés
    private int bricks = 0;
    private int gold = 0;
    private int orbs = 0;
    #endregion

    #region Accesseurs
    public int Bricks {
        get { return bricks; }
        set { bricks = value; }
    }

    public int Gold {
        get { return gold; }
        set { gold = value; }
    }

    public int Orbs {
        get { return orbs; }
        set { orbs = value; }
    }
    #endregion

    #region Méthodes publiques
    public void AddBricks (int _bricks) {
        bricks += _bricks;
    }

    public void AddGold (int _gold) {
        gold += _gold;
    }

    public void AddOrbs (int _orbs) {
        orbs += _orbs;
    }

    public void AddResources (int _bricks, int _gold, int _orbs) {
        bricks += _bricks;
        gold += _gold;
        orbs += _orbs;
    }

    public void DropBricks (int _bricks) {
        bricks -= _bricks;

        if (bricks < 0) {
            bricks = 0;
        }
    }

    public void DropGold (int _gold) {
        gold -= _gold;

        if (gold < 0) {
            gold = 0;
        }
    }

    public void DropOrbs (int _orbs) {
        orbs -= _orbs;

        if (orbs < 0) {
            orbs = 0;
        }
    }
    #endregion
}
