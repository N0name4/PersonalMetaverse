using UnityEngine;
using UnityEngine.UI;

public class CharacterCustomization : MonoBehaviour
{
    public SpriteRenderer characterSprite; // 캐릭터 스프라이트
    public GameObject[] accessories; // 장식 아이템 목록 (예: 모자, 망토 등)

    public void ChangeColor(Color newColor)
    {
        characterSprite.color = newColor; // 캐릭터 색상 변경
    }

    public void EquipAccessory(int index)
    {
        for (int i = 0; i < accessories.Length; i++)
        {
            accessories[i].SetActive(i == index); // 선택한 아이템만 활성화
        }
    }
}
