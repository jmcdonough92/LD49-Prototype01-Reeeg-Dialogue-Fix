using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject shot;

    public void ShootUp(int numShots)
    {
        switch (numShots)
        {
            case 1:
                Instantiate(shot, transform.position, Quaternion.identity);
                break;
            case 2:
                Instantiate(shot, transform.position, Quaternion.AngleAxis(-7.5f, transform.forward));
                Instantiate(shot, transform.position, Quaternion.AngleAxis(7.5f, transform.forward));
                break;
            case 3:
                Instantiate(shot, transform.position, Quaternion.identity);
                Instantiate(shot, transform.position, Quaternion.AngleAxis(15, transform.forward));
                Instantiate(shot, transform.position, Quaternion.AngleAxis(-15, transform.forward));
                break;
            case 4:
                Instantiate(shot, transform.position, Quaternion.AngleAxis(-7.5f, transform.forward));
                Instantiate(shot, transform.position, Quaternion.AngleAxis(7.5f, transform.forward));
                Instantiate(shot, transform.position, Quaternion.AngleAxis(-22.5f, transform.forward));
                Instantiate(shot, transform.position, Quaternion.AngleAxis(22.5f, transform.forward));
                break;
            case 5:
                Instantiate(shot, transform.position, Quaternion.identity);
                Instantiate(shot, transform.position, Quaternion.AngleAxis(15, transform.forward));
                Instantiate(shot, transform.position, Quaternion.AngleAxis(-15, transform.forward));
                Instantiate(shot, transform.position, Quaternion.AngleAxis(30, transform.forward));
                Instantiate(shot, transform.position, Quaternion.AngleAxis(-30, transform.forward));
                break;
            default:
                if (numShots < 1)
                {

                    Instantiate(shot, transform.position, Quaternion.identity);
                }
                else
                {

                    Instantiate(shot, transform.position, Quaternion.identity);
                    Instantiate(shot, transform.position, Quaternion.AngleAxis(15, transform.forward));
                    Instantiate(shot, transform.position, Quaternion.AngleAxis(-15, transform.forward));
                    Instantiate(shot, transform.position, Quaternion.AngleAxis(30, transform.forward));
                    Instantiate(shot, transform.position, Quaternion.AngleAxis(-30, transform.forward));
                }
                break;
        }
    }

    public void ShootDown(int numShots)
    {
        switch (numShots)
        {
            case 1:
                Instantiate(shot, transform.position, Quaternion.AngleAxis(180,transform.forward));
                break;
            case 2:
                Instantiate(shot, transform.position, Quaternion.AngleAxis(187.5f, transform.forward));
                Instantiate(shot, transform.position, Quaternion.AngleAxis(172.5f, transform.forward));
                break;
            case 3:
                Instantiate(shot, transform.position, Quaternion.AngleAxis(180, transform.forward));
                Instantiate(shot, transform.position, Quaternion.AngleAxis(165, transform.forward));
                Instantiate(shot, transform.position, Quaternion.AngleAxis(195, transform.forward));
                break;
            case 4:
                Instantiate(shot, transform.position, Quaternion.AngleAxis(187.5f, transform.forward));
                Instantiate(shot, transform.position, Quaternion.AngleAxis(172.5f, transform.forward));
                Instantiate(shot, transform.position, Quaternion.AngleAxis(202.5f, transform.forward));
                Instantiate(shot, transform.position, Quaternion.AngleAxis(157.5f, transform.forward));
                break;
            case 5:
                Instantiate(shot, transform.position, Quaternion.AngleAxis(180, transform.forward));
                Instantiate(shot, transform.position, Quaternion.AngleAxis(165, transform.forward));
                Instantiate(shot, transform.position, Quaternion.AngleAxis(195, transform.forward));
                Instantiate(shot, transform.position, Quaternion.AngleAxis(140, transform.forward));
                Instantiate(shot, transform.position, Quaternion.AngleAxis(210, transform.forward));
                break;
            default:
                if (numShots < 1)
                {

                    Instantiate(shot, transform.position, Quaternion.AngleAxis(180, transform.forward));
                }
                else
                {
                    Instantiate(shot, transform.position, Quaternion.AngleAxis(180, transform.forward));
                    Instantiate(shot, transform.position, Quaternion.AngleAxis(165, transform.forward));
                    Instantiate(shot, transform.position, Quaternion.AngleAxis(195, transform.forward));
                    Instantiate(shot, transform.position, Quaternion.AngleAxis(140, transform.forward));
                    Instantiate(shot, transform.position, Quaternion.AngleAxis(210, transform.forward));
                }
                break;
        }
    }
}
