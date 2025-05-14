# LightAndDark
TeamProject
![image](https://github.com/user-attachments/assets/6576edcf-eeef-400f-8516-2fa53988939e)


게임소개: 


==========================================================================

🧭 20조 트러블슈팅 정리 (Troubleshooting Log)

🚨 [통합 트러블슈팅 로그]

✅ [1] 캐릭터 생존 판정 오류 (김건휘)

문제점
- 하얀 캐릭터가 빛 밖으로 나가도 죽지 않음
- 검은 캐릭터와 동일한 코드 구조임에도 불구하고 현상 발생

원인 분석
- 하얀 캐릭터 코드에 FixedUpdate() 내부 if (state.IsDead) return; 조건 누락
- 상태가 Dead인 경우 이후 로직이 실행되지 않아야 하나, 해당 분기가 없어서
→ 빛 밖에서도 다음 로직 계속 실행 → 사망 트리거 무시됨

해결 방법
- FixedUpdate()에 if (state.IsDead) return; 추가
- 캐릭터 생존 체크 일관성 확보

교훈
- 상태 관리 분기 누락은 예상치 못한 행동을 초래
- 코드 리뷰 시 상태 분기 체크 루틴 일괄 확인 필수
- 피로 상태에서 코드 리뷰는 금물

✅ [2] 스코어 계산 오류 및 Init 누락 (이희민)

문제점
- 스코어 테스트 함수 호출 시 점수가 출력되지 않음
- StageData는 선언만 되고, Init로 값 주입이 빠져 있었음

원인 분석
- StageData stageData; 선언 후 Init 미호출 → Null 참조
- SceneTransitionHandler에서도 Init 호출 누락 확인됨 (잠재적 오류 선제 발견)

해결 방법
- 모든 StageData 사용하는 곳에서 Init 호출 확실히 처리
- SceneTransitionHandler에도 Init 호출 적용하여 오류 예방

교훈
- 선언만으로 끝나는 것이 아닌, 초기화까지 검증하는 습관 필요
- Init 패턴 사용 시 초기화 체크 리스트화 추천

✅ [3] 퍼즐 스위치 → 퍼즐 게이트 연동 오류 (조현성)

문제점
- Light 스위치만 켜도 퍼즐 게이트가 열림
- Dark 스위치 조건 무시
- GateTestCaller.cs 테스트 코드 존재로 스페이스바 입력 시 강제 열림

시도한 해결
- TriggerType enum 도입 → 문자열 비교 제거
- PuzzleGateController에 requiredTriggers, triggerStates 도입
- 상태 Enum 기반 수동 판정
- PuzzleSystem에 shouldAffectGates 추가 → 퍼즐 외부 영향 차단

결과
- Light & Dark 스위치 모두 충족 시 정상적으로 게이트 열림
- 테스트 코드 제거하여 외부 입력 차단 완료

향후 개선 방향
- 스위치 상태 관리 → ScriptableObject 또는 퍼즐 매니저에서 일괄 관리 리팩토링
- 다중 게이트/스위치 대응 → PuzzleStage 단위로 설계 확장

교훈
- 테스트 코드 제거 중요성
- 조건 분기 복잡해질수록 상태 Enum, Dictionary 기반 관리 필수
- 초기 설계 시 다중 스위치, 다중 게이트 대응 고려
