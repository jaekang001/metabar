using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cocktailingredients : MonoBehaviour
{
   
    public GameObject cocktailingredientslObject; // 활성화시킬 자식 객체의 참조를 저장할 변수
    public GameObject[] liquid;
    private int count=0;

    void Start()
    {
        cocktailingredientslObject.SetActive(false);
        
    }

    public void OnButtonClick()
    {
        // 버튼이 클릭되었을 때 호출되는 메서드

        // 자식 객체를 활성화
        
        count += 1;
        Debug.Log("버튼 눌림");

          

        if(count %2 != 0){
            cocktailingredientslObject.SetActive(true);
        }
        else{
            cocktailingredientslObject.SetActive(false);
        }
        
    }

    public void liquidCheck()//시작버튼 눌릴때 맞는 재료를 선택했는지 확인
    {
        
           if(liquid[0].activeSelf ==true && liquid[1].activeSelf ==true
               && liquid[2].activeSelf ==true && liquid[3].activeSelf ==true)
           {
              Debug.Log("금산주 성공, 다음페이지");
           }
           else
           {
            Debug.Log("실패, 다시해보세요");
           }


        }

    }



    
