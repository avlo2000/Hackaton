using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
	public Transform hexPrefab;
	public Transform mountainPrefab;
	public Transform figurePrefab;

	public int gridWidth = 10;
	public int gridHeight = 10;
	public int[,] config = new int[,] {{1, 1, 0, 0, 0, 0, 0, 0, 0, 0}, 
		{0, 1, 2, 0, 0, 0, 0, 0, 0, 0}, 
		{0, 2, 0, 0, 1, 0, 0, 0, 0, 0}, 
		{1, 0, 2, 0, 1, 0, 0, 0, 0, 0}, 
		{0, 0, 0, 1, 0, 0, 0, 0, 0, 0},
		{0, 0, 0, 1, 0, 0, 0, 0, 0, 0},
		{0, 0, 0, 1, 0, 0, 0, 0, 0, 0},
		{0, 0, 0, 1, 0, 0, 0, 0, 0, 0},
		{0, 0, 0, 1, 0, 0, 0, 0, 0, 0},
		{0, 0, 0, 1, 0, 0, 0, 0, 0, 0}};

	float hexWidth = 1.732f;
	float hexHeight = 2.0f;
	public float gap = 0.0f;

	Vector3 startPos;

	void Start()
	{
		AddGap();
		CalcStartPos();
		CreateGrid();
	}

	void AddGap()
	{
		hexWidth += hexWidth * gap;
		hexHeight += hexHeight * gap;
	}

	void CalcStartPos()
	{
		float offset = 0;
		if (gridHeight / 2 % 2 != 0)
			offset = hexWidth / 2;

		float x = -hexWidth * (gridWidth / 2) - offset;
		float z = hexHeight * 0.75f * (gridHeight / 2);

		startPos = new Vector3(x, 0, z);
	}

	Vector3 CalcWorldPos(Vector2 gridPos)
	{
		float offset = 0;
		if (gridPos.y % 2 != 0)
			offset = hexWidth / 2;

		float x = startPos.x + gridPos.x * hexWidth + offset;
		float z = startPos.z - gridPos.y * hexHeight * 0.75f;

		return new Vector3(x, 0, z);
	}

	void CreateGrid()
	{
		for (int y = 0; y < gridHeight; y++)
		{
			for (int x = 0; x < gridWidth; x++)
			{
				Transform hex = Instantiate(hexPrefab) as Transform;
				Vector2 gridPos = new Vector2(x, y);
				hex.position = CalcWorldPos(gridPos);
				hex.parent = this.transform;
				hex.name = "Hexagon" + x + "|" + y;
				if (config [x, y] == 1) {
					LocateMountain(hex.position, x, y);
				} else if (config [x, y] == 2) {
					LocateFigure(hex.position, x, y);
				}
			}
		}
	}

	void LocateMountain (Vector3 hexPos, int x, int y)
	{
		Transform mountain = Instantiate (mountainPrefab) as Transform;
		mountain.position = hexPos + new Vector3 (-0.0014771f, 0.072f, -0.00022189f);
		mountain.parent = this.transform;
		mountain.name = "Mountain" + x + "|" + y;
	}

	void LocateFigure (Vector3 hexPos, int x, int y)
	{
		Transform figure = Instantiate (figurePrefab) as Transform;
		figure.position = hexPos + new Vector3 (0.0f, 0.1f, 0.0f);
		figure.parent = this.transform;
		figure.name = "Figure" + x + "|" + y;
	}
}