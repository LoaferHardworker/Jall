using System.Collections.Generic;
using UnityEngine;
using GameObjects;

public class ChunkPlacer : MonoBehaviour
{
	public Chunk[] chunkPrefabs;
	public Chunk startChunk;
	public float distancePlacing = 8;
	public int maxChunksCount = 7;
	
	private Transform _target;
	private List<Chunk> _placedChunks;
	private Chunk _last;

	private void Start()
	{
		if (Camera.main != null) _target = Camera.main.transform;
		_placedChunks = new List<Chunk>(){startChunk};
		_last = startChunk;
	}

	private void Update()
	{
		if (_target.position.x + distancePlacing >= _last.End.position.x)
			PlaceChunk();
	}

	private void PlaceChunk()
	{
		var newChunk = Instantiate(chunkPrefabs[Random.Range(0, chunkPrefabs.Length)]);
		newChunk.transform.position = _last.End.position;
		_last = newChunk;

		_placedChunks.Add(newChunk);
		
		if (_placedChunks.Count <= maxChunksCount) return;

		Destroy(_placedChunks[0].gameObject);
		_placedChunks.RemoveAt(0);
	}
}