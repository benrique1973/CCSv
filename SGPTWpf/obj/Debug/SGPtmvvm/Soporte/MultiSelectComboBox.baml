   M S B A M L   `   `   `  ����  SGPTWpf*    $SGPTmvvm.Soporte.MultiSelectComboBox   5      n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      .��5      �� -   5          ��Name$  MultiSelectCombo��5   	    J� SnapsToDevicePixels .  � OverridesDefaultStyle . $
��Auto=�5	   	   $
��Auto=�5
   	   ��. $ �� IsSynchronizedWithCurrentItem$
 TrueY�5   	   ��5   
   �� 5      .R�5      �� -   5        ��5      �� *descripcion+ d� 	IsChecked 5      ��  �� Path$ esSeleccionado� �� Mode$ OneWay=� �� UpdateSourceTrigger$ PropertyChanged=�
 � Tag 5      �� *FindAncestor+	 �� AncestorType"	 ��5      5      ��5   
   �� 5      
 �� 
TargetType"
 ��6   .R�5      � .+�5      d�  d�Name$ ToggleButton��5      $��2��5      |�.   �� 	ClickMode$ Press=�5      $
��Left=�6+    5   (   �� $ IsDropDownOpen�$ TwoWay=� �� RelativeSource �� *TemplatedParent+��5      �� 5       .R�5!   "   �  � ColumnDefinitions 5"   &   �� 5#   *   $��* �6;   �� 5$   *   $��18 �6;   .+�5&   &   ��  ��Name$ Border��5'   '   $��2��5(   '    �� CornerRadius$ 2��5)   '   
�������
���   �$��1,1,1,1q�5,   '   �� 5-   &   $ 
BorderComp��5.   )   $��0��5/   '   $ 2��50   '   $��1q�51   '   
�������
���   �$��0,0,0,0q�54   '   ._�55   *   �� 
������� �� Padding$ 3q�56   C   ��55   4   �� $
 Text� ��  �� Mode$ FindAncestor=�$	 UserControlL�56   C   57   '   F� 58   &    F�Name$ Arrow��59      $��1��5:      
���   �$��Center=�5<      $��Center=�5=      "����        � 	=  	= � z     	5>      5?   #   5@      5B      � 5C      $��Popup��5D      $��Bottom=�5E       � AllowsTransparency . |�.   �� IsDropDownOpen#��z 5G   ,   $��Slide=�5H      .��5I      � $��DropDown��5J   #    .  � ActualWidth#��z 5L       �� MaxDropDownHeight#��z 5M   #   .+�5N      �� $ DropDownBorder��5O   %   $��1q�5P   $   
�������
���   �5Q   %   �� 5R      $��4,6,4,6q�6+    .  � DataContext 6W   �� .��5S   "   ��  K� IsItemsHost . -  'System.Windows.Input.KeyboardNavigation   DirectionalNavigation$ 	Contained=�6@   5T      5U      5V      5W       �� Triggers 5X      P� 5Y       P� Property �@��HasItems P� Value .  . �5Z      ��  �� 
TargetName$ DropDownBorder��6!    �� Property � ��  �� Value$  95��6R   5[      P� 5\      ! P� 
SourceName$! Popup��6    �@�AllowsTransparency . . �5]      �� $ DropDownBorder��6!    �@��CornerRadius$  4��6U   �� 5^      $ DropDownBorder��6!    � ��$  0,2,0,0q�6O   5_      5a      5c      5d      