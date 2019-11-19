using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    private enum LadderPart { all, lower, top };
    [SerializeField] LadderPart part = LadderPart.all;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Playercontrols>())
        {
            Playercontrols player = collision.GetComponent<Playercontrols>();
            switch (part)
            {
                case LadderPart.all:
                    player.canClimb = true;
                    player.ladder = this;
                    break;

                case LadderPart.lower:
                    player.lowerLadder = true;
                    break;

                case LadderPart.top:
                    player.topLadder = true;
                    break;

                default:

                    break;
            }
        }


    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Playercontrols>())
        {
            Playercontrols player = collision.GetComponent<Playercontrols>();
            switch (part)
            {
                case LadderPart.all:
                    player.canClimb = false;
                    break;

                case LadderPart.lower:
                    player.lowerLadder = false
                        ;
                    break;

                case LadderPart.top:
                    player.topLadder = false;
                    break;

                default:

                    break;
            }

        }
    }
}