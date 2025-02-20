using UnityEngine;
using UnityEngine.UI;

public class CharacterCustomization : MonoBehaviour
{
    public SpriteRenderer characterSprite; // ĳ���� ��������Ʈ
    public GameObject[] accessories; // ��� ������ ��� (��: ����, ���� ��)

    public void ChangeColor(Color newColor)
    {
        characterSprite.color = newColor; // ĳ���� ���� ����
    }

    public void EquipAccessory(int index)
    {
        for (int i = 0; i < accessories.Length; i++)
        {
            accessories[i].SetActive(i == index); // ������ �����۸� Ȱ��ȭ
        }
    }
}
