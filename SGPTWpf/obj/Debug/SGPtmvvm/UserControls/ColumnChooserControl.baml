   M S B A M L   `   `   `  ����  SGPTWpf4    .ExtendedGrid.UserControls.ColumnChooserControl   5      n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      -   5        $��Stretch=�5      $��Stretch=�6*   $��Arial)�6r   $��9(�6�     � 	Resources  5         CheckBoxStyle �� 
TargetType �� Property �� Value  CheckBoxFocusVisual  NormalBrush  NormalBorderBrush �� 
TargetType �� Opacity j� Stretch !� Visual J� Opacity	 �� StrokeStartLineCap
 �� StrokeEndLineCap �� StrokeLineJoin �� Triggers P� Property P� Value �� 
TargetName  editingTextBoxTemplate �� Mode��%�  &	        &	 �    �� 5   
   " ��6&   .�5      ��  �@J�SnapsToDevicePixels . 64   �� 5	       �@�FocusVisualStyle# �  61   �� 5
       � ��# �  6+   �� 5       � ��# �  6,   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� ._�5      � .+�5   "   �� #��z��63   #��z��6W   #��z��6�   �� 5   "   ��5   &   !� 5   *   $	 1.0Q�66   $
 None=�6D    5   .   F� 5   2   $
��path��67   $	 0.1Q�6C   "����    @KL ���- ��� р��     	���	#FF3838BA$	��1.5��6}   $	 Round=�5      $
 Round=�6   $ Round=�68   5   +   5   #   5      5       5      P� 5       �@d�	IsChecked$
 TrueY�6;   . �5    "   �� $
 path��6)    �@J�Opacity$	 1.0Q�6N   �� 5!   "   $
 path��6)    � �� �	#FF70A16F6M   �� 5"   "   $
 path��6)    � ��$	 2.5��6V   5#      P� 5$       � {� .  . �5%   "   ��  � ��
 �����6?   5&      5)      5+      -   5        50      �� 51   
   .R�52      �� -   5        
���  ��$��Arial)�52   '   $��15��6:   $	��Top=�6F   $��9(�6^   ��6�   �� *columnHeader+$ TwoWay=�6  53      54      .��55      ]� $��0��6   ��. $��Stretch=�62   $��Stretch=�6O   $��	-14,0,0,0q�6m   .+�57   
   � -   5         �Name$ 	popupDrag��57       J� IsHitTestVisible .  $��RelativePoint=�6<    � AllowsTransparency . ��.   � PlacementTarget 6V   �� .��58      �� 
����İ�$��1q�62   
�������$	 0.9Q�6_   ._�59      ��  �� Orientation$ 
Horizontal=�6   $��4,3,8,3q�67   .+�5:      �� $��../Images/plus.png��6   $��16��68   $��16��6C   �� 5;      $��9(�5<   !   
���   �$
��Bold"�5>   !   $��Center=�5?   !   $��4,0,0,0q�5A   !   ��5@   !   ��  �� Path$ DraggedItem[columnHeader]�5B      5C      5D      5E      &   System.Windows.Controls.DataGrid  5G   
   -   5          Name$
 grid��5G         AutoGenerateColumns .     
IsReadOnly .     HeadersVisibility$
 None=�5H   K      CanUserAddRows .     CanUserDeleteRows .     CanUserReorderColumns .     CanUserResizeColumns .     CanUserResizeRows .      CanUserSortColumns  .  $��0q�5K   D   !   GridLinesVisibility$
! None=�6X   ��5H      �� *ColumnChooserDataTable+��5K      Z� ��6-   Z�   5N      *  $System.Windows.Controls.DataGridCell��%E   '        �� 5O      "  6   .�5P      -   5        5S      5T      "   Columns" 5U      4  .System.Windows.Controls.DataGridCheckBoxColumn  5V      ,  &System.Windows.Controls.DataGridColumn#   Width5  /System.Windows.Controls.DataGridLengthConverter$# SizeToCells 6*   $   MinWidth$$ 25Q�6>   %   
IsReadOnly% .  1  +System.Windows.Controls.DataGridBoundColumn&   ElementStyle#& [  5X   ?   '   Binding' 5W   ,   �� *chkBox+5Z      4  .System.Windows.Controls.DataGridTemplateColumn  5[      (   CellTemplate( 5]      �� 5^      .R�5_        
���   �$��Center=�5a      ��5_   +   �� *columnHeader+5a      5b      5e        5g      )   CellEditingTemplate#) [ 6)   *   
Visibility$* 	Collapsed=�5h   2   ( 5i      �� 5j      .R�5k        
���   �$��Center=�5m      ��5k   +   �� *columnField+5m      5n      5r      5u      5v      5w      