using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceSpawner : MonoBehaviour {

	public PieceType type;
	private Piece currentPiece;

	public void Spawn()
	{

		int amtobj = 0;
		switch (type)
		{
			case PieceType.jump:
				amtobj = LevelManager.Instance.jumps.Count;
				break;
			case PieceType.longBlock:
				amtobj = LevelManager.Instance.longBlocks.Count;
				break;
			case PieceType.ramp:
				amtobj = LevelManager.Instance.ramps.Count;
				break;
			case PieceType.slide:
				amtobj = LevelManager.Instance.slides.Count;
				break;

		}
	}
		public void DeSpawn()
	{
		currentPiece.gameObject.SetActive (false);
	}
}
