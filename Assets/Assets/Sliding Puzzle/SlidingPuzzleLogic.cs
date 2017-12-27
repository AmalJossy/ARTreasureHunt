using UnityEngine;
using System.Collections.Generic;

public class SlidingPuzzleLogic : MonoBehaviour
{
    public List<GameObject> tiles;

	public string nextscene;
	public string themessage;

	private int size = 3;

	[HideInInspector]
	public float z = 0.02849352f;

	[HideInInspector]
	public float delta = 0.1755742f;

	private int[,] internTiles;

	public int MoveTile(int k)
	{
		for (int i = 0; i < size; i++)
		{
			for (int j = 0; j < size; j++)
			{
				if (internTiles[i,j] == k)
				{
					// Check right
					if (j < size-1)
					{
						if (internTiles[i,j+1] == 0)
						{
							internTiles[i,j+1] = k;
							internTiles[i,j] = 0;
							return 1;
						}
					}
					// Check left
					if (j > 0)
					{
						if (internTiles[i,j-1] == 0)
						{
							internTiles[i,j-1] = k;
							internTiles[i,j] = 0;
							return -1;
						}
					}
					// Check down
					if (i < size-1)
					{
						if (internTiles[i+1,j] == 0)
						{
							internTiles[i+1,j] = k;
							internTiles[i,j] = 0;
							return 2;
						}
					}
					// Check up
					if (i > 0)
					{
						if (internTiles[i-1,j] == 0)
						{
							internTiles[i-1,j] = k;
							internTiles[i,j] = 0;
							return -2;
						}
					}
					return 0;
				}
			}
		}
		return 0;
	}

    protected void Reset()
    {
        // Not all random puzzles are solvable.
        // So we create a solved puzzle and do actual moves to end up with a random (but solvable) puzzle.
		internTiles = new int[size, size];
        int k = 1;
        for (int y = 0; y < size; y++)
        {
            for (int x = 0; x < size; x++)
            {
				internTiles[y, x] = k;
                k++;
            }
        }
		internTiles[size - 1, size - 1] = 0;
        int emptyX = size - 1;
        int emptyY = size - 1;
        
        k = 1;
        while (k < 200)
        {
            int delta = Random.Range(-1, 2);
            int dir = Random.Range(-1, 2);
            int newX, newY;
            
            if (dir == -1)
            {
                newX = emptyX + delta;
                newY = emptyY;
            }
            else
            {
                newX = emptyX;
                newY = emptyY + delta;
            }
            
            if (0 <= newX && newX < size && 0 <= newY && newY < size)
            {
				internTiles[emptyY, emptyX] = internTiles[newY, newX];
				internTiles[newY, newX] = 0;
                emptyX = newX;
                emptyY = newY;
                k = k + 1;
            }
        }
        
        // Go through all tiles and set their position according to the shuffled positions.
        int i = 0;
		for (float y = delta; y >= -delta; y = y - delta)
        {
            int j = 0;
			for (float x = delta; x >= -delta; x = x - delta)
            {
				k = internTiles[i, j];
                if (k < size * size)
                {
					if (k != 0)
					{
						tiles[k - 1].transform.localPosition = new Vector3(x, y, z);
						//tiles[k - 1].GetComponent<TileMovement>().Activate(); I have a bad feeling about this
					}
					j = j + 1;
                }
            }
			i = i + 1;
        }
    }

    protected bool CheckIfSolved()
    {
		bool solved = true;
		
		int k = 1;
		for (int i = 0; i < size; i++)
		{
			for (int j = 0; j < size; j++)
			{
				if (k < size*size)
				{
					if (internTiles[i, j] != k)
					{
						solved = false;
					}
				}
				k = k + 1;
			}
		}

		return solved;
    }

	void Start(){
		Reset ();
	}
	void Update(){
		if (CheckIfSolved ()) {
			PlayerPrefs.SetString ("last", nextscene);
			PlayerPrefs.SetString (nextscene, themessage + " : ");
			updatetime ();
			PlayerPrefs.Save ();
			UnityEngine.SceneManagement.SceneManager.LoadScene (nextscene);
		}
	}
	void updatetime(){
		string str = nextscene + "_time";
		PlayerPrefs.SetString (str, System.DateTime.Now.ToString ());	

	}
}