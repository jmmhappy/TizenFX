/*
 * Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the License);
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an AS IS BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;

namespace Tizen.Sensor
{
    /// <summary>
    /// The LightSensor class is used for registering callbacks for the light sensor and getting the light data.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public sealed class LightSensor : Sensor
    {
        private const string LightSensorKey = "http://tizen.org/feature/sensor.photometer";

        /// <summary>
        /// Get the light level of light sensor as float type.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value> The light level. </value>
        public float Level { get; private set; } = float.MinValue;

        /// <summary>
        /// Return true or false based on whether the light sensor is supported by the device.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value><c>true</c> if supported; otherwise <c>false</c>.</value>
        public static bool IsSupported
        {
            get
            {
                Log.Info(Globals.LogTag, "Checking if the LightSensor is supported");
                return CheckIfSupported(SensorType.LightSensor, LightSensorKey);
            }
        }

        /// <summary>
        /// Return the number of light sensors available on the system.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value> The count of light sensors. </value>
        public static int Count
        {
            get
            {
                Log.Info(Globals.LogTag, "Getting the count of light sensors");
                return GetCount();
            }
        }

        /// <summary>
        /// Initialize a new instance of the <see cref="Tizen.Sensor.LightSensor"/> class.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <feature>http://tizen.org/feature/sensor.photometer</feature>
        /// <exception cref="ArgumentException">Thrown when an invalid argument is used.</exception>
        /// <exception cref="NotSupportedException">Thrown when the sensor is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the operation is invalid for the current state.</exception>
        /// <param name='index'>
        /// Index refers to a particular light sensor in case of multiple sensors.
        /// Default value is 0.
        /// </param>
        public LightSensor(uint index = 0) : base(index)
        {
            Log.Info(Globals.LogTag, "Creating LightSensor object");
        }

        internal override SensorType GetSensorType()
        {
            return SensorType.LightSensor;
        }

        /// <summary>
        /// An event handler for storing the callback functions for the event corresponding to the change in the light sensor data.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<LightSensorDataUpdatedEventArgs> DataUpdated;

        private static int GetCount()
        {
            IntPtr list;
            int count;
            int error = Interop.SensorManager.GetSensorList(SensorType.LightSensor, out list, out count);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error getting sensor list for light");
                count = 0;
            }
            else
                Interop.Libc.Free(list);
            return count;
        }

        /// <summary>
        /// Read light sensor data synchronously.
        /// </summary>
        internal override void ReadData()
        {
            Interop.SensorEventStruct sensorData;
            int error = Interop.SensorListener.ReadData(ListenerHandle, out sensorData);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error reading light sensor data");
                throw SensorErrorFactory.CheckAndThrowException(error, "Reading light sensor data failed");
            }

            Timestamp = sensorData.timestamp;
            Level = sensorData.values[0];
        }

        private static Interop.SensorListener.SensorEventsCallback _callback;

        internal override void EventListenStart()
        {
            _callback = (IntPtr sensorHandle, IntPtr eventPtr, uint events_count, IntPtr data) => {
                updateBatchEvents(eventPtr, events_count);
                Interop.SensorEventStruct sensorData = latestEvent();

                Timestamp = sensorData.timestamp;
                Level = sensorData.values[0];

                DataUpdated?.Invoke(this, new LightSensorDataUpdatedEventArgs(sensorData.values[0]));
            };

            int error = Interop.SensorListener.SetEventsCallback(ListenerHandle, _callback, IntPtr.Zero);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error setting event callback for light sensor");
                throw SensorErrorFactory.CheckAndThrowException(error, "Unable to set event callback for light");
            }
        }

        internal override void EventListenStop()
        {
            int error = Interop.SensorListener.UnsetEventsCallback(ListenerHandle);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error unsetting event callback for light sensor");
                throw SensorErrorFactory.CheckAndThrowException(error, "Unable to unset event callback for light");
            }
        }
    }
}
