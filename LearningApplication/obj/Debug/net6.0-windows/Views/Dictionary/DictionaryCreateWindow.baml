   M S B A M L   `   `   `  ����N  JLearningApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:LearningApplication.ViewsLearningApplication.Views  5   	   O,clr-namespace:LearningApplication.ViewModelsLearningApplication.ViewModels  5   	   9!clr-namespace:LearningApplicationLearningApplication  5   	   6    0LearningApplication.Views.DictionaryCreateWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:LearningApplication.Views     5   	   ;vm,clr-namespace:LearningApplication.ViewModels     5   	   1app!clr-namespace:LearningApplication     5   	   _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � 
ResizeMode$  NoResize=�5
   	    � WindowStartupLocation$ CenterScreen=�5   	      MaterialDesignBody#���   5   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	    � Title$ Tworzenie słownika��5   	   $	��400��6$   $	��500��61   .��5      � .+�5   
   �� ${�False��6   $	��Top=�6#    J� Opacity$ 1Q�6;   $��Nazwa słownika��6G   
�������$
��Left=�6s   $��	50,30,0,0q�6�   $��2q�6�   +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 10��6�   $	��200��6�   $��40��6�   $��20(�6�   
���   �6	  �� 5   
   ${�False��6   $	��Top=�6#   $ 1Q�6;   $��3��6G   $	��135��6X   $	��400��6e   
�������$
��Left=�6�   $��	50,80,0,0q�6�   $��2q�6�   $ 10��6�   $��30(�6�   
���   �6  �� 5   
   $��Medium"�6   *   $LearningApplication.SelectAllOnFocus   Enable$
 True��6&    �� 	MaxLength$ 50��6I   	 �� TextWrapping$
	 Wrap=�6X   $	��Top=�6l   $��3��6�   $	��135��6�   $	��380��6�   
������ $
��Left=�6  $��Center=�65  $��Center=�6Y  $��	60,80,0,0q�6{  $��0q�6�  $��30(�6�  
���   ���6�   �� *DictionaryName+
 �� Mode$
 TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�.��6�   J� InputBindings 5      �� 5      
 �� Key$ Enter��6C    �� Command 6   �� *CreateDictionary+6C   .��5   %   5      �� 5   
   $	��180��6   $��60��6   $|�False��6)   $��	50,0,0,30q�6;   $��Bottom=�6N   $
��Left=�6i   $��4��6�    �� 	IsDefault$
 True��6�   $��Dodaj��6�   $ 10��6�   $��20(�6  #���   6  ��6�   �� *CreateDictionary+6  �� 5   
   $	��180��6   $��60��6   $|�False��6)   $��
270,0,0,30q�6;   $��Bottom=�6O   $
��Left=�6j   $��4��6�    �� IsCancel$
 True��6�   $��Zamknij��6�   $ 10��6�   $��20(�6  #���   6  ���	#FFFF5454���	#FFFF5454��6�   �� *CloseWindow+6Y  5      5       