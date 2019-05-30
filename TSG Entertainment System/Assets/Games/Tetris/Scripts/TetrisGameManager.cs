using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class TetrisGameManager : MonoBehaviour {
	
	public static int score;
	public static int rowsCleared;
	private int level;
	public static int[,] blockSpace;
	
	public GUIText levelValue;
	public GUIText linesClearedValue;
	public GUIText scoreValue;
	public GUIText gameOverTitle;
	public GUIText clearLineNotification;
	
	public GameObject[] allBlockPieces;
	
	public KeyCode rotateButton;
	public KeyCode speedUpButton;
	public KeyCode leftButton;
	public KeyCode rightButton;
	public KeyCode turboButton;

	private int moveRightForRotate;
	private int moveLeftForRotate;

	public AudioSource moveAudio;
	
	private int currentIndex;
	private Vector3 move;
	private Vector3 moveRight;
	private Vector3 moveLeft;
	private System.Random randomGenerator = new System.Random();
	private GameObject[,] blockObjects;
	private GameObject currentBlock;
	private GameObject nextBlock;
	private List<int> clearedRows;
	private float time;
	private int previousLevel;
	private bool gameOver;
	bool preventSpeedUp;
	private bool preventMoveRight;
	private bool preventMoveLeft;
	private int countUpdateLoop;
	// Use this for initialization
	void Start () {
		blockSpace = new int[21,10];
		blockObjects = new GameObject[21, 10];
		for (int y = 0; y < blockSpace.GetLength(0); y++) 
		{
			for(int x = 0; x < blockSpace.GetLength(1); x++)
			{
				blockSpace[y,x] = 0;
			}
		}
		moveRightForRotate = 0;
		moveLeftForRotate = 0;
		gameOver = false;
		previousLevel = level;
		time = 0.4f;
		move = new Vector3 (0, -0.64f,0);
		moveLeft = new Vector3 (-0.64f, 0,0);
		moveRight = new Vector3 (0.64f, 0,0);
		Time.fixedDeltaTime = time;
		GameObject temp = allBlockPieces [randomGenerator.Next () % allBlockPieces.Length];
		currentBlock = (GameObject)Instantiate (temp, new Vector2 (CalculateXTransform (5), CalculateYTransform (0)), temp.transform.rotation);
		temp = allBlockPieces [randomGenerator.Next () % allBlockPieces.Length];
		nextBlock = (GameObject)Instantiate (temp, new Vector2 (2.6f, 5.5f), temp.transform.rotation);
		rowsCleared = 0;
		score = 0;
		level = 0;
		levelValue.text = level.ToString ();
		scoreValue.text = score.ToString ();
		linesClearedValue.text = rowsCleared.ToString ();
		preventSpeedUp = false;
		preventMoveRight = true;
		preventMoveLeft = true;
		countUpdateLoop = 0;
		GetComponent<AudioSource>().Play ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (!gameOver) {
			if (Input.GetKeyDown (rotateButton)) {
				Rotate ();
				moveAudio.Play ();
			}
			if(countUpdateLoop == 10)
			{

				if (Input.GetKey (speedUpButton)) {
					if (!preventSpeedUp) {
						bool doMove = ShouldMoveDown ();
						
						if (doMove) {
							currentBlock.transform.position += move;
						} 
					}
				}
				countUpdateLoop = 0;
			}
			else
			{
				countUpdateLoop++;
			}

			if (Input.GetKey (rightButton) && !Input.GetKey (leftButton)) {
				if(!preventMoveRight)
				{
					bool shouldMoveRight = ShouldMoveRight ();
					if (shouldMoveRight) {
						currentBlock.transform.position += moveRight;
					}
				}
			}
			if (Input.GetKey (leftButton) && !Input.GetKey (rightButton)) {
				if(!preventMoveLeft)
				{
					bool shouldMoveLeft = ShouldMoveLeft ();
					if (shouldMoveLeft) {
						currentBlock.transform.position += moveLeft;
					}
				}
			}

			if (Input.GetKeyDown (rightButton) && !Input.GetKey (leftButton)) {
				preventMoveLeft = true;
				bool shouldMoveRight = ShouldMoveRight ();
				if (shouldMoveRight) {
					currentBlock.transform.position += moveRight;
				}
				StartCoroutine(MoveRightTimer());
			}
			if (Input.GetKeyDown (leftButton) && !Input.GetKey (rightButton)) {
				preventMoveRight = true;
				bool shouldMoveLeft = ShouldMoveLeft ();
				if (shouldMoveLeft) {
					currentBlock.transform.position += moveLeft;
				}
				StartCoroutine(MoveLeftTimer());
			}

			if (Input.GetKeyUp (rightButton)) {
//				StartCoroutine(StopMoveRightTimer());
				StopCoroutine(MoveRightTimer());
				preventMoveRight = true;
			}
			if (Input.GetKeyUp (leftButton)) {
//				StartCoroutine(StopMoveLeftTimer());
				StopCoroutine(MoveLeftTimer());
				preventMoveLeft = true;
			}

			if (Input.GetKeyDown (speedUpButton)) {
				preventSpeedUp = false;
			}
			if (Input.GetKeyDown (turboButton)) {
				int constant = ShouldMoveDownReallyFast ();

				currentBlock.transform.position += (move * constant); 
			}
		}
	}

	IEnumerator MoveRightTimer() {
		yield return new WaitForSeconds(0.2f);
		if (Input.GetKey (rightButton)) {
			bool shouldMoveRight = ShouldMoveRight ();
			if (shouldMoveRight) {
				currentBlock.transform.position += moveRight;
			}
			yield return new WaitForSeconds(0.2f);
			if (Input.GetKey (rightButton)) 
			{
				preventMoveRight = false;
			}
		}
	}
	IEnumerator MoveLeftTimer() {
		yield return new WaitForSeconds(0.2f);
		if(Input.GetKey (leftButton)){
			bool shouldMoveLeft = ShouldMoveLeft ();
			if (shouldMoveLeft) {
				currentBlock.transform.position += moveLeft;
			}
		yield return new WaitForSeconds(0.2f);
		if(Input.GetKey (leftButton)){
			preventMoveLeft = false;
		}
		}
	}
	IEnumerator StopMoveRightTimer() {
		yield return new WaitForSeconds(0.2f);
		preventMoveRight = true;
	}
	IEnumerator StopMoveLeftTimer() {
		yield return new WaitForSeconds(0.2f);
		preventMoveLeft = true;
	}

	public void Rotate()
	{
		if (!currentBlock.name.Contains("OShapeBlock")) 
		{
			float yLocationCenter = currentBlock.transform.GetChild (1).gameObject.transform.position.y;
			float xLocationCenter = currentBlock.transform.GetChild (1).gameObject.transform.position.x;
			int yIndexCenter = CalculateYIndex (yLocationCenter);
			int xIndexCenter = CalculateXIndex (xLocationCenter);
			List<Vector2> tempTransforms = new List<Vector2>();
			for (int i = 0; i < 4; i++) 
			{
				float yLocation = currentBlock.transform.GetChild (i).gameObject.transform.position.y;
				float xLocation = currentBlock.transform.GetChild (i).gameObject.transform.position.x;
				int yIndex = CalculateYIndex (yLocation);
				int xIndex = CalculateXIndex (xLocation);
				
				int yDistance =yIndex - yIndexCenter;
				int xDistance = xIndex - xIndexCenter;
				
				int yIndexAfter = yIndex;
				int xIndexAfter = xIndex;
				if(!(xDistance == 0 && yDistance == 0))
				{
					if(xDistance == 0 || yDistance == 0)
					{
						if(xDistance == 0 && yDistance > 0)
						{
							yIndexAfter = yIndexCenter;
							xIndexAfter = xIndexCenter + yDistance;
						}
						else if(xDistance > 0 && yDistance == 0)
						{
							yIndexAfter = yIndexCenter - xDistance;
							xIndexAfter = xIndexCenter;
						}
						else if(xDistance == 0 && yDistance < 0)
						{
							yIndexAfter = yIndexCenter;
							xIndexAfter = xIndexCenter + yDistance;
						}
						else if(xDistance < 0 && yDistance == 0)
						{
							yIndexAfter = yIndexCenter - xDistance;
							xIndexAfter = xIndexCenter;
						}
					}
					else
					{
						int slope = yDistance / xDistance;
						
						if(slope < 0)
						{
							yIndexAfter = yIndexCenter + yDistance;
							xIndexAfter = xIndexCenter - xDistance;
						}
						else if(slope > 0)
						{
							yIndexAfter = yIndexCenter - yDistance;
							xIndexAfter = xIndexCenter + xDistance;
							
						}
					}
					
					if (yIndexAfter > 20) 
					{
						break;
					}
					if (xIndexAfter > 9) 
					{
						bool shouldMoveLeft = ShouldMoveLeft ();
						if (shouldMoveLeft) 
						{
							currentBlock.transform.position += moveLeft;
							Rotate ();
							break;
						}
						else
						{
							break;
						}
					}
					if (yIndexAfter < 0) 
					{
						break;
					}
					
					if (xIndexAfter < 0) 
					{
						bool shouldMoveRight = ShouldMoveRight ();
						if (shouldMoveRight)
						{
							currentBlock.transform.position += moveRight;
							Rotate ();
							break;
						}
						else
						{
							break;
						}
					}
					if (blockSpace [yIndexAfter, xIndexAfter] == 1) 
					{
						if(yIndexAfter != yIndex)
						{
							break;
						}
						else if (xIndexAfter > xIndex)
						{
							bool shouldMoveLeft = ShouldMoveLeft ();
							if (shouldMoveLeft) 
							{
								currentBlock.transform.position += moveLeft;
								Rotate ();
								break;
							}
							else
							{
								break;
							}
						}
						else if (xIndexAfter < xIndex)
						{
							bool shouldMoveRight = ShouldMoveRight ();
							if (shouldMoveRight) 
							{
								currentBlock.transform.position += moveRight;
								Rotate ();
								break;
							}
							else
							{
								break;
							}
						}
					}

				}
				tempTransforms.Add(new Vector2(CalculateXTransform(xIndexAfter), CalculateYTransform(yIndexAfter)));
			}
			if(tempTransforms.Count == 4)
			{
				for(int i = 0; i < 4; i++)
				{
					currentBlock.transform.GetChild (i).gameObject.transform.position = tempTransforms[i];
				}
			}
		}
	}

	void FixedUpdate()
	{
		if (!gameOver) {
			bool doMove = ShouldMoveDown ();
			
			if (doMove) {
				currentBlock.transform.position += move;
			} else {
				if (Input.GetKeyDown (rotateButton)) {
					Rotate ();
					moveAudio.Play();
				}
				else
				{
				for (int i = 0; i < currentBlock.transform.childCount; i++) {
					float yLocation = currentBlock.transform.GetChild (i).gameObject.transform.position.y;
					float xLocation = currentBlock.transform.GetChild (i).gameObject.transform.position.x;
					int yIndex = CalculateYIndex (yLocation);
					int xIndex = CalculateXIndex (xLocation);
					if (yIndex <= 0) {
						gameOver = true;
						break;
					}
					blockSpace [yIndex, xIndex] = 1;
					blockObjects [yIndex, xIndex] = currentBlock.transform.GetChild (i).gameObject;
					
				}
				clearedRows = new List<int> ();
				CheckRows ();
				
				if (clearedRows.Count > 0) {
					ClearRows ();
					rowsCleared += clearedRows.Count;
					level = rowsCleared / 10;
					
					if (level > previousLevel) {
						previousLevel = level;
						time -= 0.025f;
						Time.fixedDeltaTime = time;
					}
					
					if (clearedRows.Count == 1) {
						score += (40 * (level + 1));
						clearLineNotification.text = "Single";
					}
					if (clearedRows.Count == 2) {
						score += (100 * (level + 1));
						clearLineNotification.text = "Double";
					}
					if (clearedRows.Count == 3) {
						score += (300 * (level + 1));
						clearLineNotification.text = "Triple";
						
					}
					if (clearedRows.Count == 4) {
						score += (1200 * (level + 1));
						clearLineNotification.text = "Tetris";
					}
					Instantiate(clearLineNotification,clearLineNotification.transform.position,clearLineNotification.transform.rotation);
					levelValue.text = level.ToString ();
					scoreValue.text = score.ToString ();
					linesClearedValue.text = rowsCleared.ToString ();
				}
				if (gameOver) {
					Destroy (nextBlock);
					Instantiate (gameOverTitle, gameOverTitle.transform.position, gameOverTitle.transform.rotation);
					GetComponent<AudioSource>().Stop();
					StartCoroutine(GameOverTransition());
				} else {

					currentBlock = (GameObject)Instantiate (nextBlock, new Vector2 (CalculateXTransform (5), CalculateYTransform (0)), nextBlock.transform.rotation);
					Destroy (nextBlock);
					GameObject temp = allBlockPieces [randomGenerator.Next () % allBlockPieces.Length];
					nextBlock = (GameObject)Instantiate (temp, new Vector2 (2.6f, 5.5f), temp.transform.rotation);
					preventSpeedUp = true;
				}
			}
			}
		}
	}
	
	private void CheckRows()
	{	
		for (int y = 0; y < blockSpace.GetLength(0); y++) 
		{
			for(int x = 0; x < blockSpace.GetLength(1); x++)
			{
				if(blockSpace[y,x] == 0)
				{
					break;
				}
				else if(x == (blockSpace.GetLength(1) - 1))
				{
					clearedRows.Add(y);
				}
			}
		}
	}
	
	private void ClearRows()
	{
		foreach (int row in clearedRows) 
		{
			for(int x = 0; x < blockSpace.GetLength(1); x++)
			{
				blockSpace[row,x] = 0;
				if(blockObjects[row,x].transform.parent.childCount == 1)
				{
					Destroy(blockObjects[row,x].transform.parent.gameObject);
				}
				else
				{
					Destroy(blockObjects[row,x]);
				}
			}
			
			for(int y = row; y > 0; y--)
			{
				for(int x = 0; x < blockSpace.GetLength(1); x++)
				{
					blockSpace[y,x] = blockSpace[y - 1,x];
					blockObjects[y,x] = blockObjects[y -1 ,x];
					if(blockObjects[y,x] != null)
					{
						blockObjects[y,x].transform.position += move;
					}
					blockSpace[y - 1,x] = 0;
					blockObjects[y - 1,x] = null;
				}
			}
			
		}
	}
	
	private bool ShouldMoveRight()
	{
		bool doMove = true;
		for (int i = 0; i < 4; i++) 
		{
			float yLocation = currentBlock.transform.GetChild(i).gameObject.transform.position.y;
			float xLocation = currentBlock.transform.GetChild(i).gameObject.transform.position.x;
			int yIndex = CalculateYIndex(yLocation);
			int xIndex = CalculateXIndex(xLocation);
			if(xIndex + 1 > 9)
			{
				doMove = false;
				break;
			}
			if(blockSpace[yIndex,xIndex + 1] == 1)
			{
				doMove = false;
				break;
			}
		}
		return doMove;
	}
	
	private bool ShouldMoveLeft()
	{
		bool doMove = true;
		for (int i = 0; i < 4; i++) 
		{
			float yLocation = currentBlock.transform.GetChild(i).gameObject.transform.position.y;
			float xLocation = currentBlock.transform.GetChild(i).gameObject.transform.position.x;
			int yIndex = CalculateYIndex(yLocation);
			int xIndex = CalculateXIndex(xLocation);
			if(xIndex - 1 < 0)
			{
				doMove = false;
				break;
			}
			if(blockSpace[yIndex,xIndex - 1] == 1)
			{
				doMove = false;
				break;
			}
		}
		return doMove;
	}
	
	
	
	private bool ShouldMoveDown()
	{
		bool doMove = true;
		for (int i = 0; i < 4; i++) 
		{
			float yLocation = currentBlock.transform.GetChild(i).gameObject.transform.position.y;
			float xLocation = currentBlock.transform.GetChild(i).gameObject.transform.position.x;
			int yIndex = CalculateYIndex(yLocation);
			int xIndex = CalculateXIndex(xLocation);
			if(yIndex + 1 > 20)
			{
				doMove = false;
				break;
			}
			if(blockSpace[yIndex + 1,xIndex] == 1)
			{
				doMove = false;
				break;
			}
		}
		return doMove;
	}
	
	private int ShouldMoveDownReallyFast()
	{
		int limit = 20;
		for (int i = 0; i < 4; i++) {
			float yLocation = currentBlock.transform.GetChild(i).gameObject.transform.position.y;
			float xLocation = currentBlock.transform.GetChild(i).gameObject.transform.position.x;
			int yIndex = CalculateYIndex (yLocation);
			int xIndex = CalculateXIndex (xLocation);
			int blocksLeft = 20 - yIndex;
			if(blocksLeft < limit)
			{
				limit = blocksLeft;
			}
			for (int j = 1; j <= blocksLeft; j++) {

				if (yIndex + j > 20) {
					if ((j - 1) < limit && blockSpace [yIndex + j - 1, xIndex] != 1) {
						limit = j - 1;
						break;
					}
				}

				if (blockSpace [yIndex + j, xIndex] == 1) {
					if ((j - 1) < limit) { 
						limit = j - 1;
						break;
					}
				}
			}

		}
		return limit;
	}

	IEnumerator GameOverTransition() {
		yield return new WaitForSeconds(2f);
		Application.LoadLevel ("TetrisMainMenu");
	}
	
	private int CalculateXIndex(float xTransform)
	{
		int returnIndex;
		float xFloat = (xTransform + 6.72f) / 0.64f;
		returnIndex = (int)System.Math.Round(xFloat, 0);
		return returnIndex;
	}
	
	private int CalculateYIndex(float yTransform)
	{
		int returnIndex;
		float yFloat = (6.4f - yTransform) / 0.64f;
		returnIndex = (int)System.Math.Round(yFloat, 0);
		return returnIndex;
	}
	
	private float CalculateXTransform(int x)
	{
		float returnTransform;
		float xFloat = (float)x;
		returnTransform = -6.72f + (xFloat * 0.64f);
		return returnTransform;
	}
	private float CalculateYTransform(int y)
	{
		float returnTransform;
		float yFloat = (float)y;
		returnTransform = 6.4f - (yFloat * 0.64f);
		return returnTransform;
	}
}
