   M S B A M L   `   `   `  ����  	ClientWPF    ClientWPF.Manager   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Manager��5   	   $	��600��6   $	��900��6&    � 
ResizeMode$ NoResize=�5   	    � WindowStyle$ 
ToolWindow=�5   	    � WindowStartupLocation$ CenterScreen=�5   	   .��5	      >�  � 	Resources 5
   
    �� 
TargetType   WrapText �� Property �� Value��%T   &	        �� 5      " ��6   .�5      ��  � ��$
 Wrap=�61   5      5      .��5   
   � .+�5   
   � $��5q�6    � ColumnDefinitions 5      �� 5      $	��30* �6#   �� 5      $
��100* �6#   .+�5       � $��1q�6   $��Stretch=�6    $��Stretch=�6>   
���   �$��1q�6n   6�   ]� 5      .+�5      �� -   5        $��Create��5      $��14(�6'   $	��Top=�65   $��35��6J   $��7,10,7,5q�6V   
�������
���   �.��6�   Create6�   �� 5      -   5        $
��Edit��5      $��14(�6%   $	��Top=�63   $��35��6H   $��7,5,7,5q�6T   
�������
���   �.��6�   Edit6�   �� 5      -   5        $��Delete��5      $��14(�6'   $	��Top=�65   $��35��6J   $��7,5,7,5q�6V   
�������
���   �.��6�   Delete6�   �� 5      -   5        $��	SetupRuns��5      $��14(�6*   $	��Top=�68   $��35��6M   $��7,5,7,5q�6Y   
�������
���   �.��6�   
Setup Runs6�   �� 5      -   5        $��Logout��5      $��14(�6'   $��Bottom=�65   $��35��6M   $��Bottom=�6Y   $
��7,10q�6t   
�������
���   �.��6�   Logout6�   5      &   System.Windows.Controls.DataGrid  5      -   5        $
��List��5   R   $��1��6   $��5q�6+   $��Stretch=�66   	   CanUserAddRows	 .  
   MinRowHeight$
 40Q�6�      AutoGenerateColumns .  ��6^   ��  �� SelectedItem 6v   �� *SelectedPlay+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6-      Width5  /System.Windows.Controls.DataGridLengthConverter$ 25 6P   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   �� *Id+6]     5       $ Title��6-      ElementStyle# [  6V   $	 150 6    6<   �� *Title+6�     5!      $ 	DateStart��6-   $ 80 6_    6@   �� *	DateStart+6l     5"      $ DateEnd��6-   $ 80 6[    6>   �� *	DateEnd+6h     5#      $
 Days��6-   # [  6T   $	 150 6}    6;   �� *Days+6�     5$      $
 Time��6-   # [  6T   $ 82 6}    6;   �� *Time+6�     5%      $ Prices��6-   $ 82 6Y    6=   �� *Prices+6f   5'       � 5(      $��1q�6   $��1��6#   $��Stretch=�63   $��Stretch=�6Q   
���   �$��1q�6�   6�   5)      5*      5+      5,      