   M S B A M L   `   `   `  ����  	ClientWPF    ClientWPF.Cashier   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Cashier��5   	   $	��300��6   $	��600��6&    � 
ResizeMode$ NoResize=�5   	    � WindowStyle$ 
ToolWindow=�5   	    � WindowStartupLocation$ CenterScreen=�5   	   .��5      � .+�5	   
   � $��5q�6    � ColumnDefinitions 5
      �� 5      $	��45* �6#   �� 5      $
��100* �6#   .+�5       � $��1q�6   $��Stretch=�6    $��Stretch=�6>   
���   �$��1q�6n   6�    � 5      $��1q�6   $��1��6   $��Stretch=�6/   $��Stretch=�6M   
���   �$��1q�6}   6�   ]� 5      .+�5      (  "System.Windows.Controls.DatePicker  -   5        $��DateDrop��5      $	��Top=�6-   $��35��6B   $��7,10,7,5q�6N   $��14(�6`   $��Center=�6n   6�   �� 5      -   5        $��Select��5      $��14(�6'   $	��Top=�65   $��35��6J   $��7,10,7,5q�6V   
�������
���   �.��6�   Select6�   �� 5      -   5        $��Logout��5      $��14(�6'   $��Bottom=�65   $��35��6M   $��Bottom=�6Y   $
��7,10q�6t   
�������
���   �.��6�   Logout6�   5      � 5      $��1��6   $
��7,10q�6#   $��Stretch=�61   .+�5      &   System.Windows.Controls.DataGrid  -   5        $��RunsGrid��5   2      CanUserAddRows .  $��Stretch=�6�      MinRowHeight$ 40Q�6�      AutoGenerateColumns .  ��6B   ��  �� SelectedItem 6Z   �� *SelectedRun+	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn
   Header$

 Time��6-      Width5  /System.Windows.Controls.DataGridLengthConverter$ 80 6T   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6;   �� *Time+6a     5      $
 Title��6-   $	 290 6W    6<   �� *Title+6e   5      5      5      5      5      