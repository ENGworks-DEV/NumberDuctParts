#pragma checksum "..\..\..\Views\MainForm.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "BC8AAFB953172CA715727AC510E3A26EAAB3E33B3EC1E9240379ABEE4A4C67C4"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace NumberDuctParts
{


    /// <summary>
    /// MainForm
    /// </summary>
    public partial class MainForm : System.Windows.Window, System.Windows.Markup.IComponentConnector
    {

#line default
#line hidden


#line 42 "..\..\..\Views\MainForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CloseButton;

#line default
#line hidden


#line 45 "..\..\..\Views\MainForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button TtitleButton;

#line default
#line hidden


#line 48 "..\..\..\Views\MainForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox PrefixBox;

#line default
#line hidden


#line 49 "..\..\..\Views\MainForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox NumberBox;

#line default
#line hidden


#line 53 "..\..\..\Views\MainForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button;

#line default
#line hidden


#line 54 "..\..\..\Views\MainForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SeparatorBox;

#line default
#line hidden


#line 58 "..\..\..\Views\MainForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ExpandButton;

#line default
#line hidden


#line 59 "..\..\..\Views\MainForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ResetColorButton;

#line default
#line hidden


#line 60 "..\..\..\Views\MainForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ResetValuesButton;

#line default
#line hidden


#line 61 "..\..\..\Views\MainForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label LabelDisplace;

#line default
#line hidden


#line 62 "..\..\..\Views\MainForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Rectangle LineDivisionDisplace;

#line default
#line hidden


#line 63 "..\..\..\Views\MainForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DiplaceUp;

#line default
#line hidden


#line 64 "..\..\..\Views\MainForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DisplaceDN;

#line default
#line hidden

        private bool _contentLoaded;

        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent()
        {
            if (_contentLoaded)
            {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/NumberDuctParts;component/views/mainform.xaml", System.UriKind.Relative);

#line 1 "..\..\..\Views\MainForm.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);

#line default
#line hidden
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target)
        {
            switch (connectionId)
            {
                case 1:
                    this.MainWindow = ((NumberDuctParts.MainForm)(target));
                    return;
                case 2:

#line 19 "..\..\..\Views\MainForm.xaml"
                    ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.NumberPartButton_Click);

#line default
#line hidden
                    return;
                case 3:

#line 23 "..\..\..\Views\MainForm.xaml"
                    ((System.Windows.Controls.Border)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Border_MouseDown);

#line default
#line hidden
                    return;
                case 4:
                    this.CloseButton = ((System.Windows.Controls.Button)(target));

#line 42 "..\..\..\Views\MainForm.xaml"
                    this.CloseButton.Click += new System.Windows.RoutedEventHandler(this.Close_Click);

#line default
#line hidden
                    return;
                case 5:

#line 43 "..\..\..\Views\MainForm.xaml"
                    ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Settings_Click);

#line default
#line hidden
                    return;
                case 6:
                    this.TtitleButton = ((System.Windows.Controls.Button)(target));

#line 45 "..\..\..\Views\MainForm.xaml"
                    this.TtitleButton.Click += new System.Windows.RoutedEventHandler(this.Title_Link);

#line default
#line hidden
                    return;
                case 7:
                    this.PrefixBox = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 8:
                    this.NumberBox = ((System.Windows.Controls.TextBox)(target));

#line 49 "..\..\..\Views\MainForm.xaml"
                    this.NumberBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.textChangedEventHandler);

#line default
#line hidden
                    return;
                case 9:
                    this.button = ((System.Windows.Controls.Button)(target));

#line 53 "..\..\..\Views\MainForm.xaml"
                    this.button.Click += new System.Windows.RoutedEventHandler(this.NumberPartButton_Click);

#line default
#line hidden
                    return;
                case 10:
                    this.SeparatorBox = ((System.Windows.Controls.TextBox)(target));

#line 54 "..\..\..\Views\MainForm.xaml"
                    this.SeparatorBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.SeparatorBox_TextChanged);

#line default
#line hidden
                    return;
                case 11:
                    this.ExpandButton = ((System.Windows.Controls.Button)(target));

#line 58 "..\..\..\Views\MainForm.xaml"
                    this.ExpandButton.Click += new System.Windows.RoutedEventHandler(this.Expand_Click);

#line default
#line hidden
                    return;
                case 12:
                    this.ResetColorButton = ((System.Windows.Controls.Button)(target));

#line 59 "..\..\..\Views\MainForm.xaml"
                    this.ResetColorButton.Click += new System.Windows.RoutedEventHandler(this.Button_Click);

#line default
#line hidden
                    return;
                case 13:
                    this.ResetValuesButton = ((System.Windows.Controls.Button)(target));

#line 60 "..\..\..\Views\MainForm.xaml"
                    this.ResetValuesButton.Click += new System.Windows.RoutedEventHandler(this.Button_Click_1);

#line default
#line hidden
                    return;
                case 14:
                    this.LabelDisplace = ((System.Windows.Controls.Label)(target));
                    return;
                case 15:
                    this.LineDivisionDisplace = ((System.Windows.Shapes.Rectangle)(target));
                    return;
                case 16:
                    this.DiplaceUp = ((System.Windows.Controls.Button)(target));
                    return;
                case 17:
                    this.DisplaceDN = ((System.Windows.Controls.Button)(target));
                    return;
            }
            this._contentLoaded = true;
        }

        internal System.Windows.Window MainWindow;
    }
}

