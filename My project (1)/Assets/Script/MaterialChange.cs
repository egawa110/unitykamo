using UnityEngine;

public class MaterialChange : MonoBehaviour
{
    [SerializeField]
    MeshRenderer meshRenderer;
    [SerializeField]
    string targetPropertyName = "_BaseColor";
    [SerializeField]
    Color targetColor = Color.white;

    int targetPropertyId;
    Material targetMaterial;

    void Start()
    {
        // プロパティ名→IDに変換（高速化）
        targetPropertyId = Shader.PropertyToID(targetPropertyName);

        // メッシュレンダラーからマテリアルを取得
        targetMaterial = meshRenderer.material;
    }

    public void ChangeValue()
    {
        // 色変更
        targetMaterial.SetColor(targetPropertyId, targetColor);
    }
}
