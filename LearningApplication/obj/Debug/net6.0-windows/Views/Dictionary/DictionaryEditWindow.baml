   M S B A M L   `   `   `  ����N  JLearningApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:LearningApplication.ViewsLearningApplication.Views  5   	   O,clr-namespace:LearningApplication.ViewModelsLearningApplication.ViewModels  5   	   9!clr-namespace:LearningApplicationLearningApplication  5   	   4    .LearningApplication.Views.DictionaryEditWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:LearningApplication.Views     5   	   ;vm,clr-namespace:LearningApplication.ViewModels     5   	   1app!clr-namespace:LearningApplication     5   	   _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � 
ResizeMode$  NoResize=�5
   	    � WindowStartupLocation$ CenterScreen=�5   	      MaterialDesignBody#���   5   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	   $	��550��5   &   $
��1150��63    � Title 6	   �� *
WindowName+.��5      � .+�5   
   �� ${�False��6   $	��Top=�6#    J� Opacity$ 1Q�6;   $��Słowo po polsku��6G   
�������$
��Left=�6t   $��	50,30,0,0q�6�   $��2q�6�   +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 10��6�   $	��180��6�   $��40��6�   $��20(�6�   
���   �6
  �� 5   
   ${�False��6   $	��Top=�6#   $ 1Q�6;   $��3��6G   $	��135��6X   $	��400��6e   
�������$
��Left=�6�   $��	50,80,0,0q�6�   $��2q�6�   $ 10��6�   $��30(�6�   
���   �6  �� 5   
   $��Medium"�6    �� 	MaxLength$ 50��6&   *   $LearningApplication.SelectAllOnFocus   Enable$
 True��65   	 �� TextWrapping$
	 Wrap=�6X   $	��Top=�6l   $��3��6�   $	��135��6�   $	��380��6�   
������ $
��Left=�6  $��Center=�65  $��Center=�6Y  $��	60,80,0,0q�6{  $��0q�6�  $��30(�6�  
���   ���6�   �� *WordPolishInput+
 �� Mode$
 TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�.��6�   J� InputBindings 5      �� 5      
 �� Key$ Enter��6:    �� Command 6   �� *	WordAdd+6:   .��5   %   5      �� 5   
   ${�False��6   $	��Top=�6#   $ 1Q�6;   $��Tłumaczenie��6G   
�������$
��Left=�6p   $��
50,225,0,0q�6�   $��2q�6�   $ 10��6�   $	��180��6�   $��40��6�   $��20(�6�   
���   �6  �� 5   
   ${�False��6   $	��Top=�6#   $ 1Q�6;   $��3��6G   $	��135��6X   $	��400��6e   
�������$
��Left=�6�   $��
50,275,0,0q�6�   $��2q�6�   $ 10��6�   $��30(�6�   
���   �6  �� 5   
   $��Medium"�6   $ 50��6&   $
 True��65   $
	 Wrap=�6X   $	��Top=�6l   $��3��6�   $	��135��6�   $	��380��6�   
������ $
��Left=�6  $��Center=�6:  $��Center=�6^  $��
60,275,0,0q�6�  $��0q�6�  $��30(�6�  
���   ���6�   �� *WordTranslatedInput+$
 TwoWay=�$ PropertyChanged=�.��6�   5       �� 5!      $ Enter��6:    6   �� *	WordAdd+6:   .��5"   %   5#      �� 5$   
   $	��120��6   $��60��6   $��	50,0,0,30q�6)   $��Bottom=�6<   $
��Left=�6W   $��4��6r   $��Dodaj��6�   $ 10��6�   $��20(�6�   #���   6�   ��6   �� *	WordAdd+6�   �� 5%   
   $	��120��6   $��60��6   $��
190,0,0,30q�6)   $��Bottom=�6=   $
��Left=�6X   $��4��6s   $��Zamień��6�   $ 10��6�   $��20(�6�   #���   6�   
��� ���$��0q�61  ��6�   �� *
WordEdit+61  �� 5&   
   $	��120��6   $��60��6   $��
330,0,0,30q�6)   $��Bottom=�6=   $
��Left=�6X   $��4��6s   $��Usuń��6�   $ 10��6�   $��20(�6�   #���   6�   
���  ��$��0q�6-  ��6�   �� *
WordDelete+6-  &   System.Windows.Controls.DataGrid  5(   
   $
��Left=�6   $|�False��6.   $��
500,30,0,0q�6@   $	��600��6T   $	��380��6`   $��20(�6m   $	��Top=�6{      CanUserAddRows$ False��6�      
IsReadOnly$
 True��6�      AutoGenerateColumns$ False��6�    �� SelectedItem 6�   �� *SelectedItem+��6�   �� *	WordsList+   	CellStyle 5)      �� 5*       �� 
TargetType*  $System.Windows.Controls.DataGridCell"  6     MaterialDesignDataGridCell �� BasedOn# [ 62   .�5+      ��  �� Property � |� �� Value$ False��62   5,         Columns 5.      0  *System.Windows.Controls.DataGridTextColumn  5/      ,  &System.Windows.Controls.DataGridColumn   Header$ Słowo po polsku��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6>   1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding 6H   �� *
WordPolish+  50      $ Tłumaczenie��6%   $ * 6:    6D   �� *WordTranslated+52      �� 53   
   $	��120��6   $��60��6   $��
980,0,0,30q�6)   $|�False��6=   $��Bottom=�6O   $
��Left=�6j   $��4��6�   $��Zamknij��6�   $ 10��6�   $��20(�6�   #���   6   ���	#FFFF5454���	#FFFF5454��6�   �� *CloseWindow+6I  54      55      