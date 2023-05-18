
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class randomtext : MonoBehaviour
{
    string[] strings = { "드라이 마티니", "네그로니", "싱가폴 슬링", "진 피즈", "맨해튼","러스트 네일","올드 패션즈",
        "뉴욕","위스키샤워","브랜디 알렉산더","사이드카","허니문","푸스 카페 레인보우","B-52","마가리타","데킬라 선라이즈"
         ,"준 벅","그래스호퍼","애프리콧 칵테일","키르","블랙 러시안","시브리즈","애플 마티니","롱 아일랜드 아이스 티",
        "코스모폴리탄","모스코 뮬","다이키리","바카디","쿠바 리브레","마이타이","피나 콜라다","블루 하와이안","힐링","진도"
            ,"풋사랑","금산","고창","프레시 레몬 스쿼시","버진 프루트 펀치" };
    public Text name1, name2, name3;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < strings.Length; i++)
        {
            string name;
            do
            {
                name = strings[Random.Range(0, strings.Length)];
            } while (name == name1.text || name == name2.text || name == name3.text);
            switch (i)
            {
                case 0:
                    name1.text = "A. "+name;
                    
                    break;
                case 1:
                    name2.text = "B. "+name;
                    
                    break;
                case 2:
                    name3.text = "C. "+name;
                    
                    break;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
