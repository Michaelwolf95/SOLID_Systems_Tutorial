using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MichaelWolfGames
{
    [System.Serializable]
    public struct Timer
    {
        public float Interval;
        private float? _timer;

        public float PercentOnInterval
        {
            get
            {
                if (_timer == null) return 0f;
                return ((float) _timer)/Interval;
            }
        }

        public bool IsRunning
        {
            get { return (_timer != null); }
        }

        public Timer(float _interval, float? timer = null)
        {
            Interval = _interval;
            _timer = timer;
        }

        /// <summary>
        /// Runs the timer, then returns true and resets the timer if the interval has been reached.
        /// </summary>
        /// <param name="timeDelta"></param>
        /// <returns></returns>
        public bool Tick(float timeDelta = -1f)
        {
            if (timeDelta <= 0f) timeDelta = Time.deltaTime;
            if (_timer != null)
            {
                _timer += timeDelta;
                if (_timer >= Interval)
                {
                    Reset();
                    return true;
                }
            }
            else
            {
                _timer = 0f;
            }
            return false;
        }

        /// <summary>
        /// Sets the float? timer value.
        /// </summary>
        /// <param name="value"></param>
        public void Set(float value)
        {
            if (value > Interval) value = Interval;
            _timer = value;
        }

        /// <summary>
        /// Sets the float? timer to null.
        /// </summary>
        public void Reset()
        {
            _timer = null;
        }

        /// <summary>
        /// Sets the float? timer to 0.
        /// Exactly the same as Restart()
        /// </summary>
        public void Restart()
        {
            _timer = 0f;
        }

        /// <summary>
        /// Sets the float? timer to 0.
        /// Exactly the same as Start()
        /// </summary>
        public void Start()
        {
            Restart();
        }
    }
}