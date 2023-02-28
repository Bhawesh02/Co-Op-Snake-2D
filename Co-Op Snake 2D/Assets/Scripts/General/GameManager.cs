using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum GameMode
{
    Solo,
    Coop
}
public class GameManager :MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get { return instance;} }

    public int xBoundry;
    public int yBoundry;

    public int playerLostId;


    public List<PlayerController> players;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


}
