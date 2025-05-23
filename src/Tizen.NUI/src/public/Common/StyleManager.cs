/*
 * Copyright(c) 2017 Samsung Electronics Co., Ltd.
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
using System.Runtime.InteropServices;
using Tizen.NUI.BaseComponents;
using System.ComponentModel;

namespace Tizen.NUI
{
    /// <summary>
    /// The StyleManager informs applications of the system theme change, and supports application theme change at runtime.<br />
    /// Applies various styles to controls using the properties system.<br />
    /// On theme change, it automatically updates all controls, then raises a event to inform the application.<br />
    /// If the application wants to customize the theme, RequestThemeChange needs to be called.<br />
    /// It provides the path to the application resource root folder, from there the filename can be specified along with any subfolders, for example, Images, Models, etc.<br />
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    [Obsolete("Deprecated in API9, will be removed in API11. Use ThemeManager instead.")]
    public class StyleManager : BaseHandle
    {
        private static readonly StyleManager instance = StyleManager.GetInternal();
        private EventHandler<StyleChangedEventArgs> styleManagerStyleChangedEventHandler;
        private StyleChangedCallbackDelegate styleManagerStyleChangedCallbackDelegate;

        /// <summary>
        /// Creates a StyleManager handle.<br />
        /// This can be initialized with StyleManager::Get().<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("Deprecated in API9, will be removed in API11. Use ThemeManager instead.")]
        public StyleManager() : this(Interop.StyleManager.NewStyleManager(), true, false)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void StyleChangedCallbackDelegate(IntPtr styleManager, Tizen.NUI.StyleChangeType styleChange);

        /// <summary>
        /// An event for the StyleChanged signal which can be used to subscribe or unsubscribe the
        /// event handler provided by the user.<br />
        /// The StyleChanged signal is emitted after the style (for example, theme or font change) has changed
        /// and the controls have been informed.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("Deprecated in API9, will be removed in API11. Use ThemeManager instead.")]
        public event EventHandler<StyleChangedEventArgs> StyleChanged
        {
            add
            {
                if (styleManagerStyleChangedEventHandler == null)
                {
                    styleManagerStyleChangedCallbackDelegate = (OnStyleChanged);
                    using var signal = StyleChangedSignal();
                    signal.Connect(styleManagerStyleChangedCallbackDelegate);
                }
                styleManagerStyleChangedEventHandler += value;
            }
            remove
            {
                styleManagerStyleChangedEventHandler -= value;
                using var signal = StyleChangedSignal();
                if (styleManagerStyleChangedEventHandler == null && signal.Empty() == false)
                {
                    signal.Disconnect(styleManagerStyleChangedCallbackDelegate);
                }
            }
        }

        /// <summary>
        /// Gets the singleton of the StyleManager object.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        [Obsolete("Deprecated in API9, will be removed in API11. Use ThemeManager instead.")]
        public static StyleManager Instance
        {
            get
            {
                return instance;
            }
        }

        /// <summary>
        /// Gets the singleton of StyleManager object.
        /// </summary>
        /// <returns>A handle to the StyleManager control.</returns>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("Deprecated in API9, will be removed in API11. Use ThemeManager instead." +
            "Do not use this, that will be deprecated. Use StyleManager.Instance instead.")]
        public static StyleManager Get()
        {
            return StyleManager.Instance;
        }

        private static StyleManager GetInternal()
        {
            global::System.IntPtr cPtr = Interop.StyleManager.Get();

            if(cPtr == global::System.IntPtr.Zero)
            {
                NUILog.ErrorBacktrace("StyleManager.Instance called before Application created, or after Application terminated!");
                // Do not throw exception until TCT test passed.
            }

            StyleManager ret = Registry.GetManagedBaseHandleFromNativePtr(cPtr) as StyleManager;
            if (ret != null)
            {
                NUILog.ErrorBacktrace("StyleManager.GetInternal() Should be called only one time!");
                object dummyObect = new object();

                HandleRef CPtr = new HandleRef(dummyObect, cPtr);
                Interop.BaseHandle.DeleteBaseHandle(CPtr);
                CPtr = new HandleRef(null, global::System.IntPtr.Zero);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
            else
            {
                ret = new StyleManager(cPtr, true);
                return ret;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                NUILog.ErrorBacktrace("We should not manually dispose for singleton class!");
            }
            else
            {
                base.Dispose(disposing);
            }
        }

        /// <summary>
        /// Applies a new theme to the application.<br />
        /// This will be merged on the top of the default Toolkit theme.<br />
        /// If the application theme file doesn't style all controls that the
        /// application uses, then the default Toolkit theme will be used
        /// instead for those controls.<br />
        /// </summary>
        /// <param name="themeFile">A relative path is specified for style theme.</param>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("Deprecated in API9, will be removed in API11. Use ThemeManager instead.")]
        public void ApplyTheme(string themeFile)
        {
            Interop.StyleManager.ApplyTheme(SwigCPtr, themeFile);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Applies the default Toolkit theme.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("Deprecated in API9, will be removed in API11. Use ThemeManager instead.")]
        public void ApplyDefaultTheme()
        {
            Interop.StyleManager.ApplyDefaultTheme(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Sets a constant for use when building styles.
        /// </summary>
        /// <param name="key">The key of the constant.</param>
        /// <param name="value">The value of the constant.</param>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("Deprecated in API9, will be removed in API11. Use ThemeManager instead.")]
        public void AddConstant(string key, PropertyValue value)
        {
            Interop.StyleManager.SetStyleConstant(SwigCPtr, key, PropertyValue.getCPtr(value));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Returns the style constant set for a specific key.
        /// </summary>
        /// <param name="key">The key of the constant.</param>
        /// <param name="valueOut">The value of the constant if it exists.</param>
        /// <returns></returns>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("Deprecated in API9, will be removed in API11. Use ThemeManager instead.")]
        public bool GetConstant(string key, PropertyValue valueOut)
        {
            bool ret = Interop.StyleManager.GetStyleConstant(SwigCPtr, key, PropertyValue.getCPtr(valueOut));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Applies the specified style to the control.
        /// </summary>
        /// <param name="control">The control to which to apply the style.</param>
        /// <param name="jsonFileName">The name of the JSON style file to apply.</param>
        /// <param name="styleName">The name of the style within the JSON file to apply.</param>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("Deprecated in API9, will be removed in API11. Use ThemeManager instead.")]
        public void ApplyStyle(View control, string jsonFileName, string styleName)
        {
            Interop.StyleManager.ApplyStyle(SwigCPtr, View.getCPtr(control), jsonFileName, styleName);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// The Type of BrokenImage
        /// </summary>
        internal enum BrokenImageType
        {
            Small = 0,
            Normal = 1,
            Large = 2
        }

        /// <summary>
        /// Sets the broken image url.
        /// The broken image is the image to show when image loading is failed.
        /// When the broken image and type are set in the Application,
        /// the proper brokenImage is set automatically considering the size of view and the size of the brokenImage.
        /// This Api is used from theme manager.
        /// </summary>
        /// <param name="type"> The type for brokenImage </param>
        /// <param name="url"> The url for brokenImage </param>
        internal void SetBrokenImageUrl(BrokenImageType type, string url)
        {
            Interop.StyleManager.SetBrokenImageUrl(SwigCPtr, (uint)type, url);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Gets the broken image url
        /// </summary>
        /// <param name="type"> The type for brokenImage</param>
        /// <returns> the url for brokenImage </returns>
        internal string GetBrokenImageUrl(BrokenImageType type)
        {
            string ret = Interop.StyleManager.GetBrokenImageUrl(SwigCPtr, (uint)type);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal StyleManager(global::System.IntPtr cPtr, bool cMemoryOwn) : this(cPtr, cMemoryOwn, cMemoryOwn)
        {
        }

        internal StyleManager(global::System.IntPtr cPtr, bool cMemoryOwn, bool cRegister) : base(cPtr, cMemoryOwn, cRegister)
        {
        }

        internal StyleChangedSignal StyleChangedSignal()
        {
            StyleChangedSignal ret = new StyleChangedSignal(Interop.StyleManager.StyleChangedSignal(SwigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        // Callback for StyleManager StyleChangedsignal
        private void OnStyleChanged(IntPtr styleManager, StyleChangeType styleChange)
        {
            if (styleManagerStyleChangedEventHandler != null)
            {
                StyleChangedEventArgs e = new StyleChangedEventArgs();

                // Populate all members of "e" (StyleChangedEventArgs) with real data.
                e.StyleManager = Registry.GetManagedBaseHandleFromNativePtr(styleManager) as StyleManager;
                e.StyleChange = styleChange;
                //Here we send all data to user event handlers.
                styleManagerStyleChangedEventHandler(this, e);
            }
        }

        /// <summary>
        /// Style changed event arguments.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("Deprecated in API9, will be removed in API11. Use ThemeManager instead.")]
        public class StyleChangedEventArgs : EventArgs
        {
            private StyleManager styleManager;
            private StyleChangeType styleChange;

            /// <summary>
            /// StyleManager.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            [Obsolete("Deprecated in API9, will be removed in API11. Use ThemeManager instead.")]
            public StyleManager StyleManager
            {
                get
                {
                    return styleManager;
                }
                set
                {
                    styleManager = value;
                }
            }

            /// <summary>
            /// StyleChange - contains the style change information (default font changed or
            /// default font size changed or theme has changed).<br />
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            [Obsolete("Deprecated in API9, will be removed in API11. Use ThemeManager instead.")]
            public StyleChangeType StyleChange
            {
                get
                {
                    return styleChange;
                }
                set
                {
                    styleChange = value;
                }
            }
        }

        internal static void SetBrokenImage(BrokenImageType type, string url)
        {
            Interop.StyleManager.SetBrokenImageUrl(Instance.SwigCPtr, (uint)type, url);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }
        internal static string GetBrokenImageURL(BrokenImageType type)
        {
            string ret = Interop.StyleManager.GetBrokenImageUrl(Instance.SwigCPtr, (uint)type);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }
    }
}
