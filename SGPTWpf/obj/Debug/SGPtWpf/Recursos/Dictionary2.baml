   M S B A M L   `   `   `  ����n  jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   AdvertenciaStyle  �� 
TargetType �� Property �� Value �� Triggers P� Property P� Value4   .System.Windows.Media.Animation.ExponentialEase  
ExpoEaseIn7  1System.Windows.Media.Animation.EasingFunctionBase   
EasingMode    Exponent  ExpoEaseOut  ExpoEaseInOut3  -System.Windows.Media.Effects.DropShadowEffect  WaitingForDataEffect   Opacity	   
BlurRadius
   ShadowDepth  
BlackColor   Color 
 Freeze  WaitingForDataStoryboard g� AutoReverse g� Duration W� From g� RepeatBehavior �� 
TargetName �� TargetProperty g� DesiredFrameRate	 W� To ! HideFloatingMessageStoryboard W� EasingFunction !	 ShowFloatingMessageStoryboard 
 errorDataGrid �� CornerRadius � ToolTip �� ElementName �� Path  TextBlockStyleSGPt �� RelativeSource  CellEditStyle  RowStyle)  #System.Windows.Controls.DataGridRow �� Padding �� AncestorType  RowStyleSGPt  AzureDataGrid �� BasedOn�� 5      H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       :x,http://schemas.microsoft.com/winfx/2006/xaml     5      HpoAhttp://schemas.microsoft.com/winfx/2006/xaml/presentation/options  5      %�  &	        &	 �     &	 �     &	     &	 U    &	 �    &	 �    7  7  &		 N    7  7  &	
 �    &	 �    '�� M	    &	 ?
    &	 z    &	 %    7  �� 5      "  ��6'   .�5   
   ��  � ��
 �  ��6)    5   
   P� 5       �@J�IsMouseOver . . �5      ��  � ��
 � � �61   5	      5         5      $ EaseIn=�5      $ 2Q�5         5      $ EaseOut=�5      $ 2Q�5         5      $ 	EaseInOut=�5      $ 2Q�5        5      $ 0Q�5      $	 10Q�5      $
 0Q�5      # �  5      �� 5      4True 62   .��5   
   W�  . $ 00:00:02D�5       $ 0X�5!      $ Forever��5"      $# PART_WaitingForDataEffectGrid��5#      $ (Effect).Opacity�5$      $ 30X�5%      $ 1X�5&      5'      �� 5)      .��5*   
   W� $ 0:0:.2D�6   $ 15X�5+      8   $# PART_FloatingMessageContainer��5-      $ 	MaxHeight�5.      $ 0X�5/      W� 50   
   $ 0:0:.2D�6   $# PART_FloatingMessageContainer��51      $ Opacity�52      $ 0X�53      W� 54   
   $ 0:0:.2D�6   8  $ PART_FloatingMessage��56      $8 2(UIElement.RenderTransform).(TranslateTransform.Y)�57      $ 20X�58      59      �� 5;      .��5<   
   W� $ 0:0:.2D�6   $ 0X�5=      8   $# PART_FloatingMessageContainer��5?      $ 	MaxHeight�5@      $ 15X�5A      W� 5B   
   $ 0:0:.2D�6   $# PART_FloatingMessageContainer��5C      $ Opacity�5D      W� 5E   
   $ 0:0:.2D�6   8  $ PART_FloatingMessage��5G      $8 2(UIElement.RenderTransform).(TranslateTransform.Y)�5H      $ 0X�5I      5J      �� 5L      "  ��6"   .�5M   
   ��  � ��$ Center=�6.   �� 5N   
    � ��$ 0,2,40,2q�6#   �� 5O   
    �@=�ErrorTemplate 5P      �� 5Q      .R�5S      ]� ��. .+�5T      �� 
���  ��$��right=�62   $��5,0,0,0q�6I   $��20��6Z   $��20��6e   $ 10��6q    5U      �� $ customAdorner��$8 2AdornedElement.(Validation.Errors)[0].ErrorContent�._�5V      �� $��!��6(   $��center=�61   $��center=�6L   $
��Bold"�6i   
�������5W      5X      �� 5Y      $��customAdorner��64   $��Center=�6I   .v�5Z      �� 
���  ��$��3q�67   5[      5\      5]      5_      5a      �� 5c      "  ��6'    5d   
   P� 5e       �@=�HasError . . �5f      ��  �@�ToolTip 5g      ��  �� *Self+$) #(Validation.Errors)[0].ErrorContent�5i      5k      �� 5n      "  ��6    5o   
   P� 5p       �@=�HasError . . �5q      ��  �@�ToolTip 5r      ��  �� *Self+$) #(Validation.Errors)[0].ErrorContent��� 5s       � ��
 �  ��6=   5t      5v      �� 5y      "  ��6"   .�5z   
   ��  � ��$ 1q�6,   �� 5{   
    � ��$ 0q�6$    5|   
   P� 5}       �@=�HasError . . �5~      ��  �@�ToolTip 5      ��  �� *Self+$) #(Validation.Errors)[0].ErrorContent��� 5�       � ��
 �  ��6=   5�      5�      �� 5�      "   6   .�5�   
   ��  �@ ValidationErrorTemplate 5�      �� 5�      .R�5�      � .+�5�      A� $��12��6"   $��12��6-   
���  ��
���   �$	��0.5��6S   �� 5�      $
��Bold"�6$   $ 4,0,0,0q�66   $��0q�6H   $	��Top=�6S   
�������$��!��6~    5�   #   ��  �� *FindAncestor+"  $) #(Validation.Errors)[0].ErrorContent�5�      5�      5�      5�      �� 5�      "   6!   8   .�5�   
   ��  �@ ValidationErrorTemplate 5�      �� 5�      .R�5�      � .+�5�      A� $��12��6"   $��12��6-   
���  ��
���   �$	��0.5��6S   5�      5�      5�      5�      5�      