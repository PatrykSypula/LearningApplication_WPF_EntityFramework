   M S B A M L   `   `   `  ����N  JLearningApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null[2clr-namespace:LearningApplication.Views.Statistics$LearningApplication.Views.Statistics  5   	   ;    5LearningApplication.Views.Statistics.StatisticsWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Dlocal2clr-namespace:LearningApplication.Views.Statistics     5   	   _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5
   	     � 
ResizeMode$  NoResize=�5   	    � WindowStartupLocation$ CenterScreen=�5	   	      MaterialDesignBody#���   5   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	   $	��630��5   &   $	��500��63    � Title 6	   �� *
WindowName+.��5      � .+�5   
   �� ${�False��6    J� Opacity$ 1Q�6#   $
��Data��6/   
�������$
��Left=�6Q   $��	30,10,0,0q�6l   $	��Top=�6   $��2q�6�   +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 10��6�   $	��150��6�   $��40��6�   $��20(�6�   
���   �6�   �� 5   
   ${�False��6   $	��Top=�6#   $ 1Q�6;   
�������$
��Left=�6Z   $��	30,60,0,0q�6u   $��2q�6�   $ 10��6�   $	��440��6�   $��60��6�   $��20(�6�   
���   �6�   �� 5   
   $��Medium"�6    �� 
IsReadOnly$
 True��6&    �� TextWrapping$
 Wrap=�68   $	��420��6�   $��60��6�   $��20(�6�   
������ $
��Left=�6�   $	��Top=�6�   $��Center=�6�   $��Center=�6  $��	40,60,0,0q�6;  $��0q�6N  
���   ���6L   �� *Data+	 �� StringFormat$	 HH:mm dd.MM.yyyy��6b  �� 5   
   ${�False��6   $ 1Q�6#   $��Poprawne odpowiedzi��6/   
�������$
��Left=�6`   $��
30,130,0,0q�6{   $	��Top=�6�   $��2q�6�   $ 10��6�   $	��230��6�   $��40��6�   $��20(�6  
���   �6  �� 5   
   ${�False��6   $	��Top=�6D   $ 1Q�6\   
�������$
��Left=�6{   $��
30,180,0,0q�6�   $��2q�6�   $ 10��6�   $	��440��6�   $��60��6�   $��20(�6  
���   ���6#   �� *GoodAnswers+6  �� 5   
   ${�False��6   $ 1Q�6#   $��Błędne odpowiedzi��6/   
�������$
��Left=�6^   $��
30,250,0,0q�6y   $	��Top=�6�   $��2q�6�   $ 10��6�   $	��230��6�   $��40��6�   $��20(�6�   
���   �6  �� 5   
   ${�False��6   $	��Top=�6C   $ 1Q�6[   
�������$
��Left=�6z   $��
30,300,0,0q�6�   $��2q�6�   $ 10��6�   $	��440��6�   $��60��6�   $��20(�6  
���   ���6#   �� *
AllAnswers+6  �� 5   
   ${�False��6   $ 1Q�6#   $��Skuteczność��6/   
�������$
��Left=�6X   $��
30,370,0,0q�6s   $	��Top=�6�   $��2q�6�   $ 10��6�   $	��150��6�   $��40��6�   $��20(�6�   
���   �6  �� 5   
   ${�False��6   $	��Top=�6C   $ 1Q�6[   
�������$
��Left=�6z   $��
30,420,0,0q�6�   $��2q�6�   $ 10��6�   $	��440��6�   $��60��6�   $��20(�6  
���   ���6#   �� *
Percentage+6  �� 5!   
   $	��440��6   $��60��6   $��30,500,0,30q�6)   
 �� 	IsDefault$

 True��6>    �� IsCancel$
 True��6O   $|�False��6_   $	��Top=�6q   $
��Left=�6�   $��Zamknij��6�   $ 10��6�   $��20(�6  #���   6  ���	#FFFF5454���	#FFFF5454��6�   �� *CloseWindow+6[  5"      5#      