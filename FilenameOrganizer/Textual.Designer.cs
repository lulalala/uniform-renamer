﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.4200
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FilenameOrganizer {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "2.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Textual {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Textual() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("FilenameOrganizer.Textual", typeof(Textual).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Delete rule empty.
        /// </summary>
        internal static string ErrorDeleteRule {
            get {
                return ResourceManager.GetString("ErrorDeleteRule", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Replace rules need to have at least 3 items delimited by tabs.
        /// </summary>
        internal static string ErrorReplaceRule {
            get {
                return ResourceManager.GetString("ErrorReplaceRule", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to File Name.
        /// </summary>
        internal static string FileName {
            get {
                return ResourceManager.GetString("FileName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to File Saved.
        /// </summary>
        internal static string FileSaved {
            get {
                return ResourceManager.GetString("FileSaved", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to New File Name.
        /// </summary>
        internal static string NewFileName {
            get {
                return ResourceManager.GetString("NewFileName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Please doublecheck the renaming preview. Do you wish to continue the renaming process?.
        /// </summary>
        internal static string RenameWarning {
            get {
                return ResourceManager.GetString("RenameWarning", resourceCulture);
            }
        }
    }
}