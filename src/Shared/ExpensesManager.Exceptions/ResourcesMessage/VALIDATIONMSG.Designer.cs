﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ExpensesManager.Exceptions.ResourcesMessage {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class VALIDATIONMSG {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal VALIDATIONMSG() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("ExpensesManager.Exceptions.ResourcesMessage.VALIDATIONMSG", typeof(VALIDATIONMSG).Assembly);
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
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Deve ser informado o valor da movimentação.
        /// </summary>
        public static string AMOUNT_ZERO {
            get {
                return ResourceManager.GetString("AMOUNT_ZERO", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Não pode ser informada uma data futura.
        /// </summary>
        public static string DATE_FUTURE {
            get {
                return ResourceManager.GetString("DATE_FUTURE", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Descrição da movimentação não pode estar vazia.
        /// </summary>
        public static string DESCRIPTION_EMPTY {
            get {
                return ResourceManager.GetString("DESCRIPTION_EMPTY", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Descrição da movimentação não pode conter apenas números.
        /// </summary>
        public static string DESCRIPTION_NUMBER {
            get {
                return ResourceManager.GetString("DESCRIPTION_NUMBER", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Título da movimentação não pode estar vazio.
        /// </summary>
        public static string TITLE_EMPTY {
            get {
                return ResourceManager.GetString("TITLE_EMPTY", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Título da movimentação não pode conter apenas números.
        /// </summary>
        public static string TITLE_NUMBER {
            get {
                return ResourceManager.GetString("TITLE_NUMBER", resourceCulture);
            }
        }
    }
}
