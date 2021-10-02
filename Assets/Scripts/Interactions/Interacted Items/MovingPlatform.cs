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
        [SerializeField] GameObject _floatingPlatform;

        private int _currentWaypoint = 0;
        private int _nextWaypoint = 1;
        private bool _isRunning = false;
        private bool _isResetting = true;
        private WaitForSeconds _waitTimeYield;
        private WaitForEndOfFrame _waitEOFYield = new WaitForEndOfFrame();
        private Coroutine _moveRoutine;
        [SerializeField] private Player _player;

        private void Start()
        {
            //Turn off all the renderers used in debugging
            _waypoints.ForEach(t => { t.TryGetComponent<Renderer>(out Renderer rend); rend.enabled = false; });

            _waitTimeYield = new WaitForSeconds(_waitTimeAtLocation);

            Reset();
        }

        public override void Interact()
        {

            if (_isRunning)
            {
                _isRunning = false;
                if(_moveRoutine != null)
                   StopCoroutine(_moveRoutine);
            }
            else
            {
                _isRunning = true;
                Invoke("MoveToNextPosition", 1f);
            }

        }

        public override void Reset()
        {
            if (_moveRoutine != null)
                StopCoroutine(_moveRoutine);

            _isRunning = false;

            if (_isResetting)
            {
                _floatingPlatform.transform.position = _waypoints[0].position;
                _currentWaypoint = 0;
                _nextWaypoint = ReturnWaypointID(_currentWaypoint + 1);
            }
        }


        private void MoveToNextPosition()
        {
            if (_isRunning)
                _moveRoutine = StartCoroutine(LerpToPosition(_floatingPlatform.transform.position, _waypoints[_nextWaypoint].position, _moveTime));
        }

        IEnumerator LerpToPosition(Vector3 moveToStart, Vector3 moveToEnd, float timeToTake)
        {
            _player.Controller.enabled = false;
            float elapsedTime = 0;

            while(elapsedTime < timeToTake)
            {
                //Move platform
                _floatingPlatform.transform.position = Vector3.Lerp(moveToStart, moveToEnd, elapsedTime/timeToTake);


                //move character on the platform
                Vector3 moveDirection = moveToEnd - _floatingPlatform.transform.position;

                elapsedTime += Time.deltaTime;

                //Force stop the coroutine if player dies (fighting with Reset method)
                if(!_isRunning)
                {
                    if (_isResetting)
                    {
                        moveToStart = _waypoints[0].position;
                        moveToEnd = _waypoints[0].position;
                    }
                    break;
                }

                yield return _waitEOFYield;
            }

            //reached destination so update waypoints
            _nextWaypoint = ReturnWaypointID(_nextWaypoint + 1);
            _currentWaypoint = ReturnWaypointID(_currentWaypoint + 1);
            _player.Controller.enabled = true;

            yield return _waitTimeYield;

            MoveToNextPosition();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                _player = other.gameObject.GetComponent<Player>();
                _player.transform.parent = this.transform;   
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                if (_player != null)
                {
                    _player.transform.parent = null;
                    _player = null;
                }
            }
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
