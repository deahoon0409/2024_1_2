using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructibleBuilding : MonoBehaviour
{
    [Header("Building Seetings")]
    public BuildingType buildingType;
    public string buildingName;
    public int requiredTree = 5;
    public float constructionTime = 2.0f;

    public bool canBuild = true;
    public bool isConstructed = false;

    private Material buildingMatreial;
    // Start is called before the first frame update
    void Start()
    {
        buildingMatreial = GetComponent<MeshRenderer>().material;

        Color color = buildingMatreial.color;
        color.a = 0.5f;
        buildingMatreial.color = color;
    }

    public void StartConstruction(PlayerInventory inventory)
    {
        if (!canBuild || isConstructed) return;

        if (inventory.treeCount >= requiredTree)
        {
            inventory.Removeitme(ItemType.Tree, requiredTree);
            if (FloatingTextManager.instance != null)
            {
                FloatingTextManager.instance.Show($"{buildingName} 건설 시작!", transform.position + Vector3.up);
            }
            StartCoroutine(CostructionRoutine());
        }
        else
        {
            if (FloatingTextManager.instance != null)
            {
                FloatingTextManager.instance.Show($"나무가 부족합니다! ({inventory.treeCount} / {requiredTree})", transform.position + Vector3.up);
            }
        }
    }    


    private IEnumerator CostructionRoutine()
    {
        canBuild = false;
        float timer = 0;
        Color color = buildingMatreial.color;

        while (timer < constructionTime)
        {
            timer += Time.deltaTime;
            color.a = Mathf.Lerp(0.5f, 1f, timer / constructionTime);
            buildingMatreial.color = color;
            yield return null;
        }
        isConstructed = true;
        if(FloatingTextManager.instance != null)
        {
            FloatingTextManager.instance.Show($"{buildingName} 건설 완료!", transform.position + Vector3.up);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
