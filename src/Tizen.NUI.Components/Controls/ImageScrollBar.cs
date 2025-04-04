﻿/*
 * Copyright(c) 2019 Samsung Electronics Co., Ltd.
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
using Tizen.NUI.BaseComponents;
using System.ComponentModel;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// The ScrollBar class of nui component. It allows users to recognize the direction and the range of lists/content.
    /// </summary>
    /// <remarks>
    /// Please note that this class will be replaced with Scrollbar class in the near future.
    /// </remarks>
    /// <since_tizen> 6 </since_tizen>
    /// This will be deprecated
    [Obsolete("Deprecated in API8; Will be removed in API10")]
    public partial class ScrollBar : Control
    {
        private ImageView trackImage;
        private ImageView thumbImage;
        private Animation scrollAniPlayer = null;
        private float thumbImagePosX;
        private float thumbImagePosY;
        private bool enableAni = false;
        private int minValue;
        private int maxValue;
        private int curValue;
        private DirectionType direction = DirectionType.Horizontal;
        private uint duration;

        static ScrollBar()
        {
            if (NUIApplication.IsUsingXaml)
            {
                DirectionProperty = BindableProperty.Create(nameof(Direction), typeof(DirectionType), typeof(ScrollBar), DirectionType.Horizontal,
                    propertyChanged: SetInternalDirectionProperty, defaultValueCreator: GetInternalDirectionProperty);
                MaxValueProperty = BindableProperty.Create(nameof(MaxValue), typeof(int), typeof(ScrollBar), default(int),
                    propertyChanged: SetInternalMaxValueProperty, defaultValueCreator: GetInternalMaxValueProperty);
                MinValueProperty = BindableProperty.Create(nameof(MinValue), typeof(int), typeof(ScrollBar), default(int),
                    propertyChanged: SetInternalMinValueProperty, defaultValueCreator: GetInternalMinValueProperty);
                CurrentValueProperty = BindableProperty.Create(nameof(CurrentValue), typeof(int), typeof(ScrollBar), default(int),
                    propertyChanged: SetInternalCurrentValueProperty, defaultValueCreator: GetInternalCurrentValueProperty);
                DurationProperty = BindableProperty.Create(nameof(Duration), typeof(uint), typeof(ScrollBar), default(uint),
                    propertyChanged: SetInternalDurationProperty, defaultValueCreator: GetInternalDurationProperty);
                ThumbSizeProperty = BindableProperty.Create(nameof(ThumbSize), typeof(Size), typeof(ScrollBar), null,
                    propertyChanged: SetInternalThumbSizeProperty, defaultValueCreator: GetInternalThumbSizeProperty);
                TrackImageURLProperty = BindableProperty.Create(nameof(TrackImageURL), typeof(string), typeof(ScrollBar), default(string),
                    propertyChanged: SetInternalTrackImageURLProperty, defaultValueCreator: GetInternalTrackImageURLProperty);
                TrackColorProperty = BindableProperty.Create(nameof(TrackColor), typeof(Color), typeof(ScrollBar), null,
                    propertyChanged: SetInternalTrackColorProperty, defaultValueCreator: GetInternalTrackColorProperty);
                ThumbColorProperty = BindableProperty.Create(nameof(ThumbColor), typeof(Color), typeof(ScrollBar), null,
                    propertyChanged: SetInternalThumbColorProperty, defaultValueCreator: GetInternalThumbColorProperty);
            }
        }

        /// <summary>
        /// The constructor of ScrollBar.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API8; Will be removed in API10")]
        public ScrollBar() : base()
        {
        }

        /// <summary>
        /// The constructor of ScrollBar with specific style.
        /// </summary>
        /// <param name="style">style name</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ScrollBar(string style) : base(style)
        {
        }

        /// <summary>
        /// The constructor of ScrollBar with specific style.
        /// </summary>
        /// <param name="scrollBarStyle">The style object to initialize the ScrollBar.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ScrollBar(ScrollBarStyle scrollBarStyle) : base(scrollBarStyle)
        {
        }

        /// <summary>
        /// The direction type of the Scroll.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API8; Will be removed in API10")]
        public enum DirectionType
        {
            /// <summary>
            /// The Horizontal type.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be deprecated
            [Obsolete("Deprecated in API8; Will be removed in API10")]
            Horizontal,

            /// <summary>
            /// The Vertical type.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be deprecated
            [Obsolete("Deprecated in API8; Will be removed in API10")]
            Vertical
        }

        #region public property 
        /// <summary>
        /// The property to get/set the direction of the ScrollBar.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API8; Will be removed in API10")]
        public DirectionType Direction
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (DirectionType)GetValue(DirectionProperty);
                }
                else
                {
                    return GetInternalDirection();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(DirectionProperty, value);
                }
                else
                {
                    SetInternalDirection(value);
                }
            }
        }

        private void SetInternalDirection(DirectionType newValue)
        {
            direction = newValue;
            UpdateValue();
        }

        private DirectionType GetInternalDirection()
        {
            return direction;
        }

        /// <summary>
        /// The property to get/set the size of the thumb object.
        /// </summary>
        /// <exception cref="InvalidOperationException">Throw when ThumbSize is null.</exception>
        /// <example>
        /// <code>
        /// ScrollBar scroll;
        /// try
        /// {
        ///     scroll.ThumbSize = new Size(500, 10, 0);
        /// }
        /// catch(InvalidOperationException e)
        /// {
        ///     Tizen.Log.Error(LogTag, "Failed to set ThumbSize value : " + e.Message);
        /// }
        /// </code>
        /// </example>
        /// <since_tizen> 6 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API8; Will be removed in API10")]
        public Size ThumbSize
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return GetValue(ThumbSizeProperty) as Size;
                }
                else
                {
                    return InternalThumbSize;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(ThumbSizeProperty, value);
                }
                else
                {
                    InternalThumbSize = value;
                }
                NotifyPropertyChanged();
            }
        }
        private Size InternalThumbSize
        {
            get
            {
                return thumbImage?.Size;
            }
            set
            {
                if (thumbImage != null)
                {
                    thumbImage.Size = value;
                    RelayoutRequest();
                }
            }
        }

        /// <summary>
        /// The property to get/set the image URL of the track object.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API8; Will be removed in API10")]
        public string TrackImageURL
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return GetValue(TrackImageURLProperty) as string;
                }
                else
                {
                    return InternalTrackImageURL;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(TrackImageURLProperty, value);
                }
                else
                {
                    InternalTrackImageURL = value;
                }
                NotifyPropertyChanged();
            }
        }
        private string InternalTrackImageURL
        {
            get
            {
                return trackImage?.ResourceUrl;
            }
            set
            {
                if (trackImage != null)
                {
                    trackImage.ResourceUrl = value;
                    RelayoutRequest();
                }
            }
        }

        /// <summary>
        /// The property to get/set the color of the track object.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API8; Will be removed in API10")]
        public Color TrackColor
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return GetValue(TrackColorProperty) as Color;
                }
                else
                {
                    return InternalTrackColor;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(TrackColorProperty, value);
                }
                else
                {
                    InternalTrackColor = value;
                }
                NotifyPropertyChanged();
            }
        }
        private Color InternalTrackColor
        {
            get
            {
                return trackImage?.BackgroundColor;
            }
            set
            {
                if (trackImage != null)
                {
                    trackImage.BackgroundColor = value;
                }
            }
        }

        /// <summary>
        /// The property to get/set the color of the thumb object.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API8; Will be removed in API10")]
        public Color ThumbColor
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return GetValue(ThumbColorProperty) as Color;
                }
                else
                {
                    return InternalThumbColor;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(ThumbColorProperty, value);
                }
                else
                {
                    InternalThumbColor = value;
                }
                NotifyPropertyChanged();
            }
        }
        private Color InternalThumbColor
        {
            get
            {
                return thumbImage?.BackgroundColor;
            }
            set
            {
                if (thumbImage != null)
                {
                    thumbImage.BackgroundColor = value;
                }
            }
        }

        /// <summary>
        /// The property to get/set the max value of the ScrollBar.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API8; Will be removed in API10")]
        public int MaxValue
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (int)GetValue(MaxValueProperty);
                }
                else
                {
                    return GetInternalMaxValue();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(MaxValueProperty, value);
                }
                else
                {
                    SetInternalMaxValue(value);
                }
            }
        }

        private void SetInternalMaxValue(int newValue)
        {
            if (newValue >= 0)
            {
                maxValue = newValue;
                UpdateValue();
            }
        }

        private int GetInternalMaxValue()
        {
            return maxValue;
        }

        /// <summary>
        /// The property to get/set the min value of the ScrollBar.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API8; Will be removed in API10")]
        public int MinValue
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (int)GetValue(MinValueProperty);
                }
                else
                {
                    return GetInternalMinValue();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(MinValueProperty, value);
                }
                else
                {
                    SetInternalMinValue(value);
                }
            }
        }

        private void SetInternalMinValue(int newValue)
        {
            if (newValue >= 0)
            {
                minValue = newValue;
                UpdateValue();
            }
        }

        private int GetInternalMinValue()
        {
            return minValue;
        }

        /// <summary>
        /// The property to get/set the current value of the ScrollBar.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Throw when Current value is less than Min value, or greater than Max value.</exception>
        /// <example>
        /// <code>
        /// ScrollBar scroll;
        /// scroll.MaxValue = 100;
        /// scroll.MinValue = 0;
        /// try
        /// {
        ///     scroll.CurrentValue = 50;
        /// }
        /// catch(ArgumentOutOfRangeException e)
        /// {
        ///     Tizen.Log.Error(LogTag, "Failed to set Current value : " + e.Message);
        /// }
        /// </code>
        /// </example>
        /// <since_tizen> 6 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API8; Will be removed in API10")]
        public int CurrentValue
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (int)GetValue(CurrentValueProperty);
                }
                else
                {
                    return GetInternalCurrentValue();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(CurrentValueProperty, value);
                }
                else
                {
                    SetInternalCurrentValue(value);
                }
            }
        }

        private void SetInternalCurrentValue(int newValue)
        {
            if (newValue >= 0)
            {
                curValue = newValue;
                UpdateValue();
            }
        }

        private int GetInternalCurrentValue()
        {
            return curValue;
        }

        /// <summary>
        /// Property to set/get animation duration.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API8; Will be removed in API10")]
        public uint Duration
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (uint)GetValue(DurationProperty);
                }
                else
                {
                    return GetInternalDuration();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(DurationProperty, value);
                }
                else
                {
                    SetInternalDuration(value);
                }
            }
        }

        private void SetInternalDuration(uint newValue)
        {
            duration = newValue;
            if (scrollAniPlayer != null)
            {
                scrollAniPlayer.Duration = (int)newValue;
            }
        }

        private uint GetInternalDuration()
        {
            return duration;
        }
        #endregion

        /// <summary>
        /// Method to set current value. The thumb object would move to the corresponding position with animation or not.
        /// </summary>
        /// <param name="currentValue">The special current value.</param>
        /// <param name="enableAnimation">Enable move with animation or not, the default value is true.</param>
        /// <exception cref="ArgumentOutOfRangeException">Throw when current size is less than the min value, or greater than the max value.</exception>
        /// <example>
        /// <code>
        /// ScrollBar scroll;
        /// scroll.MinValue = 0;
        /// scroll.MaxValue = 100;
        /// try
        /// {
        ///     scroll.SetCurrentValue(50);
        /// }
        /// catch(ArgumentOutOfRangeException e)
        /// {
        ///     Tizen.Log.Error(LogTag, "Failed to set current value : " + e.Message);
        /// }
        /// </code>
        /// </example>
        /// <since_tizen> 6 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API8; Will be removed in API10")]
        public void SetCurrentValue(int currentValue, bool enableAnimation = true)
        {
            if (currentValue < minValue || currentValue > maxValue)
            {
                //TNLog.E("Current value is less than the Min value, or greater than the Max value. currentValue = " + currentValue + ";");
#pragma warning disable CA2208 // Instantiate argument exceptions correctly
                throw new ArgumentOutOfRangeException("Wrong Current value. It should be greater than the Min value, and less than the Max value!");
#pragma warning restore CA2208 // Instantiate argument exceptions correctly
            }

            enableAni = enableAnimation;
            CurrentValue = currentValue;
        }

        /// <summary>
        /// Dispose ScrollBar.
        /// </summary>
        /// <param name="type">The DisposeTypes value.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API8; Will be removed in API10")]
#pragma warning disable CS0809 // Obsolete member overrides non-obsolete member, It will be removed in API10
        protected override void Dispose(DisposeTypes type)
#pragma warning restore CS0809 // Obsolete member overrides non-obsolete member, It will be removed in API10
        {
            if (disposed)
            {
                return;
            }

            if (type == DisposeTypes.Explicit)
            {
                //Called by User
                //Release your own managed resources here.
                //You should release all of your own disposable objects here.

                Utility.Dispose(trackImage);
                Utility.Dispose(thumbImage);

                if (scrollAniPlayer != null)
                {
                    scrollAniPlayer.Stop();
                    scrollAniPlayer.Clear();
                    scrollAniPlayer.Dispose();
                    scrollAniPlayer = null;
                }
            }

            //Release your own unmanaged resources here.
            //You should not access any managed member here except static instance.
            //because the execution order of Finalizes is non-deterministic.
            //Unreference this from if a static instance refer to this. 

            //You must call base.Dispose(type) just before exit.
            base.Dispose(type);
        }

        /// <summary>
        /// Get Scrollbar style.
        /// </summary>
        /// <returns>The default scrollbar style.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override ViewStyle CreateViewStyle()
        {
            return new ScrollBarStyle();
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void OnInitialize()
        {
            base.OnInitialize();

            this.Focusable = false;

            trackImage = new ImageView
            {
                Focusable = false,
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.FillToParent,
                PositionUsesPivotPoint = true,
                ParentOrigin = Tizen.NUI.ParentOrigin.CenterLeft,
                PivotPoint = Tizen.NUI.PivotPoint.CenterLeft
            };
            this.Add(trackImage);
            

            thumbImage = new ImageView
            {
                Focusable = false,
                WidthResizePolicy = ResizePolicyType.Fixed,
                HeightResizePolicy = ResizePolicyType.Fixed,
                PositionUsesPivotPoint = true,
                ParentOrigin = Tizen.NUI.ParentOrigin.CenterLeft,
                PivotPoint = Tizen.NUI.PivotPoint.CenterLeft
            };
            this.Add(thumbImage);
            

            scrollAniPlayer = new Animation(334);
            scrollAniPlayer.DefaultAlphaFunction = new AlphaFunction(AlphaFunction.BuiltinFunctions.Linear);

            thumbImagePosX = 0;
            thumbImagePosY = 0;
            LayoutDirectionChanged += OnLayoutDirectionChanged;
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void ApplyStyle(ViewStyle style)
        {
            base.ApplyStyle(style);

            if (style is ScrollBarStyle scrollBarStyle)
            {
                trackImage.ApplyStyle(scrollBarStyle.Track);
                thumbImage.ApplyStyle(scrollBarStyle.Thumb);
                UpdateValue();
            }
        }

        private void OnLayoutDirectionChanged(object sender, LayoutDirectionChangedEventArgs e)
        {
            RelayoutRequest();
        }

        private void UpdateValue()
        {
            if (minValue >= maxValue || curValue < minValue || curValue > maxValue) return;

            float width = (float)Size2D.Width;
            float height = (float)Size2D.Height;
            float thumbW = 0.0f;
            float thumbH = 0.0f;
            if (thumbImage == null || thumbImage.Size == null)
            {
                return;
            }
            else
            {
                thumbW = thumbImage.Size.Width;
                thumbH = thumbImage.Size.Height;
            }
            float ratio = (float)(curValue - minValue) / (float)(maxValue - minValue);

            if (direction == DirectionType.Horizontal)
            {
                if (LayoutDirection == ViewLayoutDirectionType.RTL)
                {
                    ratio = 1.0f - ratio;
                }

                float posX = ratio * (width - thumbW);
                float posY = (height - thumbH) / 2.0f;

                thumbImagePosX = posX;
                if (null != scrollAniPlayer)
                {
                    scrollAniPlayer.Stop();
                }

                if (!enableAni)
                {
                    thumbImage.Position = new Position(posX, posY, 0);
                }
                else
                {
                    if (null != scrollAniPlayer)
                    {
                        scrollAniPlayer.Clear();
                        scrollAniPlayer.AnimateTo(thumbImage, "PositionX", posX);
                        scrollAniPlayer.Play();
                    }
                }
            }
            else
            {
                float posX = (width - thumbW) / 2.0f;
                float posY = ratio * (height - thumbH);

                thumbImagePosY = posY;
                if (null != scrollAniPlayer)
                {
                    scrollAniPlayer.Stop();
                }

                if (!enableAni)
                {
                    thumbImage.Position = new Position(posX, posY, 0);
                }
                else
                {
                    if (null != scrollAniPlayer)
                    {
                        scrollAniPlayer.Clear();
                        scrollAniPlayer.AnimateTo(thumbImage, "PositionY", posY);
                        scrollAniPlayer.Play();
                    }
                }
            }

            if (enableAni) enableAni = false;
        }

        private int CalculateCurrentValue(float offset, DirectionType dir)
        {
            if (dir == DirectionType.Horizontal)
            {
                thumbImagePosX += offset;
                if (thumbImagePosX < 0)
                {
                    thumbImage.PositionX = 0;
                    curValue = minValue;
                }
                else if (thumbImagePosX > Size2D.Width - thumbImage.Size2D.Width)
                {
                    thumbImage.PositionX = Size2D.Width - thumbImage.Size2D.Width;
                    curValue = maxValue;
                }
                else
                {
                    thumbImage.PositionX = thumbImagePosX;
                    curValue = (int)((thumbImagePosX / (float)(Size2D.Width - thumbImage.Size2D.Width)) * (float)(maxValue - minValue) + 0.5f);
                }
            }
            else
            {
                thumbImagePosY += offset;
                if (thumbImagePosY < 0)
                {
                    thumbImage.PositionY = 0;
                    curValue = minValue;
                }
                else if (thumbImagePosY > Size2D.Height - thumbImage.Size2D.Height)
                {
                    thumbImage.PositionY = Size2D.Height - thumbImage.Size2D.Height;
                    curValue = maxValue;
                }
                else
                {
                    thumbImage.PositionY = thumbImagePosY;
                    curValue = (int)((thumbImagePosY / (float)(Size2D.Height - thumbImage.Size2D.Height)) * (float)(maxValue - minValue) + 0.5f);
                }
            }

            return curValue;
        }
    }
}
