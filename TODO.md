# TODO: Implement Lane-Based Swipe Movement with Mathf.Lerp

- [x] Add new variables: int currentLane, float[] laneYs, float targetY, float lerpSpeed, Vector2 startPos, bool isSwiping
- [x] Modify Start(): Initialize currentLane = 1, targetY = laneYs[currentLane]
- [x] Modify Update(): Implement swipe detection using mouse input to change lanes
- [x] Modify FixedUpdate(): Use rb.MovePosition with Mathf.Lerp for smooth lane transitions, remove old velocity logic
- [x] Remove old variables: playerDirection, and old input logic in Update()
