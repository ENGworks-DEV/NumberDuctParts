   M S B A M L   `   `   `  ����  NumberDuctParts&     NumberDuctParts.MainFormSettings   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          �Name$  
MainWindow��5   	   $	��280��5   	   $	��280��6   $	��280��5   	   $	��280��6   $	��400��5   	   $	��280��6    � WindowStartupLocation$ CenterScreen=�5	   	    � 
ResizeMode$ NoResize=�5
   	      CustomWindowStyle#���   5   	    � WindowStyle$
 None=�5   	   .��5      �� 
�������
������ $��1,1,1,1q�6:    �� CornerRadius$ 5,5,5,5��6T   $��15,-13,15,13q�6k    J� Effect 5   
   3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 20Q�6      Color$
 Gray��6/      Opacity$	 0.3Q�6<   	   ShadowDepth$	 0Q�6J   
   	Direction$
 0Q�6Z   6j   ._�5   
   � $��9,9,11,0q�6   
������ $	��230��6:   $	��Top=�6G    � ColumnDefinitions 5      �� 5      $��0* �6#   �� 5      $	��33* �6#   �� 5      $��5* �6#    � RowDefinitions 5      �� 5      $
��151* �6    �� 5      $��5* �6    .+�5!      �� -   5         ��Name$ 	TextTitle��5!      $��1��6+   $
��Left=�6;   $��7,12,0,0q�6V   $
��Wrap=�6h   $��Number Ducts��6|   $	��126��6�   $��Roboto Bold)�6�   $��18(�6�   |�.   J� 	AllowDrop .  
���   �$��23��6�   $	��Top=�6  �� 5"      -   5        $��CloseButton��5"   @     CloseButtonStyle#���  6   
���   �$��0q�6f   
������ $	��Top=�6�   $��2��6�   $��21��6�   $��16(�6�   $
��Bold"�6�   $��	4,12,11,0q�6�   .��6  X6  �� 5%      -   5        $��checkBoxDuplicates��5%      $��Equal Elemnts��61   $
��Left=�6I   $��8,52,0,0q�6d   $	��Top=�6v   $��18��6�   $��18��6�   $��1��6�   �� 5&      -   5        $��textBox��5&      $
��Left=�6%   $��16��6@   $��	37,52,0,0q�6L    �� TextWrapping$
 Wrap=�6_   $ �� NUMBER DUPLICATE ELEMENTS��6s   $	��Top=�6�   $	��187��6�   ���	#FFFFFFFF$��Roboto)�6�   $��1��6�   $��2��6�   �� 5'      -   5         ��Name$ Round_Ducts��5'      $�� ��6,   $
��Left=�67   $��8,94,0,0q�6R   $	��Top=�6d   $��1��6|   �� 5(      -   5         ��Name$ textBox_Copy��5(      $
��Left=�6,   $��16��6G   $��	41,94,0,0q�6S   $
 Wrap=�6f   $��INCLUDE ROUND DUCTS��6z   $	��Top=�6�   $	��187��6�   ���	#FFFFFFFF$��Roboto)�6�   $��1��6�   $��2��6�   	� 5)      -   5         	�Name$ SnglElmtButton��5)      $��2��62   $��Single element��6F   $
��Left=�6_   $��
10,172,0,0q�6z   $	��Top=�6�   	� 5*      -	   5        $ CmpltRunButton��5*      $��2��62   $��Complete run��6F   $
��Left=�6]   $��
10,203,0,0q�6x   $	��Top=�6�   5-      5.       � 	Resources 5/       �� MergedDictionaries �� Source�� 50   
    51      �� 52      $ Resources.xaml?�6%   %    54      56      