// creator Isaac Bustad
// created 3/26/2021


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallServices : ServeCMD
{
    public override void Service(GameObject aCli)
    {
        Thrower cliThrower = aCli.GetComponent<Thrower>();
        if (cliThrower != null)
        {
            cliThrower.ballOBJ = this.gameObject;
            this.gameObject.GetComponent<Ball>().ballLayer = cliThrower.ballLayer;
        }
    }
}
