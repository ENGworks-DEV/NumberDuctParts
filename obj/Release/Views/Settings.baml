   M S B A M L   `   `   `  ����   NumberDuctParts&     NumberDuctParts.MainFormSettings   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     -     �Name$  
MainWindow��$	��280��$	��280��$	��280��$	��280��$	��400��$	��280�� � WindowStartupLocation$ CenterScreen=� � 
ResizeMode$ NoResize=�   CustomWindowStyle#���    � WindowStyle$
 None=�.���� 
�������
������ $��1,1,1,1q� �� CornerRadius$ 5,5,5,5��$��15,-13,15,13q� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     
BlurRadius$ 20Q�   Color$
 Gray��   Opacity$	 0.3Q�	   ShadowDepth$	 0Q�
   	Direction$
 0Q�._�� $��9,9,11,0q�
������ $	��230��$	��Top=� � ColumnDefinitions �� $��0* ��� $	��33* ��� $��5* � � RowDefinitions �� $
��151* ��� $��5* �.+��� -    ��Name$ 	TextTitle��$��1��$
��Left=�$��7,12,0,0q�$
��Wrap=�$��Number Ducts��$	��126��$��Roboto Bold)�$��18(�|�.   J� 	AllowDrop .  
���   �$��23��$	��Top=��� -   $��CloseButton��  CloseButtonStyle#���  
���   �$��0q�
������ $	��Top=�$��2��$��21��$��16(�$
��Bold"�$��	4,12,11,0q�.��X�� -   $��checkBoxDuplicates��$��Equal Elemnts��$
��Left=�$��8,52,0,0q�$	��Top=�$��18��$��18��$��1���� -   $��textBox��$
��Left=�$��16��$��	37,52,0,0q� �� TextWrapping$
 Wrap=�$ �� NUMBER DUPLICATE ELEMENTS��$	��Top=�$	��187�����	#FFFFFFFF$��Roboto)�$��1��$��2���� -    ��Name$ Round_Ducts��$�� ��$
��Left=�$��8,94,0,0q�$	��Top=�$��1���� -    ��Name$ textBox_Copy��$
��Left=�$��16��$��	41,94,0,0q�$
 Wrap=�$��INCLUDE ROUND DUCTS��$	��Top=�$	��187�����	#FFFFFFFF$��Roboto)�$��1��$��2��	� -    	�Name$ SnglElmtButton��$��2��$��Single element��$
��Left=�$��
10,172,0,0q�$	��Top=�	� -	   $ CmpltRunButton��$��2��$��Complete run��$
��Left=�$��
10,203,0,0q�$	��Top=� � 	Resources  �� MergedDictionaries �� Source��  �� $ Resources.xaml?�%    