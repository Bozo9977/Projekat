   M S B A M L   `   `   `  ����I  EOsnovnaSkolaUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:OsnovnaSkolaUI.ViewsOsnovnaSkolaUI.Views  5   	   '    !OsnovnaSkolaUI.Views.AddCasWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:OsnovnaSkolaUI.Views     5   	     � Title$  Novi Cas��5   
   $	��713��6   $	��800��6(    � 
ResizeMode$ NoResize=�64    � WindowStartupLocation$ CenterScreen=�6J    � 	Resources 5	         FocusTextBox �� 
TargetType �� Triggers �� Binding �� ElementName �� Path	 �� Value
 �� Property �� Value��%�   &	        �� 5
   
   " �6%    5      �� 5       6   �� $ 
textBoxIme��$ 	IsVisible�	 True6Y   .a�5      �� 
 �@+�FocusedElement 6D   �� $ textBoxPrezime��5      5      5      .��5      � -   5         �Name$ 	LoginGrid��5      
���   �#��[  61   .+�5   
   �� $
��ČAS��6   $��Center=�6   $��66��6B   $��
21,10,23,0q�6N   $	��Top=�6b   $��26(�6{   $��Segoe UI)�6�   ���	#FFFBFB9F6�   �� 5   
   $��	Početak:��6   $��Center=�6#   $
��Left=�6G   $��34��6b   $��275,188,0,0q�6n   $	��Top=�6�   $	��244��6�   $��Segoe UI)�6�   ���	#FFFBFB9F$��20(�6�   �� 5   
   -   5         ��Name$ ImeBox��5      $
��Left=�6"   $
��Left=�6=   $��Center=�6_   $��Khmer UI)�6�   $��20(�6�    �� TextWrapping$
 Wrap=�6�   $	��244��6�   $��275,232,0,0q�6  ���	#FF2E2E2E���	#FF282829���	#FFFBFB9F$��39��6_  $	��Top=�6k  ��6�   �� *	Pocetak+ �� UpdateSourceTrigger$ PropertyChanged=�.��6�   J� InputBindings 5      �� 5      
 �� Key$ Enter��6?    �� Command 6   �� *AddCasCommand+6?   .��5   %   5      �� 5   
   -   5        $��imeError��5   V   $��Center=�6f   $��Center=�6�   $
��Left=�6�   $��169,276,0,347q�6�   $	��440��6�   $��Segoe UI)�6�   
���  ��$��16(�6  ��6   �� *PocetakError+$ PropertyChanged=�6  &   System.Windows.Controls.DataGrid  5   
   $
��Left=�6�   $	��194��6�   $��
21,321,0,0q�6�   $	��Top=�6�   $	��750��6�      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6     AutoGenerateColumns .     
IsReadOnly . ��6   �� *	Odeljenja+$ PropertyChanged=� �� Mode$ TwoWay=�y�6g   �� *Modification+ �� SelectedItem 6�   �� *SelectedOdeljenje+   Columns 5       0  *System.Windows.Controls.DataGridTextColumn  5+      ,  &System.Windows.Controls.DataGridColumn   Header$ Razred��6%    �� TextAlignment$ Center=�65      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 6V   �� *razred+   ElementStyle 5,      �� 5-      " ��6    .�5.      �� 
 � ��$
 Wrap=�6=   �� 5/      
 � ��$ Center=�6D   �� 50      
 � ��$ Center=�6B   51      53        56      $ Razredni��6%   $ Center=�67    .  6X   �� *
Razredni+ 57      �� 58      " ��6    .�59      �� 
 � ��$
 Wrap=�6=   �� 5:      
 � ��$ Center=�6D   �� 5;      
 � ��$ Center=�6B   5<      5>      5Q      �� 5S   
   $��Datum održavanja:��6   $��Center=�6,   $
��Left=�6P   $��38��6k   $��
275,81,0,0q�6w   $	��Top=�6�   $	��244��6�   $��Segoe UI)�6�   ���	#FFFBFB9F$��20(�6�   (  "System.Windows.Controls.DatePicker  5W   
   $��113,119,127,514q�6=      SelectedDate 6   �� *SelectedDatum+6X   �� 5Y   
   -   5        $��prezimeError��5Y   S   $��Center=�6g   $��Center=�6�   $
��Left=�6�   $��34��6�   $��169,149,0,0q�6�   $	��Top=�6�   $	��440��6  $��Segoe UI)�6  
���  ��$��16(�64  ��6   �� *	DateError+$ PropertyChanged=�64  �� 5[   
    �� 	IsDefault . $
��Left=�6g   $��24(�6�   $	��Top=�6�   $	��130��6�   $��331,605,0,0q�6�   $��48��6�     J� RenderTransformOrigin$  0.503,0.458&�6�   $��Segoe UI)�6�   
������ 
��� ������	#FFFBFB9F$
��Bold"�6T  ��6   �� *ButtonContent+��6E   �� *AddCasCommand+6T  �� 5\   
   $��OBRIŠI��6    . $
��Left=�6�   $��24(�6�   $	��Top=�6�   $	��130��6�   $��331,557,0,0q�6�   $��48��6�   $  	0.5,0.514&�6�   $��Segoe UI)�6  
������ 
��� ������	#FFFBFB9F$
��Bold"�6k  y�6#   �� *DeletionEnabled+��6[   �� *DeleteCasCommand+6k  5^      5_      