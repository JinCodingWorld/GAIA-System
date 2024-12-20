# GAIA-System

1. 게임소개 : 현실의 나를 가상환경의 도움으로 레벨업하는 GPS기반 AR게임
2. 제작기간 : 24.09.30 ~ 24.10.11
3. 플레이 영상 : [유튜브 링크](https://youtu.be/wEdPmabE-dA)
4. 개발과정
    - LocationService 클래스의 변수와 함수들을 활용하여 위도, 경도를 불러와 실시간 위치를 화면에 출력하였습니다.
    - Firebase의 실시간 데이터 베이스와 Authentication API서비스를 통해 사용자가 DB에 입력된 특정 장소와 일정 거리 이내에 있으면 해당 UI를 띄우는 기능과 시작 시 로그인 인증 기능을 도입하였습니다. 
    - Google Cloud TTS API 서비스를 활용하여 상태창의 글들을 음성으로 전환하여 출력하였습니다.
5. 도전과제 및 해결과정
    - 손동작으로 3D 객체를 이동하고 움직이는 기능을 도입하고 싶어 ManoMotion SDK를 활용하여 캐릭터를 생성, 위치 이동, 회전 그리고 삭제하는 상호작용을 구현하였습니다. 
    - 공식 사이트에 묘사한 손동작을 모두 활용해 보려고 하였으나 실제로 사용해보니 인식이 잘 되지 않는 특정 손동작(Swip, Drop)이 있는 것을 알게 되었고 장소에 따라 손의 깊이 추적 상태가 상이한 것을 배웠습니다
---
## 게임 이미지
![Image Sequence_003_0030](https://github.com/user-attachments/assets/f9f96f39-9363-4d53-88eb-b74581587532)
![KakaoTalk_20241017_203545463_04](https://github.com/user-attachments/assets/7ac8fe53-dddb-4860-9389-f4201ddf929b)
![KakaoTalk_20241017_203545463_03](https://github.com/user-attachments/assets/23b1e5db-81fb-4f31-8c31-0608057a1cb5)
![KakaoTalk_20241017_203545463_05](https://github.com/user-attachments/assets/21124e3a-ec43-4e3e-a81c-6103b7dc17c6)

