﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ExpensesManager.Events.Templates {
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
    public class MailTemplates {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal MailTemplates() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("ExpensesManager.Events.Templates.MailTemplates", typeof(MailTemplates).Assembly);
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
        ///   Looks up a localized string similar to Criação do Usuário - Expenses Manager.
        /// </summary>
        public static string SUBJECT_CREATE_USER {
            get {
                return ResourceManager.GetString("SUBJECT_CREATE_USER", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;!DOCTYPE html&gt;
        ///&lt;html lang=&quot;en&quot;&gt;
        ///&lt;body style=&quot;margin:30px 0px; padding:0; background-color:#1E1E2E; font-family: Arial, sans-serif; color: #FFFFFF;&quot;&gt;
        ///    &lt;div style=&quot;max-width:600px; margin:0 auto; background-color:#2E2E3E; border:1px solid #3E3E5E; border-radius:8px; overflow:hidden;&quot;&gt;
        ///        &lt;div style=&quot;background-color:#4E94EC; padding:20px; text-align:center; color:#FFFFFF;&quot;&gt;
        ///            &lt;h1 style=&quot;margin:0; font-size:24px;&quot;&gt;Bem-vindo ao Gerenciador de Despesas!&lt;/h1&gt;
        ///        &lt;/div&gt;
        ///        &lt;div  [rest of string was truncated]&quot;;.
        /// </summary>
        public static string TEMPLATE_CREATE_USER {
            get {
                return ResourceManager.GetString("TEMPLATE_CREATE_USER", resourceCulture);
            }
        }
    }
}
