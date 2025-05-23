/* 
* Copyright(c) 2021 Samsung Electronics Co., Ltd.
*
* Licensed under the Apache License, Version 2.0 (the "License");
* you may not use this file except in compliance with the License.
* You may obtain a copy of the License at
*
* http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an "AS IS" BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
*
*/

using System;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace Tizen.NUI.BaseComponents.VectorGraphics
{
    /// <summary>
    /// Shape is a command list for drawing one shape groups It has own path data and properties for sync/asynchronous drawing
    /// </summary>
    /// <since_tizen> 9 </since_tizen>
    public class Shape : Drawable
    {
        private Gradient fillGradient; //Added gradient
        private Gradient strokeGradient; //Added gradient

        /// <summary>
        /// Creates an initialized Shape.
        /// This constructor initializes a new instance of the Shape class.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public Shape() : this(Interop.Shape.New(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal Shape(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        /// <summary>
        /// The color to use for filling the path.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public Color FillColor
        {
            get
            {
                global::System.IntPtr cPtr = Interop.Shape.GetFillColor(BaseHandle.getCPtr(this));
                return new Vector4(cPtr, true);
            }
            set
            {
                Interop.Shape.SetFillColor(BaseHandle.getCPtr(this), Vector4.getCPtr(value));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        /// <summary>
        /// The gradient to use for filling the path.
        /// Even if FillColor is set, Gradient setting takes precedence.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public Gradient FillGradient
        {
            get
            {
                global::System.IntPtr cPtr = Interop.Shape.GetFillGradient(BaseHandle.getCPtr(this));

                Gradient ret = Registry.GetManagedBaseHandleFromNativePtr(cPtr) as Gradient;
                if (ret != null)
                {
                    HandleRef CPtr = new HandleRef(this, cPtr);
                    Interop.BaseHandle.DeleteBaseHandle(CPtr);
                    CPtr = new HandleRef(null, global::System.IntPtr.Zero);
                    return ret;
                }
                else
                {
                    ret = new Gradient(cPtr, true);
                    return ret;
                }
            }
            set
            {
                if (value != null)
                {
                    Interop.Shape.SetFillGradient(BaseHandle.getCPtr(this), BaseHandle.getCPtr(value));
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                    fillGradient = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the fill rule type for the shape.
        /// The fill rule type which determines how the interior of a shape is determined.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public FillRuleType FillRule
        {
            get
            {
                return (FillRuleType)Interop.Shape.GetFillRule(BaseHandle.getCPtr(this));
            }
            set
            {
                Interop.Shape.SetFillRule(BaseHandle.getCPtr(this), (int)value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        /// <summary>
        /// The stroke width to use for stroking the path.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public float StrokeWidth
        {
            get
            {
                return Interop.Shape.GetStrokeWidth(BaseHandle.getCPtr(this));
            }
            set
            {
                Interop.Shape.SetStrokeWidth(BaseHandle.getCPtr(this), value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        /// <summary>
        /// The color to use for stroking the path.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public Color StrokeColor
        {
            get
            {
                global::System.IntPtr cPtr = Interop.Shape.GetStrokeColor(BaseHandle.getCPtr(this));
                return new Vector4(cPtr, true);
            }
            set
            {
                Interop.Shape.SetStrokeColor(BaseHandle.getCPtr(this), Vector4.getCPtr(value));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        /// <summary>
        /// The gradient to use for stroking the path.
        /// Even if StrokeColor is set, Gradient setting takes precedence.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public Gradient StrokeGradient
        {
            get
            {
                global::System.IntPtr cPtr = Interop.Shape.GetStrokeGradient(BaseHandle.getCPtr(this));

                Gradient ret = Registry.GetManagedBaseHandleFromNativePtr(cPtr) as Gradient;
                if (ret != null)
                {
                    HandleRef CPtr = new HandleRef(this, cPtr);
                    Interop.BaseHandle.DeleteBaseHandle(CPtr);
                    CPtr = new HandleRef(null, global::System.IntPtr.Zero);
                    return ret;
                }
                else
                {
                    ret = new Gradient(cPtr, true);
                    return ret;
                }
            }
            set
            {
                if (value != null)
                {
                    Interop.Shape.SetStrokeGradient(BaseHandle.getCPtr(this), BaseHandle.getCPtr(value));
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                    strokeGradient = value;
                }
            }
        }

        /// <summary>
        /// The cap style to use for stroking the path. The cap will be used for capping the end point of a open subpath.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public StrokeCapType StrokeCap
        {
            get
            {
                return (StrokeCapType)Interop.Shape.GetStrokeCap(BaseHandle.getCPtr(this));
            }
            set
            {
                Interop.Shape.SetStrokeCap(BaseHandle.getCPtr(this), (int)value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        /// <summary>
        /// The join style to use for stroking the path.
        /// The join style will be used for joining the two line segment while stroking the path.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public StrokeJoinType StrokeJoin
        {
            get
            {
                return (StrokeJoinType)Interop.Shape.GetStrokeJoin(BaseHandle.getCPtr(this));
            }
            set
            {
                Interop.Shape.SetStrokeJoin(BaseHandle.getCPtr(this), (int)value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        /// <summary>
        /// The stroke dash pattern. The dash pattern is specified dash pattern.
        /// </summary>
        /// <exception cref="ArgumentNullException"> Thrown when value is null. </exception>
        /// <since_tizen> 9 </since_tizen>
        public ReadOnlyCollection<float> StrokeDash
        {
            get
            {
                List<float> retList = new List<float>();
                uint patternCount = Interop.Shape.GetStrokeDashCount(BaseHandle.getCPtr(this));
                for (uint i = 0; i < patternCount; i++)
                {
                    retList.Add(Interop.Shape.GetStrokeDashIndexOf(BaseHandle.getCPtr(this), i));
                }

                ReadOnlyCollection<float> ret = new ReadOnlyCollection<float>(retList);
                return ret;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }
                float[] pattern = new float[value.Count];
                for (int i = 0; i < value.Count; i++)
                {
                    pattern[i] = value[i];
                }
                Interop.Shape.SetStrokeDash(BaseHandle.getCPtr(this), pattern, (uint)value.Count);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        /// <summary>
        /// Append the given rectangle with rounded corner to the path.
        /// The roundedCorner arguments specify the radii of the ellipses defining the
        /// corners of the rounded rectangle.
        ///
        /// roundedCorner are specified in terms of width and height respectively.
        ///
        /// If roundedCorner's values are 0, then it will draw a rectangle without rounded corner.
        /// </summary>
        /// <param name="x">X co-ordinate of the rectangle.</param>
        /// <param name="y">Y co-ordinate of the rectangle.</param>
        /// <param name="width">Width of the rectangle.</param>
        /// <param name="height">Height of the rectangle.</param>
        /// <param name="roundedCornerX">The x radius of the rounded corner and should be in range [ 0 to w/2 ].</param>
        /// <param name="roundedCornerY">The y radius of the rounded corner and should be in range [ 0 to w/2 ].</param>
        /// <returns>True when it's successful. False otherwise.</returns>
        /// <since_tizen> 9 </since_tizen>
        public bool AddRect(float x, float y, float width, float height, float roundedCornerX, float roundedCornerY)
        {
            bool ret = Interop.Shape.AddRect(BaseHandle.getCPtr(this), x, y, width, height, roundedCornerX, roundedCornerY);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Append a circle with given center and x,y-axis radius
        /// </summary>
        /// <param name="x">X co-ordinate of the center of the circle.</param>
        /// <param name="y">Y co-ordinate of the center of the circle.</param>
        /// <param name="radiusX">X axis radius.</param>
        /// <param name="radiusY">Y axis radius.</param>
        /// <returns>True when it's successful. False otherwise.</returns>
        /// <since_tizen> 9 </since_tizen>
        public bool AddCircle(float x, float y, float radiusX, float radiusY)
        {
            bool ret = Interop.Shape.AddCircle(BaseHandle.getCPtr(this), x, y, radiusX, radiusY);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Append the arcs.
        /// </summary>
        /// <param name="x">X co-ordinate of end point of the arc.</param>
        /// <param name="y">Y co-ordinate of end point of the arc.</param>
        /// <param name="radius">Radius of arc</param>
        /// <param name="startAngle">Start angle (in degrees) where the arc begins.</param>
        /// <param name="sweep">The Angle measures how long the arc will be drawn.</param>
        /// <param name="pie">If True, the area is created by connecting start angle point and sweep angle point of the drawn arc. If false, it doesn't.</param>
        /// <returns>True when it's successful. False otherwise.</returns>
        /// <since_tizen> 9 </since_tizen>
        public bool AddArc(float x, float y, float radius, float startAngle, float sweep, bool pie)
        {
            bool ret = Interop.Shape.AddArc(BaseHandle.getCPtr(this), x, y, radius, startAngle, sweep, pie);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Add a point that sets the given point as the current point,
        /// implicitly starting a new subpath and closing the previous one.
        /// </summary>
        /// <param name="x">X co-ordinate of the current point.</param>
        /// <param name="y">Y co-ordinate of the current point.</param>
        /// <returns>True when it's successful. False otherwise.</returns>
        /// <since_tizen> 9 </since_tizen>
        public bool AddMoveTo(float x, float y)
        {
            bool ret = Interop.Shape.AddMoveTo(BaseHandle.getCPtr(this), x, y);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Adds a straight line from the current position to the given end point.
        /// After the line is drawn, the current position is updated to be at the
        /// end point of the line.
        /// If no current position present, it draws a line to itself, basically * a point.
        /// </summary>
        /// <param name="x">X co-ordinate of end point of the line.</param>
        /// <param name="y">Y co-ordinate of end point of the line.</param>
        /// <returns>True when it's successful. False otherwise.</returns>
        /// <since_tizen> 9 </since_tizen>
        public bool AddLineTo(float x, float y)
        {
            bool ret = Interop.Shape.AddLineTo(BaseHandle.getCPtr(this), x, y);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Adds a cubic Bezier curve between the current position and the
        /// given end point (lineEndPoint) using the control points specified by
        /// (controlPoint1), and (controlPoint2). After the path is drawn,
        /// the current position is updated to be at the end point of the path.
        /// </summary>
        /// <param name="controlPoint1X">X co-ordinate of 1st control point.</param>
        /// <param name="controlPoint1Y">Y co-ordinate of 1st control point.</param>
        /// <param name="controlPoint2X">X co-ordinate of 2nd control point.</param>
        /// <param name="controlPoint2Y">Y co-ordinate of 2nd control point.</param>
        /// <param name="endPointX">X co-ordinate of end point of the line.</param>
        /// <param name="endPointY">Y co-ordinate of end point of the line.</param>
        /// <returns>True when it's successful. False otherwise.</returns>
        /// <since_tizen> 9 </since_tizen>
        public bool AddCubicTo(float controlPoint1X, float controlPoint1Y, float controlPoint2X, float controlPoint2Y, float endPointX, float endPointY)
        {
            bool ret = Interop.Shape.AddCubicTo(BaseHandle.getCPtr(this), controlPoint1X, controlPoint1Y, controlPoint2X, controlPoint2Y, endPointX, endPointY);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }


        /// <summary>
        /// Appends a given sub-path to the path.
        /// The current point value is set to the last point from the sub-path.
        /// @note The interface is designed for optimal path setting if the caller has a completed path commands already.
        /// </summary>
        /// <param name="pathCommands">The command object that contain sub-path information. (This command information is copied internally.)</param>
        /// <exception cref="ArgumentNullException"> Thrown when pathCommands is null. </exception>
        /// <since_tizen> 9 </since_tizen>
        public void AddPath(PathCommands pathCommands)
        {
            if (pathCommands == null)
            {
                throw new ArgumentNullException(nameof(pathCommands));
            }

            PathCommandType[] commands = null;
            if (pathCommands.Commands is PathCommandType[] commandArray)
            {
                commands = commandArray;
            }
            else
            {
                commands = pathCommands.Commands.ToArray();        
            }

            float[] points = null;            
            if (pathCommands.Points is float[] pointArray)
            {
                points = pointArray;
            }
            else
            {
                points = pathCommands.Points.ToArray();    
            }
            
            Interop.Shape.AddPath(BaseHandle.getCPtr(this), commands, (uint)commands.Length, points, (uint)points.Length);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Closes the current subpath by drawing a line to the beginning of the
        /// subpath, automatically starting a new path. The current point of the
        /// new path is (0, 0).
        /// If the subpath does not contain any points, this function does nothing.
        /// </summary>
        /// <returns>True when it's successful. False otherwise.</returns>
        /// <since_tizen> 9 </since_tizen>
        public bool Close()
        {
            bool ret = Interop.Shape.Close(BaseHandle.getCPtr(this));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Reset the added path(rect, circle, path, etc...) information.
        /// Color and Stroke information are keeped.
        /// </summary>
        /// <returns>True when it's successful. False otherwise.</returns>
        /// <since_tizen> 9 </since_tizen>
        public bool ResetPath()
        {
            bool ret = Interop.Shape.ResetPath(BaseHandle.getCPtr(this));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }
    }
}
