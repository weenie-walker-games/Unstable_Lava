using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace WeenieWalker
{
    public class MovingPlatform : InteractedItems
    {
        [SerializeField] protected List<Transform> _waypoints = new List<Transform>();
        [Tooltip("The time to wait at each waypoint before moving to the next one")]
        [SerializeField] protected float _waitTimeAtLocation = 2f;
        [Tooltip("The time it takes the platform to reach the next location")]
        [SerializeField] protected float _moveTime = 3f;

        private int _currentWaypoint = 0;
        private int _nextWaypoint = 1;
        private bool _isRunning = false;
        private WaitForSeconds _waitTimeYield;
        private WaitForEndOfFrame _waitEOFYield = new WaitForEndOfFrame();

        private void Start()
        {
            //Turn off all the renderers used in debugging
            _waypoints.ForEach(t => { t.TryGetComponent<Renderer>(out Renderer rend); rend.enabled = false; });

            _waitTimeYield = new WaitForSeconds(_waitTimeAtLocation);
        }

        public override void Interact()
        {
            
        }

        public override void Reset()
        {
            transform.position = _waypoints[0].position;
            transform.rotation = _waypoints[0].rotation;

        }

        IEnumerator LerpToPosition(Vector3 moveToStart, Vector3 moveToEnd, float timeToTake)
        {
            float elapsedTime = 0;

            while(elapsedTime < timeToTake)
            {
                transform.position = Vector3.Lerp(moveToStart, moveToEnd, elapsedTime/timeToTake);
                elapsedTime += Time.deltaTime;
            }

            //reached destination so update waypoints
            _nextWaypoint = ReturnWaypointID(_nextWaypoint + 1);
            _currentWaypoint = ReturnWaypointID(_currentWaypoint + 1);

            yield return _waitTimeYield;

            MoveToNextPosition();
        }

        private void MoveToNextPosition()
        {
            StartCoroutine(LerpToPosition(_waypoints[_currentWaypoint].position, _waypoints[_nextWaypoint].position, _moveTime));
        }

        private int ReturnWaypointID(int toTest)
        {
            return (toTest % _waypoints.Count);
        }

        private void OnDrawGizmos()
        {
            for (int i = 0; i < _waypoints.Count; i++)
            {
                Gizmos.color = Color.yellow;
                int q = (i + 1) % _waypoints.Count; 
                Gizmos.DrawLine(_waypoints[i].position, _waypoints[q].position);
            }
        }
    }
}
