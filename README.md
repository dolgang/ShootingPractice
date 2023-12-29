# Unity 심화 개인 과제 - 자유 주제

</br>

## 제작자
* 황선범
</br>

## 제작 내용
3D 환경에서 회전과 관련된 부분을 연습하기 위한 연습용 과제   
1인칭 슈팅 형식으로 FPS의 사격 훈련장 같은 느낌으로 제작
</br>

## 제작 기간
* 23.12.28 ~ 23.12.29
</br>

## 주요 기능
### 완성된 기능
* 투사체 발사하기
  * 화면 중앙 에임에 맞춰서 발사지점 정렬
  * 발사된 투사체가 중력의 영향을 받게 회전
* input 약간 수정
  * 마우스 누르고 있는 동안에는 계속 무기가 발사됨
* 오브젝트 풀링 적용
  * 동적 오브젝트 풀링 및 투사체 초기화 필요 학습
</br>

### 미완성 기능
* 과녁 랜덤 생성 및 좌우이동
* 과녁 적중 시 스코어 책정 및 UI
 * 과녁에 중심점을 잡아두고 충돌 지점과의 거리를 계산하여 점수 부여

</br>

## 과제 소감
일단 어찌저찌 만들긴 했는데 회전이 많이 어려웠습니다.
회전 연습하려고 가볍게 만든거긴 한데 회전만 만들게 되었습니다.

회전에 집중하려고 코드 대부분을 재사용했는데
조작은 기존 숙련 코드를 가져와서 공격 부분만 수정하였고
오브젝트 풀링은 일단 팀과제때 만들었던 것을 가져와서 재사용했습니다.