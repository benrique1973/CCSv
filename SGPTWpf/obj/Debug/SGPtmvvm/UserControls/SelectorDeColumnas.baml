   M S B A M L   `   `   `  ����  SGPTWpf6    0SGPTWpf.SGPtmvvm.UserControls.SelectorDeColumnas   5      n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -   5        $��Stretch=�5      $��Stretch=�6*   $��Arial)�6r   $��9(�6�     � 	Resources  5         CheckBoxStyle �� 
TargetType �� Property �� Value  CheckBoxFocusVisual  NormalBrush  NormalBorderBrush �� 
TargetType �� Opacity j� Stretch !� Visual J� Opacity	 �� StrokeStartLineCap
 �� StrokeEndLineCap �� StrokeLineJoin �� Triggers P� Property P� Value �� 
TargetName  editingTextBoxTemplate �� Mode��%�  &	        &	 �    �� 5	   
   " ��6&   .�5
      ��  �@J�SnapsToDevicePixels . 64   �� 5       �@�FocusVisualStyle# �  61   �� 5       � ��# �  6+   �� 5       � ��# �  6,   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� ._�5      � .+�5   "   �� #��z��63   #��z��6W   #��z��6�   �� 5   "   ��5   &   !� 5   *   $	 1.0Q�66   $
 None=�6D    5   .   F� 5   2   $
��path��67   $	 0.1Q�6C   "����    @KL ���- ��� р��     	���	#FF3838BA$	��1.5��6}   $	 Round=�5      $
 Round=�6   $ Round=�68   5   +   5   #   5      5       5       P� 5!       �@d�	IsChecked$
 TrueY�6;   . �5"   "   �� $
 path��6)    �@J�Opacity$	 1.0Q�6N   �� 5#   "   $
 path��6)    � �� �	#FF70A16F6M   �� 5$   "   $
 path��6)    � ��$	 2.5��6V   5%      P� 5&       � {� .  . �5'   "   ��  � ��
 �����6?   5(      5+      5-      -   5        52      �� 53   
   .R�54      �� -   5        
���  ��$��Arial)�54   '   $��15��6:   $	��Top=�6F   $��9(�6^   ��6�   �� *columnHeader+$ TwoWay=�6  55      56      .��57      ]� $��0��6   ��. $��Stretch=�62   $��Stretch=�6O   $��	-14,0,0,0q�6m   .+�59   
   � -   5         �Name$ 	popupDrag��59       J� IsHitTestVisible .  $��RelativePoint=�6<    � AllowsTransparency . ��.   � PlacementTarget 6V   �� .��5:      �� 
����İ�$��1q�62   
�������$	 0.9Q�6_   ._�5;      ��  �� Orientation$ 
Horizontal=�6   $��4,3,8,3q�67   .+�5<      �� $��../Images/plus.png��6   $��16��68   $��16��6C   �� 5=      $��9(�5>   !   
���   �$
��Bold"�5@   !   $��Center=�5A   !   $��4,0,0,0q�5C   !   ��5B   !   ��  �� Path$ DraggedItem[columnHeader]�5D      5E      5F      5G      &   System.Windows.Controls.DataGrid  5I   
   -   5          Name$
 grid��5I         AutoGenerateColumns .     
IsReadOnly .     HeadersVisibility$
 None=�5J   K      CanUserAddRows .     CanUserDeleteRows .     CanUserReorderColumns .     CanUserResizeColumns .     CanUserResizeRows .      CanUserSortColumns  .  $��0q�5M   D   !   GridLinesVisibility$
! None=�6X   ��5J      �� *ColumnChooserDataTable+��5M      Z� ��6-   Z�   5P      *  $System.Windows.Controls.DataGridCell��%E   '        �� 5Q      "  6   .�5R      -   5        5U      5V      "   Columns" 5W      4  .System.Windows.Controls.DataGridCheckBoxColumn  5X      ,  &System.Windows.Controls.DataGridColumn#   Width5  /System.Windows.Controls.DataGridLengthConverter$# SizeToCells 6*   $   MinWidth$$ 25Q�6>   %   
IsReadOnly% .  1  +System.Windows.Controls.DataGridBoundColumn&   ElementStyle#& [  5Z   ?   '   Binding' 5Y   ,   �� *chkBox+5\      4  .System.Windows.Controls.DataGridTemplateColumn  5]      (   CellTemplate( 5_      �� 5`      .R�5a        
���   �$��Center=�5c      ��5a   +   �� *columnHeader+5c      5d      5g        5i      )   CellEditingTemplate#) [ 6)   *   
Visibility$* 	Collapsed=�5j   2   ( 5k      �� 5l      .R�5m        
���   �$��Center=�5o      ��5m   +   �� *columnField+5o      5p      5t      5w      5x      5y      