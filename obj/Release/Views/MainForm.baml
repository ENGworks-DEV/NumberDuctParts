   M S B A M L   `   `   `  ����   NumberDuctParts    NumberDuctParts.MainForm   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     -     �Name$  
MainWindow��$��297.825��$	��280��$	��280��$	��280��$	��400��$	��280�� � WindowStartupLocation$ CenterScreen=� � 
ResizeMode$ NoResize=�   CustomWindowStyle#���    � WindowStyle$
 None=� J� InputBindings �� 
 �� Key$ A�� �� 	Modifiers$ Controlf� �� Command$ 	SelectAll�� J� CommandBindings )  #System.Windows.Input.CommandBinding  -   	   Command$	 	SelectAll��.���� -   
�������
������ $��1,1,1,1q�
 �� CornerRadius$
 5,5,5,5��$��15,10,15,13q� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     
BlurRadius$ 20Q�   Color$
 Gray��   Opacity$	 0.3Q�   ShadowDepth$ 0Q�   	Direction$ 0Q�._�� $��9,9,11,-160q�
������ $	��424��$	��Top=� � ColumnDefinitions �� $��0* ��� $	��33* ��� $��5* � � RowDefinitions �� $
��151* ��� $��5* �.+��� -   $��CloseButton��  CloseButtonStyle#���  
���   �$��0q�
������ $	��Top=�$��2��$��21��$��16(�$
��Bold"�$��	4,12,11,0q�.��X�� -     SettingsButtonStyle#���  $��2��
������ 
������ $��182,15,2,380q�$
��Auto����  
 Labels#���  $��6,31,0,0q�$��15��$	��Top=�$��Roboto)�$
��Left=�$��38�� J� RenderTransformOrigin$ 0.776,0.792&�$��2������  �� Path$ ProjectVersion��� -   $��TtitleButton��#���  
���   �$��0q�
������ $	��Top=�$��24��$��20(�$
��Bold"�$��5,9,77,0q�$��2��.��	NUM DUCTS�� -   $��	PrefixBox��  MainTextBox#���  $��5,92,0,0q� �� TextWrapping$
 Wrap=�$��ABCDEFGHIJK��$��1��$��30��$	��Top=�$
��Left=�$	��104���� -   $��	NumberBox��#���  $��	0,92,10,0q�$
 Wrap=�$	��000��$��1��$��30��$	��Top=�$	��0.6q�$��Right=�$��56��$��2���� #���  $��Number��$��
162,68,8,0q�$��1��$��24��$	��Top=�$��2���� #���  $��Prefix��$��3,71,0,0q�$��1��$��24��$	��Top=�$��Roboto)�$
��Left=�$��33���� #���  $	��Sep��$��
110,69,0,0q�$��1��$��24��$	��Top=�$��Roboto)�$
��Left=�$��49���� -	   $��button��  MainButtonStyle#���  $��3��$��SELECT ELEMENT��$
��Left=�$��	5,141,0,0q�$	��Top=�$	��213��
 � Tag$  ���� -
    ��Name$ SeparatorBox��#���  $��30��$��
121,92,0,0q�$
 Wrap=�$��-��$	��Top=� �� 	MaxLength$ 1��$	��0.6q�$��1��$
��Left=�$��30��$ 
0.441,0.55&��� $��Stretch=�$	��Top=�
�������$��2��$��
7,199,11,0q� J� Opacity$	 0.1Q�$��1��$��2���� -   $��ExpandButton��#���  
�������$��
0,204,11,0q�$��0q�$��Right=�$��15��
������ $	��Top=�$��2��$��20��$��16(�$
��Bold"�.��▼�� -    ��Name$ ResetColorButton��  SecondaryButtonStyle#���  $��COLOR��$��	8,238,0,0q�$��1�� � ToolTip$ Reset Elements color��$	��Top=�$
��Left=�$��84��$y�Hidden=��� -   $ ResetValuesButton��#���  $��VALUES��$��
0,238,10,0q�$��77��$ Reset Elements values��$	��Top=�$��Right=�$��1��$��2��$y�Hidden=��� -    ��Name$ LabelDisplace��#���  $��Displace values��$��	7,298,0,0q�$��86��$��1��$��20��$	��Top=�$
��Left=�$y�Hidden=��� -    ��Name$ LineDivisionDisplace��$��Stretch=�$	��Top=�
�������$��2��$��10,291,11,0q�$	 0.1Q�$��1��$y�Hidden=�$��2���� -   $ 	DiplaceUp��#���  $��UP��$��
8,332,0,-4q�$ 
0.44,0.595&�$��1��$&  Displace all elements numbers up��$	��Top=�$
��Left=�$��86��$y�Hidden=�$��2���� -   $ 
DisplaceDN��#���  $
��DOWN��$��0,332,11,-4q� �� IsCancel .  �� 	IsDefault . $��1��$ 0.477,0.461&�$( "Displace all elements numbers down��$	��Top=�$��Right=�$��77��$y�Hidden=�$��2��$��2���� #���  $��Reset / Modify��$��	4,206,0,0q�$��1��$��17��$	��Top=�$��Roboto)�$
��Left=�$��85��  � 	Resources  ! �� MergedDictionaries" �� Source�� ! �� $" Resources.xaml?�%    