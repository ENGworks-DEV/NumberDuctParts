   M S B A M L   `   `   `  ���� O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  1&clr-namespace:System;assembly=mscorlibSystem  M INumberDuctParts, Version=2020.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:NumberDuctPartsNumberDuctParts W0clr-namespace:WpfStyleableWindow.StyleableWindow"WpfStyleableWindow.StyleableWindow    NumberDuctParts.ResourcesR NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   WindowColor  �� Color  WindowBackColor  WindowForeColor  WindowForeHighlightColor  WindowButtonColor  WindowButtonOverColor �� Opacity  WindowButtonPressedColor  WindowTemplate �� 
TargetType ��Name  WarningTemplate � RowDefinitions � ColumnDefinitions � Title 	 MaximizeCommandC  =WpfStyleableWindow.StyleableWindow.ControlDoubleClickBehavior   ExecuteCommand?  9WpfStyleableWindow.StyleableWindow.ShowSystemMenuBehavior   RightButtonShow;  5WpfStyleableWindow.StyleableWindow.WindowDragBehavior	   LeftMouseButtonDrag
 �� RelativeSource �� Mode �� AncestorType   ExecuteCommandParameter   TargetWindow �� Orientation 
 WindowButton  CloseCommand J� BitmapEffect F� Color F� 	Direction F� ShadowDepth F� Opacity F� Softness ��Name n�Name � Cursor J� Opacity=  7WpfStyleableWindow.StyleableWindow.WindowResizeBehavior   	TopResize   TopLeftResize   BottomResize   TopRightResize   RightResize   BottomRightResize    
LeftResize!   BottomLeftResize" �� Triggers# ]� 
Conditions$ �� Property% �� Value& �� 
TargetName' �� Property( �� Value  CustomWindowStyle) �� 
TargetType  Warning  MainButtonStyleTemplate* ��Name+ �� CornerRadius, J� SnapsToDevicePixels- �� ContentStringFormat. �� ContentStringFormat/ P� Property0 P� Value  MainButtonStyle3  -System.Windows.Media.Effects.DropShadowEffect1   Color2   	Direction3   ShadowDepth4   
BlurRadius5   Opacity   SecondaryButtonStyleTemplate  SecondaryButtonStyle  LabelsTemplate 
 Labels  LabelsTitleTemplate  LabelsTitle  MainTextBoxTemplate6 �Name'  !System.Windows.VisualStateManager7   VisualStateGroups%  System.Windows.VisualStateGroup8   States   System.Windows.VisualState9   
Storyboard: �� 
TargetName; �� TargetProperty8	  2System.Windows.Media.Animation.EasingColorKeyFrame< �� KeyTime= �� Value> g� 	BeginTime? g� Duration@ W� From	A W� ToB ��Name  MainTextBox  CloseButtonStyleTemplate  CloseButtonStyle  SettingsButtonStyleTemplateC ��Name  SettingsButtonStyle   F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     :x,http://schemas.microsoft.com/winfx/2006/xaml     1System&clr-namespace:System;assembly=mscorlib  1system&clr-namespace:System;assembly=mscorlib  'localclr-namespace:NumberDuctParts  7sw0clr-namespace:WpfStyleableWindow.StyleableWindow  %  &	        &	      &	      &	 0     &	 A     &	 T     &	 o     &	 �     &	     7  7  7 	 7 
 7  &	 �    7  &	 �	    7  &	 �
    &	 �    7  7  &	 @    &	 �    7  &	 �    &	 �    7  &	 Z    &	 �    7  &	     &	 �    7  &	 �    &	 >    7  7  &	 2    &	 �    7  7  �� $	  Red���� $
  Gray���� $  White���� $  White���� $  #0B94D6���� $  White��$	 0.5Q��� $  White��$	 0.8Q��� " �.R�� 
������ .+�� .+��� $��1��#��z��$��0 0 0 0q�#��z��._�� .+��� .u��� $ WindowContent���� " �.R�� 8��  .+��  �� $��30 ��� $��* �.+�� $��0��$��5,0,0,0q� �� $
��auto ��� $��* ��� $��28 �.+��� $��1��$
��Left=�#��z $��3,0,0,0q�$��Center=�$��Center=�$��Stretch=�$��Stretch=�8�� $��16(�8   . 	 �� 
 �� $ FindAncestor=�" � �� 
 �� $ FindAncestor=�" � �� 
 �� $ FindAncestor=�" ��� $��0��.+��� �� $��28��$��28��$��Resources/WarningLogo.png��$��UniformToFill=��� $��2��$ 
Horizontal=�.+��� $��Right=�8�� 8�� ���� 
 �� $ FindAncestor=�" �.��X�� $��1��#��z��#��z��#��z�� F� $ Black��$	 320Q�$ 10Q�$ .5Q�$ 9Q�._�� .+��� .u��� $ WindowContent���� $ WindowResizeGrip��$��Right=���.  $y�	Collapsed=�$��Bottom=�n� $ ThumbTop��$��6��$
��14,0q�$	��Top=�$ SizeNS��$ 0Q� �� 
 �� $ FindAncestor=�" �n� $ ThumbTopLeft��$��6��$��6��$	��Top=�$
��Left=�$ SizeNWSE��$ 0Q� �� 
 �� $ FindAncestor=�" �n� $ ThumbBottom��$��6��$
��14,0q�$��Bottom=�$ SizeNS��$ 0Q� �� 
 �� $ FindAncestor=�" �n� $ ThumbTopRight��$��6��$��6��$	��Top=�$��Right=�$ SizeNESW��$ 0Q� �� 
 �� $ FindAncestor=�" �n� $ 
ThumbRight��$��Right=�$
��0,14q�$��6��$ SizeWE��$ 0Q� �� 
 �� $ FindAncestor=�" �n� $ ThumbBottomRight��$��6��$��6��$��Bottom=�$��Right=�$ SizeNWSE��$ 0Q� �� 
 �� $ FindAncestor=�" �n� $ 	ThumbLeft��$
��Left=�$
��0,14q�$��6��$ SizeWE��$ 0Q�  �� 
 �� $ FindAncestor=�" �n� $ ThumbBottomLeft��$��6��$��6��$��Bottom=�$
��Left=�$ SizeNESW��$ 0Q�! �� 
 �� $ FindAncestor=�" �" ]� # �� $ �@�
ResizeMode$% CanResizeWithGrip=��� $ �@�WindowState$% Normal=�./��� $& WindowResizeGrip��' � y�$( Visible=��� ") �.��� ' �@�WindowStyle$
( None=��� ' �@�AllowsTransparency( . �� ' � ��
( ���� �� ' � ��
( ���� �� ' � ��$( 0q��� ' � ��
( ���� �� ' � ��8(   �� ' �@�
ResizeMode$( NoResize=��� ") �.��� ' �@�WindowStyle$
( None=��� ' �@�AllowsTransparency( . �� ' � ��$	( 200���� ' � ��$( 46���� ' � ��
( ������� ' � ��
( ������� ' � ��$( 1q��� ' � ��
( �iii��� ' � ��8(   �� ' �@�
ResizeMode$( NoResize=��� " ��.R��� $* border��$+ 3��#��z��#��z��#��z��, . ._��� $ contentPresenter��#��z��#��z��#. z- |�.  #��z��#��z����. #, z, #��z��" P� / �@��IsDefaulted0 . P� / �@J�IsMouseOver0 . . ��� $& border��' �@J�Opacity$	( 0.5Q�P� / � ��0 . . ��� $& border��' �@J�Opacity$	( 0.2Q��� ") ��.��� ' � ��8(   �� ' � ��$( Roboto)��� ' � ��$
( 14px(��� ' � ��
( ������� ' � ��$( 0q��� ' � ��8(  �� ' �@^�ShowDuration$
( 2000���� ' �@^�InitialShowDelay$
( 1500���� ' � ��$( 38���� ' �@J�Effect(   $1 Black��$	2 320Q�$	3 3.6Q�$4 3Q�$
5 0.25Q��� " ��.R��� $* border��$+ 3��#��z��#��z��#��z��, . ._��� $ contentPresenter��#��z��#��z��#. z- |�.  #��z��#��z����. #, z, #��z��" P� / �@��IsDefaulted0 . P� / �@J�IsMouseOver0 . . ��� $& border��' � ��
( �����P� / � ��0 . . ��� $& border��' � ��
( ������� ") ��.��� ' � ��8(   �� ' � ��$( Roboto)��� ' � ��$
( 14px(��� ' � ��
( �   ��� ' � ��$
( 0.55q��� ' � ��
( ������� ' � ��
( ������� ' �@^�ShowDuration$
( 2000���� ' �@^�InitialShowDelay$
( 1500���� ' � ��$( 28���� " ��.R��� ._��� $��Center=�$��Center=���. " P� / � {�0 . �� ") ��.��� ' � ��8(   �� ' � ��$( Roboto)��� ' � ��$
( 12px(��� ' � ��
( ������� " ��.R��� ._��� $��Center=�$��Center=���. " P� / � {�0 . �� ") ��.��� ' � ��8(   �� ' � ��$( Roboto)��� ' � ��$
( 13px(��� ' � ��
( �   ��� " ��.R�� $
6 root��#��z��#��z��7   CommonStates��.8   Disabled��.9 �� .���� $: normalBorder��$1; +(Border.Background).(SolidColorBrush.Color)�.g�	  $< 0��$	= Red���� $: normalBorder��$2; ,(Border.BorderBrush).(SolidColorBrush.Color)�.g�	  $< 0��$	= Red��  ReadOnly��.9 �� .���� $: normalBorder��$1; +(Border.Background).(SolidColorBrush.Color)�.g�	  $< 0��$	= Red���� $: normalBorder��$2; ,(Border.BorderBrush).(SolidColorBrush.Color)�.g�	  $< 0��$	= Red��  FocusStates��.8   Focused��.9 �� .��W� $> 00:00:00.000X�$? 00:00:00.300D�$@ 0X�$A 1X�$; Opacity�$: focusBorder��  	Unfocused��.9 �� .��W� $> 00:00:00.000X�$? 00:00:00.700D�$@ 1X�$A 0X�$; Opacity�$: focusBorder��.+��� $* normalBorder��
�������
�������$��0.8 0.8 0.8 1q�$+ 3���� $* focusBorder��
�������
�������$��0.8 0.8 0.8 4q�$+ 3���� $B PART_ContentHost��#��z��$��0q���.  $��2q�#��z��#��z��#��z����Z� " P� / � {�0 .  . ��� ' � ��( �� $	  Red��P� / �@��
IsReadOnly0 . . ��� ' � ��( �� $	  Red���� ") ��.��� ' � ��8(   �� ' � ��$( Roboto)��� ' � ��$
( 14px(��� ' � ��( �� $  White���� ' � ��( �� $  Black���� ' � ��$	( 8 4q��� ' � ��$( Stretch=��� ' � ��$
( Left=��� ' � ��$( Stretch=��� ' � ��$( Center=��� ' � ��$( 1q��� ' � ��( �� $
  Gray���� " ��.R��� $* border��$+ 3��#��z��#��z��#��z��, . ._��� $ contentPresenter��#��z��#��z��#. z- |�.  #��z��#��z����. #, z, #��z��" P� / �@��IsDefaulted0 . P� / �@J�IsMouseOver0 . . ��� $& border��' �@J�Opacity$	( 0.5Q�P� / � ��0 . . ��� $& border��' �@J�Opacity$	( 0.2Q��� ") ��.��� ' � ��8(   �� ' � ��$( Roboto)��� ' � ��$
( 12px(��� ' � ��
( ������� ' � ��$( 0q��� ' � ��8(  �� ' �@^�ShowDuration$
( 2000���� ' �@^�InitialShowDelay$
( 1500���� ' � ��$( 38���� " ��.R��� $* border��$+ 3��#��z��#��z��#��z��, . ._�� .+��� $C buttonImage��$7��1/NumberDuctParts;component/Resources/Settings.png��$��UniformToFill=��� $ contentPresenter��#��z��#��z��#. z- |�.  #��z��#��z����. #, z, #��z��" P� / �@��IsDefaulted0 . . ��� $& border��' �@J�Opacity$( 1Q��� $& buttonImage��' � ��$7( 1/NumberDuctParts;component/Resources/Settings.png��P� / �@J�IsMouseOver0 . . ��� $& border��' �@J�Opacity$	( 0.5Q��� $& buttonImage��' � ��$7( 1/NumberDuctParts;component/Resources/Settings.png��P� / � ��0 . . ��� $& border��' �@J�Opacity$	( 0.2Q��� ") ��.��� ' � ��8(   �� ' � ��$( Roboto)��� ' � ��$
( 12px(��� ' � ��
( ������� ' � ��$( 0q��� ' � ��8(  �� ' �@^�ShowDuration$
( 2000���� ' �@^�InitialShowDelay$
( 1500���� ' � ��$( 38��