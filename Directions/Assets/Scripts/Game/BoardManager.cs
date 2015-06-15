using UnityEngine;
using System.Collections;

public class BoardManager : MonoBehaviour {

    [SerializeField]
    public class BoardSize
    {
        public int Maximun;
        public int Minimun;

        public BoardSize(int min, int max)
        {
            Minimun = min;
            Maximun = max;
        }
    }

    GameManager gManager;
    
	void Start () {
        gManager = GameManager.Instance;
	}
	
	void Update () {
	
	}
}
