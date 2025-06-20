using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    [Header("Terrain")]
    public Terrain terrain;

    [Header("Liste des prefabs de rochers")]
    public GameObject[] rockPrefabs;

    [Header("Placement")]
    public int numberOfRocks = 100;
    public float minScale = 0.8f;
    public float maxScale = 1.2f;

    [Header("Filtrage par hauteur")]
    public float minHeight = 0f;
    public float maxHeight = 9999f;

    void Start()
    {
        SpawnRocks();
    }

    void SpawnRocks()
    {
        if (terrain == null || rockPrefabs.Length == 0)
        {
            Debug.LogWarning("Terrain ou prefabs non définis !");
            return;
        }

        TerrainData terrainData = terrain.terrainData;
        Vector3 terrainPos = terrain.transform.position;

        for (int i = 0; i < numberOfRocks; i++)
        {
            // Coordonnées aléatoires dans la surface du terrain
            float x = Random.Range(0f, terrainData.size.x);
            float z = Random.Range(0f, terrainData.size.z);
            float y = terrain.SampleHeight(new Vector3(x, 0, z)) + terrainPos.y;

            if (y < minHeight || y > maxHeight)
                continue;

            Vector3 position = new Vector3(x + terrainPos.x, y, z + terrainPos.z);

            // Choisir un prefab au hasard
            GameObject prefab = rockPrefabs[Random.Range(0, rockPrefabs.Length)];

            // Instancier
            GameObject rock = Instantiate(prefab, position, Quaternion.identity, transform);

            // Aligner à la pente
            Vector3 normal = terrainData.GetInterpolatedNormal(x / terrainData.size.x, z / terrainData.size.z);
            rock.transform.rotation = Quaternion.FromToRotation(Vector3.up, normal);

            // Random scale
            float scale = Random.Range(minScale, maxScale);
            rock.transform.localScale = Vector3.one * scale;

            // Ajouter un collider si nécessaire
            if (rock.GetComponent<Collider>() == null)
            {
                rock.AddComponent<MeshCollider>();
            }
        }
    }
}
