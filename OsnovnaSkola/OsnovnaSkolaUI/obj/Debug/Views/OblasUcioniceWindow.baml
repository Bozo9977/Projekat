   M S B A M L   `   `   `  ����I  EOsnovnaSkolaUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:OsnovnaSkolaUI.ViewsOsnovnaSkolaUI.Views  5   	   .    (OsnovnaSkolaUI.Views.OblasUcioniceWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:OsnovnaSkolaUI.Views     5   	     � Title$"  Izaberite učionicu i oblast��5   	   $	��450��6-   $	��800��6:    � WindowStartupLocation$ CenterScreen=�6F   .��5	      � 
���   � � ColumnDefinitions 5
   
   �� 5      $��7* �6   �� 5      $	��29* �6   .+�5   
   &   System.Windows.Controls.DataGrid  $
��Left=�6i   $	��224��6�   $��0,60,0,0q�6�   $	��Top=�6�   $	��397��6�      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6�      AutoGenerateColumns .     
IsReadOnly . $��2��6/  ��6   �� *
Ucionice+ �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ TwoWay=� �� SelectedItem 6�   �� *SelectedUcionica+	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn
   Header$
 Naziv��6%    �� TextAlignment$ Center=�64      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 6U   �� *naziv+   ElementStyle 5      �� 5       �� 
TargetType" ��6    .�5      ��  �� Property � �� �� Value$
 Wrap=�6=   �� 5       � ��$ Center=�6D   �� 5        � ��$ Center=�6B   5!      5#        5&      $
 Broj učenika��6%   $ Center=�6;    .  6\   �� *broj_ucenika+ 5'      �� 5(      " ��6    .�5)      ��  � ��$
 Wrap=�6=   �� 5*       � ��$ Center=�6D   �� 5+       � ��$ Center=�6B   5,      5.      5A        5D   
   $ * 6�    .   . $
��Left=�6�   $	��224��6�   $��248.396,60,0,0q�6�   $	��Top=�6  $	��390��6$  $��1��60  ��6   �� *	Oblasti+$ PropertyChanged=�$ TwoWay=� 6f   �� *SelectedOblast+	 5E        5P      $
 Naziv��6%   $ Center=�64    .  6U   �� *naziv+ 5Q      �� 5R      " ��6    .�5S      ��  � ��$
 Wrap=�6=   �� 5T       � ��$ Center=�6D   �� 5U       � ��$ Center=�6B   5V      5X        5[      $
 Id predmeta��6%   $ Center=�6:    .  6[   �� *PredmetId_predmeta+ 5\      �� 5]      " ��6    .�5^      ��  � ��$
 Wrap=�6=   �� 5_       � ��$ Center=�6D   �� 5`       � ��$ Center=�6B   5a      5c      5f      �� 5i   
   -   5         ��Name$ button��5i      $��NAPRAVI ČAS��6!   
������ $��Segoe UI)�6v   ���	#FFFBFB9F
��� ���$��22(�6�   $
��Left=�6�   $��44��6�   $��171,365,0,0q�6�   $	��Top=�6   $	��149��6  $��1��6$  ��67   �� *NapraviCasCommand+6$  �� 5j   
   -   5         ��Name$ label��5j      $��Izaberite učionicu��6   ���	#FFFBFB9F$��22(�6S   $
��Left=�6a   $��45��6|   $��	10,10,0,0q�6�   $	��Top=�6�   $	��341��6�   $��2��6�   �� 5k   
   -   5        $ 
label_Copy��5k      $��Izaberite oblast��6$   ���	#FFFBFB9F$��22(�6V   $
��Left=�6d   $��45��6   $��248.396,10,0,0q�6�   $	��Top=�6�   $	��341��6�   $��1��6�   �� 5l   
   -   5        $ label1��5l      
���  ��$��24(�6u   $��Center=�6�   $��Center=�6�   $
��Left=�6�   $��43��6�   $��	0,300,0,0q�6�   $	��Top=�6  $	��792��6  $��2��6'  ��6    �� *
ErrorLabel+$ PropertyChanged=�6'  5n      5o      