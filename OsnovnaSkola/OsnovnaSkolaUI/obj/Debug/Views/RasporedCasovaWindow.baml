   M S B A M L   `   `   `  ����I  EOsnovnaSkolaUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:OsnovnaSkolaUI.ViewsOsnovnaSkolaUI.Views  5   	   /    )OsnovnaSkolaUI.Views.RasporedCasovaWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:OsnovnaSkolaUI.Views     5   	     � Title$  RasporedCasovaWindow��5   	   $	��662��6&   $	��800��63    � 
ResizeMode$ NoResize=�6?    � WindowStartupLocation$ CenterScreen=�6U   .��5
      � -   5         �Name$ 	LoginGrid��5
      
���   �.+�5   
   �� $��Raspored časova��6   $��Center=�6*   $��66��6N   $��
21,10,23,0q�6Z   $	��Top=�6n   $��26(�6�   $��Segoe UI)�6�   ���	#FFFBFB9F6�   &   System.Windows.Controls.DataGrid  5   
   $
��Left=�6e   $	��208��6�   $��
21,411,0,0q�6�   $	��Top=�6�   $	��750��6�      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6�      AutoGenerateColumns .     
IsReadOnly . ��6   �� *Casovi+ �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ TwoWay=�	 �� SelectedItem	 6�   �� *SelectedCas+
   Columns
 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Datum��6%    �� TextAlignment$ Center=�64      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 6U   �� *datum+ �� StringFormat$ {0:dd.MM.yyyy}��   ElementStyle 5      �� 5       �� 
TargetType" ��6    .�5      ��  �� Property � �� �� Value$
 Wrap=�6=   �� 5       � ��$ Center=�6D   �� 5       � ��$ Center=�6B   5      5        5      $ Početak��6%   $ Center=�66    .  6W   �� *	pocetak+ 5      �� 5      " ��6    .�5      ��  � ��$
 Wrap=�6=   �� 5       � ��$ Center=�6D   �� 5        � ��$ Center=�6B   5!      5#        5%      $ 	Učionica��6%   $ Center=�67    .  6X   �� *
ucionica+ 5&      �� 5'      " ��6    .�5(      ��  � ��$
 Wrap=�6=   �� 5)       � ��$ Center=�6D   �� 5*       � ��$ Center=�6B   5+      5-        5/      $ Oblast��6%   $ Center=�65    .  6V   �� *naziv_oblasti+ 50      �� 51      " ��6    .�52      ��  � ��$
 Wrap=�6=   �� 53       � ��$ Center=�6D   �� 54       � ��$ Center=�6B   55      57        59      $ 	Odeljenje��6%   $ Center=�68    .  6Y   �� *	odeljenje+ 5:      �� 5;      " ��6    .�5<      ��  � ��$
 Wrap=�6=   �� 5=       � ��$ Center=�6D   �� 5>       � ��$ Center=�6B   5?      5A      5L      �� 5N   
   $��Datum odrzavanja:��6   $��Center=�6,   $
��Left=�6P   $��38��6k   $��
275,81,0,0q�6w   $	��Top=�6�   $	��244��6�   $��Segoe UI)�6�   ���	#FFFBFB9F$��20(�6�   (  "System.Windows.Controls.DatePicker  5R   
   $��113,119,127,476q�6=      SelectedDate 6   �� *SelectedDatum+6X   �� 5T   
   -   5        $��prezimeError��5T   W   $��Center=�6k   $��Center=�6�   $
��Left=�6�   $	��104��6�   $��113,244,0,0q�6�   $	��Top=�6�   $	��554��6  $��Segoe UI)�6  ���	#FFFBFB9F$��20(�6?  ��6   �� *RasporedError+$ PropertyChanged=�6?  �� 5U   
   $��PROVERI��6   $
��Left=�6#   $��77��6�   $��294,162,0,0q�6�   $	��Top=�6�   $	��194��6�   ���	#FFFBFB9F
������ $��Segoe UI)�6�   
�������$��22(�6&  ��6>   �� *CheckRasporedCommand+y�6g   �� *	IsAdmin+6&  5V      5W      